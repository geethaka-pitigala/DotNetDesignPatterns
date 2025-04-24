namespace CreationalDesignPatterns.Factory.FactoryMethod
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cartesianPoint = Point.CartisianPoint(3, 4);
            System.Console.WriteLine(cartesianPoint);

            var polarPoint = Point.PolarPoint(10, Math.PI / 3);
            System.Console.WriteLine(polarPoint);
        }
    }
}