using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

using PorownajJPG;
using KonwertujPlikiDoJPG;

namespace PorownajZIPy
{
    public class PorownajZip
    {
        private string sciezkaDoZipa1;
        private string sciezkaDoZipa2;
        private string sciezkaDoWyniku;
        private string sciezkaDorozpakowanegoZipa1;
        private string sciezkaDorozpakowanegoZipa2;
        private List<string> plikiWZipie1;
        private List<string> plikiWZipie2;
        private List<string> jpg1;
        private List<string> jpg2;

        private bool czyPokazacDokladneRoznice;


        public PorownajZip(string text1, string text2, string text3)
        {
            this.sciezkaDoZipa1 = text1;
            this.sciezkaDoZipa2 = text2;
            this.sciezkaDoWyniku = text3 +"\\";
            plikiWZipie1 = new List<string>();
            plikiWZipie2 = new List<string>();
            jpg1= new List<string>();
            jpg2 = new List<string>();
            czyPokazacDokladneRoznice = false;
            //start();
        }
        int i = 1;
        private void wszystko(string sciezka, string sciezkaDoWynikowegoFolderu, List<string> plikiWZipie, List<string> jpg)
        {
            var a = sciezka.Remove(0,sciezka.LastIndexOf(".") + 1);
            switch (a)
            {
                case "zip":
                    var nazwa = sciezka.Substring(sciezka.LastIndexOf("\\") + 1, sciezka.LastIndexOf(".") - (sciezka.LastIndexOf("\\") + 1));
                    wypakuj(sciezka, nazwa);
                    sciezkaDoWynikowegoFolderu = sciezkaDoWyniku + sciezka.Remove(0, sciezka.LastIndexOf("\\") + 1);
                    sciezkaDoWynikowegoFolderu = sciezkaDoWynikowegoFolderu.Remove(sciezkaDoWynikowegoFolderu.LastIndexOf("."));
                    znajdzPliki(sciezkaDoWynikowegoFolderu, plikiWZipie);
                    if (plikiWZipie.Count == 0)
                    {
                        sciezkaDoWynikowegoFolderu += "\\" + nazwa;
                        znajdzPliki(sciezkaDoWynikowegoFolderu, plikiWZipie);
                    }
                    break;
                #region Pojedyńcze pliki
                case "pdf":
                    sciezkaDoWynikowegoFolderu = sciezkaDoWyniku + i.ToString();
                    Directory.CreateDirectory(sciezkaDoWynikowegoFolderu);
                    var sciezkaDoPliku = sciezkaDoWynikowegoFolderu + "\\" + sciezka.Remove(0, sciezka.LastIndexOf("\\") + 1);
                    kopjujPlik(sciezka, sciezkaDoPliku);
                    znajdzPliki(sciezkaDoWynikowegoFolderu, plikiWZipie);
                    i++;
                    break;
                case "doc":
                    sciezkaDoWynikowegoFolderu = sciezkaDoWyniku + i.ToString();
                    Directory.CreateDirectory(sciezkaDoWynikowegoFolderu);
                    sciezkaDoPliku = sciezkaDoWynikowegoFolderu + "\\" + sciezka.Remove(0, sciezka.LastIndexOf("\\") + 1);
                    kopjujPlik(sciezka, sciezkaDoPliku);
                    znajdzPliki(sciezkaDoWynikowegoFolderu, plikiWZipie);
                    i++;
                    break;
                case "docx":
                    sciezkaDoWynikowegoFolderu = sciezkaDoWyniku + i.ToString();
                    Directory.CreateDirectory(sciezkaDoWynikowegoFolderu);
                    sciezkaDoPliku = sciezkaDoWynikowegoFolderu + "\\" + sciezka.Remove(0, sciezka.LastIndexOf("\\") + 1);
                    kopjujPlik(sciezka, sciezkaDoPliku);
                    znajdzPliki(sciezkaDoWynikowegoFolderu, plikiWZipie);
                    i++;
                    break;
                case "xls":
                    sciezkaDoWynikowegoFolderu = sciezkaDoWyniku + i.ToString();
                    Directory.CreateDirectory(sciezkaDoWynikowegoFolderu);
                    sciezkaDoPliku = sciezkaDoWynikowegoFolderu + "\\" + sciezka.Remove(0, sciezka.LastIndexOf("\\") + 1);
                    kopjujPlik(sciezka, sciezkaDoPliku);
                    znajdzPliki(sciezkaDoWynikowegoFolderu, plikiWZipie);
                    i++;
                    break;
                case "xlsx":
                    sciezkaDoWynikowegoFolderu = sciezkaDoWyniku + i.ToString();
                    Directory.CreateDirectory(sciezkaDoWynikowegoFolderu);
                    sciezkaDoPliku = sciezkaDoWynikowegoFolderu + "\\" + sciezka.Remove(0, sciezka.LastIndexOf("\\") + 1);
                    kopjujPlik(sciezka, sciezkaDoPliku);
                    znajdzPliki(sciezkaDoWynikowegoFolderu, plikiWZipie);
                    i++;
                    break;
                #endregion
                default:
                    sciezkaDoWynikowegoFolderu = sciezkaDoWyniku + sciezka.Remove(0, sciezka.LastIndexOf("\\") + 1);
                    kopjujFolder(sciezka, sciezkaDoWynikowegoFolderu);
                    znajdzPliki(sciezkaDoWynikowegoFolderu, plikiWZipie);
                    break;
            }
            konwertuj(sciezkaDoWynikowegoFolderu, plikiWZipie, jpg);
        }
        public void pokazRoznice(bool roznica)
        {
            czyPokazacDokladneRoznice = roznica;
        }
        public void start()
        {
            Directory.CreateDirectory(sciezkaDoWyniku + "Roznice");
            wszystko(sciezkaDoZipa1, sciezkaDorozpakowanegoZipa1, plikiWZipie1, jpg1);
            wszystko(sciezkaDoZipa2, sciezkaDorozpakowanegoZipa2, plikiWZipie2, jpg2);
            porownajOdpowiadajacePliki();
        }

