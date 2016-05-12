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
                int i = 0;
                string[] lines = System.IO.File.ReadAllLines(@"Trace.txt");
                foreach (string line in lines)
                {
                    if(i !=0)
                    {
                        String[] datas = line.Split('\t');
                        
                        Datas.Point p = new Datas.Point(Int32.Parse(datas[0]), UInt32.Parse(datas[1]), Double.Parse(datas[2]), Int32.Parse(datas[3]), Int32.Parse(datas[4]), Int32.Parse(datas[5]), UInt32.Parse(datas[6]), Int32.Parse(datas[7]), Int32.Parse(datas[8]), Int32.Parse(datas[9]));
                        a.addPoint(p);
                    }
                    ++i;
                }
                a.analyse();
                i = 0;
                return a;
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichier introuvable");
            }
            return null;
        }

        public static void saveTrace(Analysis a)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Trace.txt", false))
            {
                String str = "N°Pt\tSN\tT\tX\tY\tZ\tP\tAlt\tAzi\tTwi";
                file.WriteLine(str);
                int i = 0;
                foreach (Point p in a.points)
                {
                    Console.WriteLine(i);
                    str = p.id + "\t" + p.sn + "\t" + p.t + "\t" + p.x + "\t" + p.y + "\t" + p.z + "\t" + p.p + "\t" + p.alt + "\t" + p.azi + "\t" + p.twi;
                    file.WriteLine(str);
                    ++i;
                }
            }
            
        }

    }
}

