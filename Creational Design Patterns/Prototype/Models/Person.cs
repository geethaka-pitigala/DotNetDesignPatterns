namespace CreationalDesignPatterns.Prototype.Models{
    public class Person{
        public string[] Names {get; set;}
        public Address Address {get; set;}

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other){
            Names = (string[])other.Names.Clone();
            Address = new Address(other.Address.Street, other.Address.City);
        }

        public override string ToString()
        {
            return $"Person: {string.Join(", ", Names)}, Address: {Address}";
        }
    }

}