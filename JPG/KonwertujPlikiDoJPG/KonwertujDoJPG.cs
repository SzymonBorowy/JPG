using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Syncfusion.DocIO;
//using Syncfusion.DocIO.DLS;


//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Parsing;
//using Syncfusion.Windows.Forms.PdfViewer;

using Syncfusion.XlsIO;


namespace KonwertujPlikiDoJPG
{
    public class KonwertujDoJPG
    {
        private string sciezkaDoPliku;
        private string sciezgaDoZapisaniaPliku;
        private string format;
        public KonwertujDoJPG(string sciezkaDoPliku, string sciezgaDoZapisaniaPliku, string format)
        {
            this.sciezkaDoPliku = sciezkaDoPliku;
            this.sciezgaDoZapisaniaPliku = sciezgaDoZapisaniaPliku;
            this.format = format;
            sprawdzFormat(this.format);
        }

        private void sprawdzFormat(string format)
        {
            format = format.ToUpper();
            switch(format)
            {
                case "PDF":
                    PDF();
                    break;
                case "XLS":
                    XLS();
                    break;
                case "XLSX":
                    XLS();
                    break;
                case "DOC":
                    DOCX();
                    break;
                case "DOCX":
                    DOCX();
                    break;
            }
        }

        private void PDF()
        {
            Spire.Pdf.PdfDocument document = new Spire.Pdf.PdfDocument();
            document.LoadFromFile(sciezkaDoPliku);
            Image wynik = document.SaveAsImage(0, Spire.Pdf.Graphics.PdfImageType.Metafile);
            for (int i = 1; i < document.Pages.Count; i++)
            {
                Image pom = document.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Metafile);
                wynik = MergeTwoImages(wynik, pom);
                pom.Dispose();
            }
            wynik.Save(sciezgaDoZapisaniaPliku + /*"_" + document.Pages.Count + */".jpg");
            wynik.Dispose();
            document.Dispose();
        }
        private void XLS()
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2010;
            IWorkbook workbook = application.Workbooks.Open(sciezkaDoPliku, ExcelOpenType.Automatic);
            IWorksheet sheet = workbook.Worksheets[0];
            sheet.UsedRangeIncludesFormatting = false;
            int lastRow = sheet.UsedRange.LastRow + 1;
            int lastColumn = sheet.UsedRange.LastColumn + 1;            
            Image image = sheet.ConvertToImage(1, 1, lastRow, lastColumn, Syncfusion.XlsIO.ImageType.Bitmap, null);
            image.Save(sciezgaDoZapisaniaPliku +".jpg");
            image.Dispose();
            excelEngine.Dispose();
        }

        private void DOCX()
        {
            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile(sciezkaDoPliku);
            Image wynik = document.SaveToImages(0,Spire.Doc.Documents.ImageType.Metafile);
            Image[] images = document.SaveToImages(Spire.Doc.Documents.ImageType.Metafile);
            int pom = 0;
            for (int i = 1; i < images.Count(); i++)
            {
                try
                {
                    if (i != 73)
                    {
                        wynik = MergeTwoImages(wynik, images[i]);
                        images[i].Dispose();
                    }
                    else 
                    {
                        wynik.Save(sciezgaDoZapisaniaPliku /*+"_"+ pom */+ ".jpg");
                        wynik.Dispose();
                        wynik = document.SaveToImages(i, Spire.Doc.Documents.ImageType.Metafile);
                        pom++;
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            wynik.Save(sciezgaDoZapisaniaPliku +"_"+ document.Count + ".jpg");
            wynik.Dispose();
            document.Dispose();
            
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
                graphics.DrawImage(firstImage, new System.Drawing.Rectangle(new System.Drawing.Point(), firstImage.Size), new System.Drawing.Rectangle(new System.Drawing.Point(), firstImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(secondImage, new System.Drawing.Rectangle(new System.Drawing.Point(0, firstImage.Height + 1), secondImage.Size), new System.Drawing.Rectangle(new System.Drawing.Point(), secondImage.Size), GraphicsUnit.Pixel);
            }
            firstImage.Dispose();
            secondImage.Dispose();
            return outputImage;
        }
    }
}

