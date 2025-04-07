
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

    public class Person
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Address: {Address}";
        }
    }

    public abstract class FunctionalBuilder<T, TSelf> where TSelf : FunctionalBuilder<T, TSelf>{
        protected List<Func<T, T>> _actions = new List<Func<T, T>>();

        public TSelf AddAction(Func<T, T> action)
        {
            _actions.Add(action);
            return (TSelf) this; 
        }

        public abstract T Build();
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>{
        private readonly Person _person = new Person();
        public override Person Build(){
            return this._actions.Aggregate(_person, (p, action) => action(p));
        }
    }

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WithName(this PersonBuilder builder, string name)
        {
            return builder.AddAction(p => { p.Name = name; return p; });
        }

        public static PersonBuilder WithAge(this PersonBuilder builder, int age)
        {
            return builder.AddAction(p => { p.Age = age; return p; });
        }

        public static PersonBuilder WithAddress(this PersonBuilder builder, string address)
        {
            return builder.AddAction(p => { p.Address = address; return p; });
         }
    }
}
