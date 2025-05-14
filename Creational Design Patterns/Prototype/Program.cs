using CreationalDesignPatterns.Prototype.Models;

namespace CreationalDesignPatterns.Prototype{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var address = new Address("123 Main St", "Springfield");
            var person1 = new Person(new[] { "John Doe" }, address);
            var person2 = new Person(person1);

            person2.Names[0] = "Jane Doe";
            person2.Address.Street = "456 Elm St";

            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
    }
}