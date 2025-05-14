using CreationalDesignPatterns.Prototype.Interfaces;

namespace CreationalDesignPatterns.Prototype.Models{
    public class Address: IPrototype<Address>{
        public string Street { get; set; }
        public string City { get; set; }
        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }

        // public Address(Address other)
        // {
        //     Street = other.Street;
        //     City = other.City;
        // }

        public Address DeepCopy()
        {
            return new Address(Street, City);
        }

        public override string ToString()
        {
            return $"{Street}, {City}";
        }
    }
}