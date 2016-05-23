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
            Point pm1, pp1, p, pp2, pm2;
            double d, t;

            List<Double> res = new List<Double>();
            for(int i = 0;i<this.points.Count-1; ++i)
            {

                if (i == 1 || i == this.points.Count - 2 || i == 0 || i == this.points.Count - 1 )
                {
                    res.Add(0);
                } else
                {
                    p = this.points.ElementAt(i);
                    pm1 = this.points.ElementAt(i - 1);
                    pm2 = this.points.ElementAt(i - 2);
                    pp2 = this.points.ElementAt(i + 2);
                    pp1 = this.points.ElementAt(i + 1);
                    if (p.id == pm1.id + 1 && p.id == pp1.id - 1 && p.id == pm2.id+2 && p.id == pp2.id - 2)
                    {
                        t = pp2.t - pm2.t;
                      
                        d = calculDistance(pm2, pm1) + calculDistance(pm1, p) + calculDistance(p, pp1) + calculDistance(pp1, pp2);

                        //convertion en cm/s
                        d = d / 2000;
                        t = t / 1000;
                        double v = d / t;
                        res.Add(v);
                       
                    }
                    else {
                        res.Add(0);
                        

                    }
                }
                
            }
            this.analysis.instantSpeed = res;

        }

        private double calculDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.y - b.y, 2) + Math.Pow(a.x - b.x, 2));
        }
    }

    
}
