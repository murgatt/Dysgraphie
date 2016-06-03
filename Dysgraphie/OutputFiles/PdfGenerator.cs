using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Dysgraphie.Database;
using Dysgraphie.Indicators;

/* TUTORIEL ICI
 * http://dotnet.developpez.com/articles/itextsharp/
 */ 
namespace Dysgraphie.OutputFiles
{
    class PdfManager
    {
        Document MyPdf;
        string savePath;
        string name;
        PdfWriter writer;
        PdfContentByte canvas;
        
       public  PdfManager(string name, string saveP)
        {
            this.MyPdf = new Document(); // Genere un document de taille A4
            this.savePath = saveP;
            this.name = name;
         }
        public void Create()
        {
           
            try
            {
                this.writer = PdfWriter.GetInstance(MyPdf, new FileStream(this.savePath + this.name + ".pdf", FileMode.Create));
                
                this.MyPdf.Open();
                this.canvas = this.writer.DirectContent;
                this.canvas.BeginText();
                    BaseFont bf = BaseFont.CreateFont("C:\\WINDOWS\\FONTS\\ARIAL.TTF", BaseFont.CP1252, true);
                    //on instancie une police Arial avec BaseFont 
                    this.canvas.SetFontAndSize(bf, 30f);
                    this.canvas.SetTextMatrix(170, 800); //on applique une matrice simple  définissant les coordonnées du texte 
                    this.canvas.ShowText("Resumé du patient");
                canvas.EndText();

            }
            catch (DocumentException de)
            {
                Console.WriteLine("error " + de);
            }
            catch (System.IO.IOException ioe)
            {
                Console.WriteLine("error " + ioe);
            }
        }
        public void AddDataChild(Child c)
        {
            PdfPTable tableau = new PdfPTable(2);
            
            tableau.AddCell("Nom : " + c.GetNom());
            tableau.AddCell("Prénom : " + c.GetPrenom());
            tableau.AddCell("Age : " + c.GetAge());
            tableau.AddCell("Classe : " + c.GetClasse());
            tableau.AddCell("Genre : " + c.GetGenre());
            tableau.AddCell("Lateralité : " + c.GetLateralite());
           
            tableau.TotalWidth = 500; //  est la largeur du tableau(en points typo)
            tableau.LockedWidth = true; // sert à empêcher la méthode document.add de redimensionner le tableau.*
            try
            {
                tableau.WriteSelectedRows(0, -1, 50, 750, this.canvas);
                
                
            }
            catch (DocumentException de)
            {
                 Console.WriteLine("error " + de);
            }
            catch (System.IO.IOException ioe)
            {
                Console.WriteLine("error " + ioe);
            }

        }
        public void AddFirstComment(string t)
        {
            PdfPTable tableau = new PdfPTable(1);

          
            Paragraph monParaph = new Paragraph();
            monParaph.Add(new Phrase(t));
            monParaph.Leading = 15f;// (où xx est une valeur et f définit la valeur comme étant un float) 
            monParaph.IndentationLeft = 30f;
            monParaph.IndentationRight = 30f;
            monParaph.Alignment = Element.ALIGN_JUSTIFIED;
            tableau.DefaultCell.Border = Rectangle.NO_BORDER;
            tableau.TotalWidth = 450; //  est la largeur du tableau(en points typo)
            tableau.LockedWidth = true; // sert à empêcher la méthode document.add de redimensionner le tableau.*
            tableau.AddCell(new Phrase("Premier commentaire"));
            tableau.AddCell(monParaph);
            tableau.WriteSelectedRows(0, -1, 80, 670, this.canvas);

        }
        public void AddImage(Image i)
        {
            try
            {
               // this.canvas.add(Image);
            }
            catch (DocumentException de)
            {
                Console.WriteLine("error " + de);
            }
            catch (System.IO.IOException ioe)
            {
                Console.WriteLine("error " + ioe);
            }
        }

        public void AddText(string text) 
        {
            try
            {
                this.MyPdf.Add(new Phrase(text));
            }
            catch (DocumentException de)
            {
                Console.WriteLine("error " + de);
            }
            catch (System.IO.IOException ioe)
            {
                Console.WriteLine("error " + ioe);
            }

        }

        public void addChartCritere(List<Analysis> listAn)
        {
            foreach( Analysis simpleAnalyse in listAn)
            {

            }
        }

        public void ClosePdf()
        {
            this.MyPdf.Close();
            this.writer.Close();
            
        }
    }
    
}
