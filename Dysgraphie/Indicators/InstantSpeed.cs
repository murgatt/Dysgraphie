using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    class InstantSpeed : AbstractIndicator
    {
        public InstantSpeed(List<Point> points, Analysis analysis) : base(points, analysis)
        {}

        public override void calcul()
        {
            Point pm1, pp1, p;
            double d, t;

            List<Double> res = new List<Double>();
            for(int i = 0;i<this.points.Count-1; ++i)
            {
                
                
                p = this.points.ElementAt(i);

                if(i != 0)
                {
                    pm1 = this.points.ElementAt(i - 1);
                   
                } else
                {
                    pm1 = p;
                }
                if (i != this.points.Count - 1)
                {
                    pp1 = this.points.ElementAt(i + 1);
                }
                else {
                    pp1 = p;
                }


                if (i == 0 || i == this.points.Count-1 || pm1.id != p.id-1 || p.id != pp1.id-1)
                {
                    res.Add(0);
                } else {
                    
                    
                    d = Math.Sqrt(Math.Pow(pm1.x, 2) + Math.Pow(p.x, 2)) + Math.Sqrt(Math.Pow(pp1.x, 2) + Math.Pow(p.x, 2));
                    t = pp1.t - pm1.t;
                    res.Add(d / t);
                }
            }
            this.analysis.instantSpeed = res;

        }
    }
}
