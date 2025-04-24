namespace CreationalDesignPatterns.Factory.AsyncFactory
{
    public class Program{
        public static async Task Main(string[] args)
        {
            var foo = await Foo.CreateAsync(5);
            System.Console.WriteLine(foo.ToString());
        }
    }
}