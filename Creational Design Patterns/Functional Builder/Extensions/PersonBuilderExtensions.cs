using CreationalDesignPatterns.FunctionalBuilder.Builders;

namespace CreationalDesignPatterns.FunctionalBuilder.Extensions
{
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