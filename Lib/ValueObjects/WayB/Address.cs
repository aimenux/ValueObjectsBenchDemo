using System.Collections.Generic;

namespace Lib.ValueObjects.WayB
{
    public class Address : AbstractValueObject
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

        protected override IEnumerable<object> GetEqualityFields()
        {
            yield return Street;
            yield return City;
            yield return Country;
        }
    }
}