        private void konwertuj(string sciezkaDoWynikowegoFolderu, List<string> plikiWZipie, List<string> jpg)
        {
            for (int i =0;i<plikiWZipie.Count;i++)
            {
                KonwertujDoJPG konwertuj1 = new KonwertujDoJPG(plikiWZipie[i], sciezkaDoWynikowegoFolderu + "\\jpg_pliku_" + plikiWZipie[i].Substring(plikiWZipie[i].LastIndexOf("\\") + 1, plikiWZipie[i].LastIndexOf(".") - (plikiWZipie[i].LastIndexOf("\\") + 1)), plikiWZipie[i].Remove(0, plikiWZipie[i].LastIndexOf(".") + 1));
                string s1 = sciezkaDoWynikowegoFolderu + "\\jpg_pliku_" + plikiWZipie[i].Substring(plikiWZipie[i].LastIndexOf("\\") + 1, plikiWZipie[i].LastIndexOf(".") - (plikiWZipie[i].LastIndexOf("\\") + 1)) + ".jpg";
                jpg.Add(s1);
            }
        }

        private void porownajOdpowiadajacePliki()
        {
            List<string> listaNiePasujacychz1 = new List<string>();
            List<string> listaNiePasujacychz2 = new List<string>();
            foreach (var item in jpg1)
            {
                listaNiePasujacychz1.Add(item);
            }
            foreach (var item in jpg2)
            {
                listaNiePasujacychz2.Add(item);
            }

            string nazwa1 = null, nazwa2 = null;

            for (int i = 0; i < jpg1.Count; i++)
            {
                nazwa1 = jpg1[i].Substring(jpg1[i].LastIndexOf("\\") + 1);
                for (int j = 0; j < jpg2.Count; j++)
                {
                    nazwa2 = jpg2[j].Substring(jpg2[j].LastIndexOf("\\") + 1);
                    if (nazwa1 == nazwa2)
                    {
                        PorownajJpg porownaj = new PorownajJpg(jpg1[i], jpg2[j], sciezkaDoWyniku + "roznice", 1);
                        porownaj.pokazRoznice(czyPokazacDokladneRoznice);
                        porownaj.start();
                        listaNiePasujacychz1.Remove(jpg1[i]);
                        listaNiePasujacychz2.Remove(jpg2[j]);
                        
                        break;
                    }
                }
            }
            nieDopasowane(listaNiePasujacychz1);
            nieDopasowane(listaNiePasujacychz2);

        }

        private void nieDopasowane(List<string> listaNiePasujacych)
        {
            if (listaNiePasujacych.Count != 0)
            {
                var folder = listaNiePasujacych[0].Remove(listaNiePasujacych[0].LastIndexOf("\\"));
                folder = folder.Remove(0, folder.LastIndexOf("\\") + 1);
                Directory.CreateDirectory(sciezkaDoWyniku + "Niedopasowane z folderu " + folder);
                foreach (var item in listaNiePasujacych)
                {
                    File.Copy(item, sciezkaDoWyniku + "Niedopasowane z folderu " + folder+ "\\"+ item.Substring(item.LastIndexOf("\\") + 1));
                }
            }
        }

        private void znajdzPliki(string sciezkaDorozpakowanegoZipa, List<string> plikiWZipie)
        {
            DirectoryInfo di = new DirectoryInfo(sciezkaDorozpakowanegoZipa);
            foreach (var item in di.GetFiles())
            {
                plikiWZipie.Add(sciezkaDorozpakowanegoZipa+"\\"+ item.ToString());
            }     
        }
        private void wypakuj(string sciezkaDoZipa, string nazwa)
        {
            Directory.CreateDirectory(sciezkaDoWyniku + nazwa);
            ZipFile.ExtractToDirectory(sciezkaDoZipa, sciezkaDoWyniku + nazwa + "\\");
        }

        private void kopjujPlik(string sciezka1, string sciezka2)
        {
            File.Copy(sciezka1, sciezka2, true);
        }
        private void kopjujFolder(string sciezka1, string sciezka2)
        {
            DirectoryInfo di = new DirectoryInfo(sciezka1);
            if(Directory.Exists(sciezka2) == false)
            {
                Directory.CreateDirectory(sciezka2);
            }
            foreach (var item in di.GetFiles())
            {
                File.Copy(sciezka1 +"\\"+item, sciezka2 + "\\" + item);
            }
        }
    }
}
