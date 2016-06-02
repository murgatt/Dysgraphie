using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dysgraphie.Drawing;
using Dysgraphie.Indicators;

namespace Dysgraphie.OutputFiles
{
    class Letter
    {
        public List<DrawingPoint> listPoint;
        string nameLetter;
        public Analysis criteres;
        public Letter(List<DrawingPoint> l, string name, Analysis c)
        {
            this.listPoint = l;
            this.nameLetter = name;
            this.criteres = c;
        }
    }
}
