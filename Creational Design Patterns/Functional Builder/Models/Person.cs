namespace CreationalDesignPatterns.FunctionalBuilder.Models
{
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
}