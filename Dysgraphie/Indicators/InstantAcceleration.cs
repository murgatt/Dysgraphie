﻿using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    //Calcul des accélérations instantannées en cm/s²
    class InstantAcceleration : AbstractIndicator
    {
        public InstantAcceleration(List<Point> points, Analysis analysis) : base(points, analysis)
        { }

        public override void calcul()
        {
            Point pm1, pp1, p, pp2, pm2;
            double d, t;

            List<Double> res = new List<Double>();
            for (int i = 0; i < this.points.Count - 1; ++i)
            {

                if (i == 1 || i == this.points.Count - 2 || i == 0 || i == this.points.Count - 1)
                {
                    res.Add(0); //Si le point est en bout ou en fin de tracé on lui attribut une accélération de 0
                }
                else
                {
                    p = this.points.ElementAt(i);
                    pm1 = this.points.ElementAt(i - 1);
                    pm2 = this.points.ElementAt(i - 2);
                    pp2 = this.points.ElementAt(i + 2);
                    pp1 = this.points.ElementAt(i + 1);
                    if (p.id == pm1.id + 1 && p.id == pp1.id - 1 && p.id == pm2.id + 2 && p.id == pp2.id - 2)
                    {
                        t = pp2.t - pm2.t;
                        
                        d = calculDistance(pm2, pm1) + calculDistance(pm1, p) + calculDistance(p, pp1) + calculDistance(pp1, pp2);
                        
                        //convertion en cm/s^2
                        d = d / 2000;
                        t = t / 1000;

                        double v = d / Math.Pow(t,2);
                        res.Add(v);
                        
                    }
                    else {
                        res.Add(0);


                    }
                }

            }
            this.analysis.instantAcceleration = res;

        }

        private double calculDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.y - b.y, 2) + Math.Pow(a.x - b.x, 2));
        }
    }

}
