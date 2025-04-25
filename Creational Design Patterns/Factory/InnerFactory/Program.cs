namespace CreationalDesignPatterns.Factory.InnerFactory
{
    public class Program{
        public static void Main(string[] args)
        {
            var cartesianPoint = Point.Factory.CartisianPoint(3, 4);
            var polarPoint = Point.Factory.PolarPoint(5, Math.PI / 4);

            Console.WriteLine(cartesianPoint); // Output: Point(3, 4)
            Console.WriteLine(polarPoint); // Output: Point(3, 3)
        }
    }

}