namespace Dysgraphie.Drawing
{
    //Représentation graphique d'un point
    public struct DrawingPoint
    {
        public int X, Y, idPoint ;
        public uint pression;
        

        public DrawingPoint(int x, int y, uint pression, int idPoint)
        {
            this.X = x;
            this.Y = y;
            this.pression = pression;
            this.idPoint = idPoint;
        }
    }
}
