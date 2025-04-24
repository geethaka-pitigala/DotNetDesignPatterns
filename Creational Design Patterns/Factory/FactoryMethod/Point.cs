namespace CreationalDesignPatterns.Factory.FactoryMethod
{
    public class Point{
        public int X { get; set; }
        public int Y { get; set; }

        private Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point CartisianPoint(int x, int y){
            return new Point(x, y);
        }

        public static Point PolarPoint(double radius, double angle)
        {
            return new Point((int)(radius * Math.Cos(angle)), (int)(radius * Math.Sin(angle)));
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }
    }
}