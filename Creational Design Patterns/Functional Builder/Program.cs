using CreationalDesignPatterns.FunctionalBuilder.Models;
using CreationalDesignPatterns.FunctionalBuilder.Builders;
using CreationalDesignPatterns.FunctionalBuilder.Extensions;


namespace CreationalDesignPatterns.FunctionalBuilder{
    public class Program
    {
        public static void Main(string[] args)
        {
            var person = new PersonBuilder()
                .WithName("John Doe")
                .WithAge(30)
                .WithAddress("123 Main St")
                .Build();
            
            Console.WriteLine(person);
        }
    }
}
