using Dysgraphie.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Database
{
    //Classe permettant le diagnostic global d'une personne
    class Diagnostic
    {
        private DbManager manager;
        private List<Analysis> analysisList;
        private string grade;
        private readonly string[] indicators = {"averageSpeed", "drawTime", "breakTime", "drawLength", "lettersHeight", "lettersWidth", "printNumber", "averagePression", "averageAltitude", "averageAzimuth", "averageTwist"};
        
        private Child patient;

        public Diagnostic(DbManager manager, Child patient, List<Analysis> analysisList, String grade)
        {
            this.patient = patient;
            this.manager = manager;
            this.analysisList = analysisList;
            this.grade = grade;
        }

        //Renvoie la somme des résultats pour chacun des critères
        public Dictionary<string, int> resultsPerIndicator()
        {
            Dictionary<char, Dictionary<string, bool>> results = this.calcul();
            Dictionary<string, int> res = new Dictionary<string, int>();
            

            foreach (KeyValuePair<char, Dictionary<string, bool>> keyValPerChar in results)
            {
                foreach (KeyValuePair<string, bool> keyValPerIndicator in keyValPerChar.Value)
                {
                    if (keyValPerIndicator.Value)
                    {
                        if (res.ContainsKey(keyValPerIndicator.Key)) res[keyValPerIndicator.Key]++;
                        else res.Add(keyValPerIndicator.Key, 1);
                    } else
                    {
                        if (!res.ContainsKey(keyValPerIndicator.Key)) res.Add(keyValPerIndicator.Key, 0);
                    }
                }
            }
            return res;
        }

        //Renvoie la somme des résultats pour chacune des lettres
        public Dictionary<char, int> resultsPerLetter()
        {
            Dictionary<char, Dictionary<string, bool>> results = this.calcul();
            Dictionary<char, int> res = new Dictionary<char, int>();
            int sum = 0;

            foreach (KeyValuePair<char, Dictionary<string, bool>> keyValPerChar in results)
            {
                foreach (KeyValuePair<string, bool> keyValPerIndicator in keyValPerChar.Value)
                {
                    if (keyValPerIndicator.Value) ++sum;                    
                }
                res.Add(keyValPerChar.Key, sum);
                sum = 0;
            }
            return res;
        }

        //ajoute une analyse à la liste
        public void addAnalysis(Analysis a) 
        {
            this.analysisList.Add(a);
        }

        //Calcul le tableau de critères validés pour chacune des lettres
        public Dictionary<char, Dictionary<string, bool>> calcul()
        {
            Dictionary<char, Dictionary<string, bool>> res = new Dictionary<char, Dictionary<string, bool>>();
            
            foreach(Analysis a in analysisList)
            {
                res.Add(a.character, this.addDiagnosticLetter(a));
            }

            return res;
        }

        //Ajoute le diagnostic pour une lettre
        private Dictionary<string, bool> addDiagnosticLetter(Analysis a)
        {
            DiagnosticLetter dl = new DiagnosticLetter(this.manager, a, a.character, this.patient, this.grade);
            DiagnosticDatas dd;
            Dictionary<string, bool> res = new Dictionary<string, bool>();
            foreach(string s in this.indicators)
            {
                Type myType = typeof(DiagnosticLetter);
                PropertyInfo myPropInfo = myType.GetProperty(s);
                dd = (DiagnosticDatas)myPropInfo.GetValue(dl, null);
                res.Add(s, dd.OK);
            }

            return res;


        }
    }
}
