using Dysgraphie.Datas;
using Dysgraphie.Indicators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Utils
{
    class OpenSaveTrace
    {
        
        public static Analysis openTrace(String url)
        {
            Analysis a = new Analysis();
            try
            {
                
                string[] lines = System.IO.File.ReadAllLines(url);
                foreach (string line in lines)
                {
                    String[] datas = line.Split('\t');

                    int val;
                    if (Int32.TryParse(datas[0], out val))
                    {
                        
                        Datas.Point p = new Datas.Point(Int32.Parse(datas[0]), UInt32.Parse(datas[1]), Double.Parse(datas[2]), Int32.Parse(datas[3]), Int32.Parse(datas[4]), Int32.Parse(datas[5]), UInt32.Parse(datas[6]), Int32.Parse(datas[7]), Int32.Parse(datas[8]), Int32.Parse(datas[9]));
                        a.addPoint(p);
                        
                        
                    }
                    
                }
                a.analyse();
                
                return a;
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichier introuvable");
            }
            return null;
        }

        public static void saveTrace(Analysis a, String url)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(url, false))
            {
                String str = "N°Pt\tSN\tT\tX\tY\tZ\tP\tAlt\tAzi\tTwi";
                file.WriteLine(str);
                foreach (Point p in a.points)
                {
                    str = p.id + "\t" + p.sn + "\t" + p.t + "\t" + p.x + "\t" + p.y + "\t" + p.z + "\t" + p.p + "\t" + p.alt + "\t" + p.azi + "\t" + p.twi;
                    file.WriteLine(str);
                }
            }
            
        }

        public static void saveSequence(List<Analysis> analisysList, String url)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(url, false))
            {
                String str = "N°Pt\tSN\tT\tX\tY\tZ\tP\tAlt\tAzi\tTwi";
                file.WriteLine(str);
                foreach (Analysis a in analisysList)
                {
                    str = "///// Lettre : " + a.character + " /////";
                    file.WriteLine(str);
                    foreach (Point p in a.points)
                    {
                        str = p.id + "\t" + p.sn + "\t" + p.t + "\t" + p.x + "\t" + p.y + "\t" + p.z + "\t" + p.p + "\t" + p.alt + "\t" + p.azi + "\t" + p.twi;
                        file.WriteLine(str);
                    }
                }
            }
                
        }

    }
}

