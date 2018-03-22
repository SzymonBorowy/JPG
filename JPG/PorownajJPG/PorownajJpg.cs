using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.IO;

namespace PorownajJPG
{
    public class PorownajJpg
    {
        private Bitmap obraz1;
        private Bitmap obraz2;
        private Bitmap wynik;
        private int ktoryWzor;
        private bool czySieRoznia;
        private string sciezka1;
        private string sciezka2;
        private string sciezkaWynik;

        private bool czyPokazacDokladneRoznice;

        public PorownajJpg(string s1, string s2, string s3, int nr)
        {
            this.sciezka1 = s1;
            this.sciezka2 = s2;
            this.sciezkaWynik = s3 +"\\wynik_"+s1.Remove(0,s1.LastIndexOf("\\")+1);
            this.sciezkaWynik = this.sciezkaWynik.Remove(sciezkaWynik.LastIndexOf("."))+".jpg";
            this.ktoryWzor = nr;
            czyPokazacDokladneRoznice = false;
        }

        public void pokazRoznice(bool roznica)
        {
            czyPokazacDokladneRoznice = roznica;
        }

        public void start()
        {
            obraz1 = new Bitmap(sciezka1);
            obraz2 = new Bitmap(sciezka2);
            czySieRoznia = false;
            if (ktoryWzor == 1)
            {
                porowanj(obraz1,obraz2);
            }
            else if (ktoryWzor == 2)
            {
                porowanj(obraz2, obraz1);
            }

            obraz1.Dispose();
            obraz2.Dispose();
        }

        private void porowanj(Bitmap ob1, Bitmap ob2)
        {
            try
            {
                File.Delete(sciezkaWynik);
            }
            catch
            {
            }
            Bitmap pom = new Bitmap(ob1.Width + 100, 1);
            wynik = MergeTwoImages(ob1, pom);
            pom.Dispose();
            for (int i = ob1.Width-1; i < wynik.Width; i++)
            {
                for (int j = 0; j < wynik.Height; j++)
                {
                    wynik.SetPixel(i, j, Color.White);
                }
            }
            if(czyPokazacDokladneRoznice)
            {
                dokladneRoznice(ob1, ob2, wynik);
            }
            else
            {
                roznice(ob1, ob2, wynik);
            }

            if (czySieRoznia==true)
                wynik.Save(sciezkaWynik);
            wynik.Dispose();
        }

        private void roznice(Bitmap ob1, Bitmap ob2, Bitmap wynik)
        {
            int liczbaStron = 1;
            bool roznaLiczbaStron = false;
            for (int i = 0; i < ob1.Height; i++)
            {
                for (int j = 90; j < ob1.Width - 90; j++)
                {
                    try
                    {
                        var pixel1 = ob1.GetPixel(j, i);
                        var pixel2 = ob2.GetPixel(j, i);
                        if (i >= (1123 * liczbaStron) - 50 && i <= 1123 * liczbaStron)
                        {
                            //wynik.SetPixel(j, i, Color.Green);
                            if (i == 1123 * liczbaStron)
                                liczbaStron++;
                        }
                        else
                        {
                            if (pixel1 != pixel2 && wynik.GetPixel(ob1.Width + 1, i).Name.ToString() != "ffff0000")
                            {
                                wynik.SetPixel(ob1.Width + 1, i, Color.Red);
                                wynik.SetPixel(ob1.Width + 2, i, Color.Red);
                                wynik.SetPixel(ob1.Width + 3, i, Color.Red);
                                wynik.SetPixel(ob1.Width + 4, i, Color.Red);
                                wynik.SetPixel(ob1.Width + 5, i, Color.Red);
                                czySieRoznia = true;
                                break;
                            }
                        }
                    }
                    catch
                    {
                        if (roznaLiczbaStron == false)
                        {
                            for (int z = i; z < ob1.Height; z++)
                            {
                                wynik.SetPixel(ob1.Width + 1, z, Color.Red);
                            }
                            roznaLiczbaStron = true;
                        }
                        break;
                    }
                }
            }
        }

        private void dokladneRoznice(Bitmap ob1, Bitmap ob2, Bitmap wynik)
        {
            int liczbaStron = 1;
            bool roznaLiczbaStron = false;
            for (int i = 0; i < ob1.Width - 0; i++)
            {
                liczbaStron = 1;
                for (int j = 0; j < ob1.Height; j++)
                {
                    try
                    {
                        var pixel1 = ob1.GetPixel(i, j);
                        var pixel2 = ob2.GetPixel(i, j);

                        if (j >= (1123 * liczbaStron) - 50 && j <= 1123 * liczbaStron)
                        {
                            if (j == 1123 * liczbaStron)
                                liczbaStron++;
                        }
                        else
                        {                                
                            if (pixel1 != pixel2)
                            {
                                wynik.SetPixel(i, j, Color.DarkRed);
                                czySieRoznia = true;
                            }
                        }
                    }
                    catch
                    {
                        if (roznaLiczbaStron == false)
                        {
                            for (int z = j; z < ob1.Height; z++)
                            {
                                wynik.SetPixel(ob1.Width + 1, z, Color.Red);
                            }
                            roznaLiczbaStron = true;
                        }
                        break;
                    }
                }
            }
        }

        private Bitmap MergeTwoImages(Image firstImage, Image secondImage)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }

            if (secondImage == null)
            {
                throw new ArgumentNullException("secondImage");
            }

            int outputImageWidth = firstImage.Width > secondImage.Width ? firstImage.Width : secondImage.Width;

            int outputImageHeight = firstImage.Height + secondImage.Height + 1;

            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
                    new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(secondImage, new Rectangle(new Point(0, firstImage.Height + 1), secondImage.Size),
                    new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
            }

            return outputImage;
        }

    }
}
