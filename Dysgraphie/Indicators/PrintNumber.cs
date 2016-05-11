using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    class PrintNumber : AbstractIndicator
    {

        public PrintNumber(List<Point> points, Analysis analysis) : base(points, analysis) { }


        public override void calcul()
        {
            if(this.points.Count == 0)
            {
                this.analysis.printNumber = 0;
            } else
            {
                Point pp1, p;
                int nb = 1;
                for (int i = 0; i < this.points.Count - 2; ++i)
                {
                    pp1 = this.points.ElementAt(i + 1);
                    p = this.points.ElementAt(i);
                    if (p.id + 1 != pp1.id)
                    {
                        nb++;
                    }
                }
                this.analysis.printNumber = nb;
            }

            
           
        }
    }
}
