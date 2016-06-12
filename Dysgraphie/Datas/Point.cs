using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Datas
{
    //Représentation d'un point donné par la tablette
    class Point : IComparable<Point>
    {
        public int id { get; }  //identifiant
        public uint sn { get; } //numéro de série
        public double t { get; }    //temps en millisecondes
        public int x { get; }   //coordonnées x
        public int y { get; }   //coordonnées y
        public int z { get; }   //coordonnées z
        public uint p { get; }  //pression(0-1023)
        public int alt { get; } //inclinaison du stylo
        public int azi { get; } //angle du stylo
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


    


