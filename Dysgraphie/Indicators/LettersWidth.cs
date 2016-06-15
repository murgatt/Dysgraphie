using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    //Hauteur du caractère en cm
    class LettersWidth : AbstractIndicator
    {
        
        public LettersWidth(List<Point> points, Analysis analysis) : base(points, analysis) { }


        public override void calcul()
        {
            Point max, min, p;
            
            if(points.Count > 0)
            {
                max = points.ElementAt(0);
                min = points.ElementAt(0);
                for(int i = 0;i<points.Count; ++i)
                {
                    p = points.ElementAt(i);
                    if(max.x < p.x)
                    {
                        max = p;
                    }
                    if (min.x > p.x)
                    {
                        min = p;
                    }
                }
                this.analysis.lettersWidth = (Convert.ToDouble(max.x) - Convert.ToDouble(min.x))/2000;
            }
        }
    }
}
