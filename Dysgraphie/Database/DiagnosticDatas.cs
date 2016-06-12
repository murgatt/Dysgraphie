using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Database
{
    //Représente le diagnostic pour une lettre et un critère donnés
    class DiagnosticDatas
    {
        public double mean { get; set; }    //Moyenne de la BDD
        public double standardDeviation { get; set; }   //Ecart-type de la BDD
        public double testValue { get; set; }   //Valeur calculée sur le test
        public bool OK { get; set; }    //Vrai si le test est validé, sinon faux

        public String toString()
        {
            return "Validé : " + this.OK + ", Moyenne : " + mean + ", Ecart-type : " + standardDeviation + ", Valeur : " + testValue;
        }
    }

  
}
