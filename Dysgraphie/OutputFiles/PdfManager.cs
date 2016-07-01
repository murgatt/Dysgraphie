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
    //outils permettant d'éditer un pdf
    class PdfManager
    {
        private Document MyPdf;
        private string savePath;
        private string name;
        private List<String> indicators;
        private string[] criteres = {"Vitesse moyenne", "Temps d'écriture", "Temps de pause", "Longueur de la trace", "Hauteur de lettre", "Largeur de lettre", "Nombre de blocs", "Pression moyenne", "Altitude  moyenne", "Azimuth  moyen", "Twist moyen"};

        public  PdfManager(string name, string saveP)
        {
            string[] indi = { "averageSpeed", "drawTime", "breakTime", "drawLength", "lettersHeight", "lettersWidth", "printNumber", "averagePression", "averageAltitude", "averageAzimuth", "averageTwist" };
            indicators = new List<string>(indi);
            this.savePath = saveP;
            this.name = name;
        }

        public void Create(Child child, Diagnostic d, string grade, string comment = null)
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
            Chunk c = new Chunk("Diagnostic\n", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD));
            Paragraph p = new Paragraph(c);
            c = new Chunk("Ce diagnotic a été réalisé en comparaison d'écritures d'enfants de classe de "+grade, FontFactory.GetFont(FontFactory.COURIER, 10));
            p.Add(c);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 12;
            MyPdf.Add(p);
            //ajout des données concernant l'enfant
            AddDataChild(child);

            //ajout du reste du diagnostic
            addDiagnostic(d);

            //ajout du commentaire s'il est non vide
            if(comment != null && comment !="")
            {
                AddComment(comment);
            }
            
        }

        public void addDiagnostic(Diagnostic d)
        {
            //Score total
            Paragraph p = new Paragraph();
            Chunk c;
            Dictionary<string, int> indicators = d.resultsPerIndicator();

            Dictionary<char, int> letters = d.resultsPerLetter();

            c = new Chunk("Score total \n", FontFactory.GetFont(FontFactory.COURIER, 14, Font.BOLD));
            p.Add(c);
            c = new Chunk("Nombre total de critères non validés sur l'ensemble des lettres : ", FontFactory.GetFont(FontFactory.COURIER, 10));
            p.Add(c);
            c = new Chunk(d.totalScore().ToString() + "/" + (indicators.Count * letters.Count).ToString(), FontFactory.GetFont(FontFactory.COURIER, 12, Font.BOLD));
            p.Add(c);
            p.SpacingAfter = 12;
            MyPdf.Add(p);
            MyPdf.NewPage();

            //titre annexe
            c = new Chunk("Resultats Annexes\n", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD));
            p = new Paragraph(c);                       
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 12;
            MyPdf.Add(p);

            //diagnostic par lettres
            p = new Paragraph();
            c = new Chunk("Diagnostic par lettres", FontFactory.GetFont(FontFactory.COURIER, 14, Font.BOLD));
            p.Add(c);
            PdfPTable tab = new PdfPTable(2);

            

            foreach (KeyValuePair<char, int> keyValLetter in letters)
            {
                tab.AddCell(Convert.ToString(keyValLetter.Key));
                tab.AddCell(keyValLetter.Value.ToString() + "/"+indicators.Count);
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
                tab.AddCell(this.criteres.ElementAt(this.indicators.IndexOf(keyValInd.Key)));
                tab.AddCell(keyValInd.Value.ToString() + "/"+letters.Count);
            }
            
            p.Add(tab);
            p.SpacingAfter = 12;
            MyPdf.Add(p);

            

            //moyennes par critères pour les lettres
            p = new Paragraph();
            c = new Chunk("Moyennes par critères pour les lettres", FontFactory.GetFont(FontFactory.COURIER, 14, Font.BOLD));
            p.Add(c);

            Dictionary<string, double> meanIndicator = d.Lettersmean();
            tab = new PdfPTable(2);
            
            
            foreach (KeyValuePair<string, double> keyValInd in meanIndicator)
            {
                tab.AddCell(this.criteres.ElementAt(this.indicators.IndexOf(keyValInd.Key)));
                tab.AddCell(keyValInd.Value.ToString("F"));
            }
            
            p.Add(tab);
            p.SpacingAfter = 12;
            MyPdf.Add(p);

            //moyennes par critères pour les chiffres
            p = new Paragraph();
            c = new Chunk("Moyennes par critères pour les chiffres", FontFactory.GetFont(FontFactory.COURIER, 14, Font.BOLD));
            p.Add(c);

            meanIndicator = d.Numbersmean();
            tab = new PdfPTable(2);


            foreach (KeyValuePair<string, double> keyValInd in meanIndicator)
            {
                tab.AddCell(this.criteres.ElementAt(this.indicators.IndexOf(keyValInd.Key)));
                tab.AddCell(keyValInd.Value.ToString("F"));
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

        //ajout du commentaire
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
        

        //fermeture du PDF
        public void ClosePdf()
        {
            this.MyPdf.Close();            
        }
    }
    
}
