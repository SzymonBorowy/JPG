using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZalogujIPobierz;
namespace InterpretacjaTekstu
{
    public class Interpretuj
    {
        private string[] polecenia = null;
        public Interpretuj(string sciezka)
        {
            polecenia = File.ReadAllLines(sciezka);
            wykonaj();
        }

        private void wykonaj()
        {
            zalogujIPobierz zaloguj = null; 
            foreach (var item in polecenia)
            {
                string[] linia = item.Split(' ');
                switch (linia[0].ToLower())
                {
                    case "zaloguj":
                        zaloguj = new zalogujIPobierz(linia[1],linia[2],linia[3]);
                        zaloguj.start();
                        break;
                    case "pobierz":
                        if (zaloguj.czyZalogowany)
                            zaloguj.pobierzRaportyZLinku(linia[1]);
                        break;
                    case "printscreen":
                        if (zaloguj.czyZalogowany)
                            zaloguj.PrintScreen(linia[1]);
                            break;
                    case "zakoncz":
                        if (zaloguj.czyZalogowany)
                            zaloguj.stop();
                            break;
                    default:
                        break;
                }
            }
        }
    }
}
