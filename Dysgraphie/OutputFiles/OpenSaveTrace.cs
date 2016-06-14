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
    //outils permettant d'ouvrir et sauvegarder une trace ou une séquence
    class OpenSaveTrace
    {
        //ouverture d'une trace
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

        //sauvegarde d'une trace
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

        //sauvegarde d'une sequence
        public static void saveSequence(List<Analysis> analisysList, String url, String commentary)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(url, false))
            {
                file.WriteLine("Commentaires : "+commentary);
                file.WriteLine();
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

        //ouverture d'une séquence
        public static List<Analysis> openSequence(String url)
        {
            List<Analysis> res = new List<Analysis>();
            Analysis a = null;
            String[] datas;
            try
            {

                string[] lines = System.IO.File.ReadAllLines(url);
                foreach (string line in lines)
                {
                    datas = line.Split('\t');

                    int val;
                    if (Int32.TryParse(datas[0], out val))
                    {

                        Datas.Point p = new Datas.Point(Int32.Parse(datas[0]), UInt32.Parse(datas[1]), Double.Parse(datas[2]), Int32.Parse(datas[3]), Int32.Parse(datas[4]), Int32.Parse(datas[5]), UInt32.Parse(datas[6]), Int32.Parse(datas[7]), Int32.Parse(datas[8]), Int32.Parse(datas[9]));
                        a.addPoint(p);


                    } else {
                        
                        datas = line.Split(' ');


                        if (datas.Length == 5)
                        {                           
                            if(a != null)
                            {
                                a.analyse();
                                res.Add(a);
                            }
                            a = new Analysis();
                            a.character = Convert.ToChar(datas[3]);                            
                        }
                            
                    }

                }
                a.analyse();
                res.Add(a);

                return res;
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichier introuvable");
            }
            return null;
        }

        public static string getSequenceCommentary(String url)
        {
            String[] datas;
            try
            {

                string[] lines = System.IO.File.ReadAllLines(url);
                foreach (string line in lines)
                {

                    datas = line.Split(':');


                    if (datas[0] == "Commentaires ")
                    {
                        return datas[1];                            
                    }
                }
                

                return null;
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichier introuvable");
            }
            return null;
        }

    }
}

