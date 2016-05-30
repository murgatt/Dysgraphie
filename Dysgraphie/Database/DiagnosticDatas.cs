using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Database
{
    class DiagnosticDatas
    {
        public double mean { get; set; }
        public double standardDeviation { get; set; }
        public double testValue { get; set; }
        public bool OK { get; set; }

        public String toString()
        {
            return "Validé : " + this.OK + ", Moyenne : " + mean + ", Ecart-type : " + standardDeviation + ", Valeur : " + testValue;
        }
    }

  
}
