using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Datas
{
    class Point : IComparable<Point>
    {
        public int id { get; }
        public uint sn { get; }
        public double t { get; }
        public int x { get; }
        public int y { get; }
        public int z { get; }
        public uint p { get; }
        public int alt { get; }
        public int azi { get; }
        public int twi { get; }


        public Point(int id, uint sn, double t, int x, int y, int z, uint p, int alt, int azi, int twi)
        {
            if (z <= 20) z = 0;
            this.id = id;
            this.sn = sn;
            this.t = t;
            this.x = x;
            this.y = y;
            this.z = z;
            this.p = p;
            this.alt = alt;
            this.azi = azi;
            this.twi = twi;
        }

      

        public int CompareTo(Point other)
        {
            if (this.id < other.id) return -1;
            else return 1;

        }


    }
}


    


