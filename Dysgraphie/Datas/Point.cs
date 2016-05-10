using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Datas
{
    class Point : IComparable<Point>
    {
        public double id { get; }
        private double sn;
        public double t { get; }
        public double x { get; }
        public double y { get; }
        public double z { get; }
        private double p;
        private double alt;
        private double azi;
        private double twi;

        public Point(String id, String sn, String t, String x, String y, String z, String p, String alt, String azi, String twi)
        {
            this.id = Convert.ToDouble(id);
            this.sn = Convert.ToDouble(sn);
            this.t = Convert.ToDouble(t);
            this.x = Convert.ToDouble(x);
            this.y = Convert.ToDouble(y);
            this.z = Convert.ToDouble(z);
            this.p = Convert.ToDouble(p);
            this.alt = Convert.ToDouble(alt);
            this.azi = Convert.ToDouble(azi);
            this.twi = Convert.ToDouble(twi);
        }

        public int CompareTo(Point other)
        {
            if (this.id < other.id) return -1;
            else return 1;

        }


    }
}


    


