namespace Dysgraphie.Drawing
{
    public struct DrawingPoint
    {
        public int X, Y ;
        public uint pression;

        public DrawingPoint(int x, int y, uint pression)
        {
            this.X = x; this.Y = y;this.pression = pression;
        }
    }
}
