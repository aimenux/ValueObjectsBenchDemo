namespace Lib.ValueObjects.WayA
{
    public class Address : AbstractValueObject<Address>
    {
        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        public string Street { get; }

        public string City { get; }

        public string Country { get; }
    }
}
