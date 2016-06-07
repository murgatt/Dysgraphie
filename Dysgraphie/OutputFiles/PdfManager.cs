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

/* TUTORIEL ICI
 * http://dotnet.developpez.com/articles/itextsharp/
 */ 
namespace Dysgraphie.OutputFiles
{
    class PdfManager
    {
        private Document MyPdf;
        private string savePath;
        private string name;
        
        public  PdfManager(string name, string saveP)
        {
            this.savePath = saveP;
            this.name = name;
        }

        public void Create(Child child, Diagnostic d, string comment = null)
        {
            FileStream fs;
            if (savePath == "")
            {
                fs = new FileStream(name, FileMode.Create, FileAccess.Write, FileShare.None);
            } else
            {
                fs = new FileStream(savePath + "\\" + name, FileMode.Create, FileAccess.Write, FileShare.None);
            }
           
            Rectangle rec = new Rectangle(PageSize.A4);
            MyPdf = new Document(rec);
            PdfWriter writer = PdfWriter.GetInstance(MyPdf, fs);
            MyPdf.Open();

            //titre
            Chunk c = new Chunk("Diagnostic", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD));
            Paragraph p = new Paragraph(c);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 12;
            MyPdf.Add(p);
            AddDataChild(child);
            addDiagnostic(d);
            if(comment != null && comment !="")
            {
                AddComment(comment);
            }
            
        }

        public void addDiagnostic(Diagnostic d)
        {
            //diagnostic par lettres
            Paragraph p = new Paragraph();
            Chunk c;
            c = new Chunk("Diagnostic par lettres", FontFactory.GetFont(FontFactory.COURIER, 14, Font.BOLD));
            p.Add(c);
            PdfPTable tab = new PdfPTable(2);

            Dictionary<string, int> indicators = d.resultsPerIndicator();

            Dictionary<char, int> letters = d.resultsPerLetter();

            foreach (KeyValuePair<char, int> keyValLetter in letters)
            {
                tab.AddCell(Convert.ToString(keyValLetter.Key));
                tab.AddCell(keyValLetter.Value.ToString() + "/11");
            }
            p.Add(tab);
            p.SpacingAfter = 12;
            MyPdf.Add(p);

            //diagnostic par critères
            p = new Paragraph();
            c = new Chunk("Diagnostic par critères", FontFactory.GetFont(FontFactory.COURIER, 14, Font.BOLD));
            p.Add(c);
            tab = new PdfPTable(2);

            foreach (KeyValuePair<string, int> keyValInd in indicators)
            {
                tab.AddCell(keyValInd.Key);
                tab.AddCell(keyValInd.Value.ToString() + "/36");
            }
            
            p.Add(tab);
            p.SpacingAfter = 12;
            MyPdf.Add(p);
        }

        public void AddDataChild(Child c)
        {
            Paragraph p = new Paragraph();
            Chunk chunk;

            chunk = new Chunk("Prénom : " + c.GetPrenom() + "\n", FontFactory.GetFont(FontFactory.COURIER, 10));
            p.Add(chunk);
            chunk = new Chunk("Nom : " + c.GetNom() + "\n", FontFactory.GetFont(FontFactory.COURIER, 10));
            p.Add(chunk);
            chunk = new Chunk("Age : " + c.GetAge() + "\n", FontFactory.GetFont(FontFactory.COURIER, 10));
            p.Add(chunk);
            chunk = new Chunk("Classe : " + c.GetClasse() + "\n", FontFactory.GetFont(FontFactory.COURIER, 10));
            p.Add(chunk);
            chunk = new Chunk("Genre : " + c.GetGenre() + "\n", FontFactory.GetFont(FontFactory.COURIER, 10));
            p.Add(chunk);
            chunk = new Chunk("Lateralité : " + c.GetLateralite() + "\n", FontFactory.GetFont(FontFactory.COURIER, 10));
            p.Add(chunk);

            p.SpacingAfter = 12;
            MyPdf.Add(p);

        }
        public void AddComment(string t)
        {
            Paragraph p = new Paragraph();
            Chunk c = new Chunk("Commentaires \n", FontFactory.GetFont(FontFactory.COURIER, 14, Font.BOLD));
            p.Add(c);
            String com = t;
            c = new Chunk(com, FontFactory.GetFont(FontFactory.COURIER, 10));
            p.Add(c);
            p.SpacingAfter = 12;
            MyPdf.Add(p);

        }
        

        
        public void ClosePdf()
        {
            this.MyPdf.Close();            
        }
    }
    
}
