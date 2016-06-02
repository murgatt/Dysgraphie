using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dysgraphie.Drawing;
using Dysgraphie.Indicators;

namespace Dysgraphie.OutputFiles
{
    abstract class FilesLetterGenerator
    {
      
        public void  GenerateFile(string path, List<List<DrawingPoint>> listData, List<Analysis> ListCritere, List<string> ListLetter)
        {
            
            TextWriter tw;
            int token = 0;

            tw = new StreamWriter(path+"\\DataLetters.txt", true);
            foreach (List<DrawingPoint> letter in listData)
            {
                tw.WriteLine("nameletter" + ListLetter[token] + "nameletter\n");
                string txt = "";
                foreach(DrawingPoint dt in letter)
                {
                    txt += dt.X + "," + dt.Y + "," + dt.pression + "|";
                }
                this.AddLetter(txt, ListLetter[token], tw);

                 /* ordre des criteres 
                 * AVG Alt
                 * AVG Az
                 * AVG Pr
                 * AVG Sp
                 * AVG DL
                 * AVG DT
                 * H
                 * W
                 *  */
                string crit = "";
                crit += "," + ListCritere[token].averageAltitude+"|";
                crit += "," + ListCritere[token].averageAzimuth + "|";
                crit += "," + ListCritere[token].averagePression + "|";
                crit += "," + ListCritere[token].averageSpeed + "|";
                crit += "," + ListCritere[token].drawLength + "|";
                crit += "," + ListCritere[token].drawTime + "|";
                crit += "," + ListCritere[token].lettersHeight +"|" ;
                crit += "," + ListCritere[token].lettersWidth ;
                AddCriteres(crit, ListLetter[token] , tw);
                token++;
            }
        }

        private void AddLetter(string txt , string letterName, TextWriter tw)
        {
            tw.WriteLine("coord"+txt+"coord\n");
        }
        private void AddCriteres(string txt, string letterName , TextWriter tw)
        {
            tw.WriteLine("criteres"+txt+"criteres\n");
        }
        public List<Letter> GetLetters(string nameFile)
        {
            List<Letter> list = new List<Letter>();
            StreamReader reader = File.OpenText(nameFile);
            string[] stringSeparators = new string[] {"Start letter"};
            string text = reader.ReadToEnd();
            string[] items = text.Split(stringSeparators, StringSplitOptions.None);
            foreach(string letter in items)
            {
                
                string[] sep1 = new string[] { "nameletter" };
                string[] nameletter = letter.Split(sep1, StringSplitOptions.None);
                
                

                string[] sep2 = new string[] { "coord" };
                string coordletter = letter.Split(sep2, StringSplitOptions.None)[1];
                string[] listCoord = coordletter.Split('|');

                List<DrawingPoint>listDP = new List<DrawingPoint>();
                foreach(string point in listCoord)
                {
                    
                    string[] d = point.Split(',');
                    DrawingPoint dp = new DrawingPoint(Int32.Parse( d[0]),Int32.Parse( d[1]), uint.Parse( d[2]),0);
                    listDP.Add(dp);
                }
                string[] sep3 = new string[] { "criteres" };
                string[] critereletter = letter.Split(sep3, StringSplitOptions.None);
                Analysis a = new Analysis();
                foreach (string point in listCoord)
                {
                    /* ordre des criteres 
                    * AVG Alt
                    * AVG Az
                    * AVG Pr
                    * AVG Sp
                    * DL
                    * DT
                    * H
                    * W
                    *  */
                    string[] d = point.Split(',');
                    
                    a.averageAltitude = point[0];
                    a.averageAzimuth = point[1];
                    a.averagePression = point[2];
                    a.averageSpeed = point[3];
                    a.drawLength = point[4];
                    a.drawTime = point[5];
                    a.lettersHeight = point[6];
                    a.lettersWidth = point[7];
                }
                Letter l = new Letter(listDP,nameletter[1],a);
                list.Add(l);
            }
          

            return list;
        }
       
    }
}
