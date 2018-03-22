using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using KonwertujPlikiDoJPG;
using System.Windows.Forms;

namespace ZalogujIPobierz
{
    public class zalogujIPobierz
    {
        private string sciezka;
        private string Login;
        private string Haslo;
        private string Strona;
        private DateTime data = DateTime.Now;
        private IWebDriver driver = null;
        public bool czyZalogowany = false;
        public zalogujIPobierz(string login, string haslo, string strona)
        {
            this.Login = login;
            this.Haslo = haslo;
            this.Strona = strona;
            this.sciezka = @"C:\Users\VOLTPC3\Desktop\Raporty\" + DateTime.Now.ToString().Replace(":", ".") + "\\";
            
        }
        public void start()
        {
            stworzFolder(sciezka);
            driver = new ChromeDriver();
            zaloguj(Login, Haslo, Strona);

        }

        public void stop()
        {
            System.Threading.Thread.Sleep(3000);
            driver.Quit();
            czyZalogowany = false;
        }

        public void pobierzRaportyZLinku( string link)
        {
            driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(3000);
            data = DateTime.Now;
            dzialaniaNaPobranymPliku();
        }

        //private void pobierzRaporty(string[] tablicaXPathIkonaPliku, string[] tablicaXPathGeneruj, string[] tablicaXPathAnuluj)
        //{
        //    for (int i = 0; i < tablicaXPathIkonaPliku.Count(); i++)
        //    {
        //        kliknijWElement("XPATH", tablicaXPathIkonaPliku[i]); //klikniecie w Ikone pliku
        //        System.Threading.Thread.Sleep(5000);
        //        kliknijWElement("XPATH", tablicaXPathGeneruj[i]); //klikniecie w Generuj
        //        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        //        data = DateTime.Now;
        //        System.Threading.Thread.Sleep(5000);
        //        kliknijWElement("XPATH", tablicaXPathAnuluj[i]); //klikniecie w Anuluj
        //        dzialaniaNaPobranymPliku();
        //    }
        //}

        private void zaloguj( string login, string haslo, string strona)
        {
            try
            {
                driver.Navigate().GoToUrl(strona);

                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.Id("login_input")).SendKeys(login);
                driver.FindElement(By.Id("password_input")).SendKeys(haslo + OpenQA.Selenium.Keys.Enter);

                czyZalogowany = true;

                kliknijWElement("ID", "ext-comp-1049"); //klikniecie w raporty
            }
            catch (Exception)
            {
                stop();
                MessageBox.Show("Błąd przy logowaniu");
            }
            
        }

        private void kliknijWElement(string rodzaj, string tekst)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement el = null;
                switch (rodzaj.ToUpper())
                {
                    case "ID":
                        el = driver.FindElement(By.Id(tekst));
                        break;
                    case "XPATH":
                        el = driver.FindElement(By.XPath(tekst));
                        break;
                }
                el.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void stworzFolder(string sciezka)
        {
            if (File.Exists(sciezka) != true)
                Directory.CreateDirectory(sciezka);
        }
        private void dzialaniaNaPobranymPliku()
        {
            string path = null;
            System.Threading.Thread.Sleep(5000);
            path = znajdz();
            if(path != null)
            {
                przenies(path);
                usun(path);
            }
        }

        private string znajdz()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\VOLTPC3\Downloads");
            foreach (var item in di.GetFiles())
            {
                 TimeSpan roznica = File.GetCreationTime(item.FullName) - data;
                if (item.Name.Contains("desktop") != true && roznica.TotalSeconds < 30 && roznica.TotalSeconds > -30)
                {
                    Console.WriteLine(item);
                    return item.FullName;
                }
            }
            return null;
        }
        private int i =1;
        private void przenies(string path)
        {
            int pom = 0;
            var a = path.Substring(path.LastIndexOf("\\") + 1);
            do
            {
                if(File.Exists(sciezka+a) == true)
                {
                    i++;
                    string rozrzeszenie = a.Remove(0, a.LastIndexOf("."));
                    a = a.Remove(a.LastIndexOf("."));
                    a = a + "(" + i + ")" + rozrzeszenie;
                }
                else
                {
                    pom = 1;
                }
            }
            while (pom == 0);
            File.Copy(path, sciezka + a);
            path = sciezka + a;
            a = path.Remove(path.LastIndexOf("\\")) + "\\jpg pliku_" + path.Remove(0, path.LastIndexOf("\\") + 1).Replace(".", "");
            KonwertujDoJPG konwertuj = new KonwertujDoJPG(path, a, path.Remove(0, path.LastIndexOf(".") + 1));
        }

        private void usun(string path)
        {
            File.Delete(path);
        }

        public void PrintScreen(string strona)
        {
            driver.Navigate().GoToUrl(strona);
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(3000);
            strona = driver.Url.Replace(":", "").Replace("/", "");
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save(sciezka+"printscreen_" + strona + ".jpg", ImageFormat.Jpeg);
        }
    }
}
