using FluentAssertions;
using Lib.ValueObjects.WayD;
using Xunit;

namespace Tests.ValueObjects.WayD
{
    public class AddressTests
    {
        [Theory]
        [InlineData("26", "Paris", "France")]
        [InlineData("26 BIS", "Paris", "France")]
        public void Should_Equals_Method_Returns_True(string street, string city, string country)
        {
            // arrange
            var first = new Address(street, city, country);
            var second = new Address(street, city, country);

            // act
            var equals = first.Equals(second);

            // assert
            equals.Should().BeTrue();
        }

        [Fact]
        public void Should_Equals_Method_Returns_False()
        {
            // arrange
            var first = new Address("street", "city", "country1");
            var second = new Address("street", "city", "country2");

            // act
            var equals = first.Equals(second);

            // assert
            equals.Should().BeFalse();
        }

        [Theory]
        [InlineData("26", "Paris", "France")]
        [InlineData("26 BIS", "Paris", "France")]
        public void Should_Equals_Operator_Returns_True(string street, string city, string country)
        {
            // arrange
            var first = new Address(street, city, country);
            var second = new Address(street, city, country);

            // act
            var equals = first == second;

            // assert
            equals.Should().BeTrue();
        }

        [Fact]
        public void Should_Equals_Operator_Returns_False()
        {
            // arrange
            var first = new Address("street1", "city1", "country1");
            var second = new Address("street2", "city2", "country2");

            // act
            var equals = first == second;

            // assert
            equals.Should().BeFalse();
        }

        [Fact]
        public void Should_NotEquals_Operator_Returns_True()
        {
            // arrange
            var first = new Address("street1", "city1", "country1");
            var second = new Address("street2", "city2", "country2");

            // act
            var equals = first != second;

            // assert
            equals.Should().BeTrue();
        }

        [Theory]
        [InlineData("26", "Paris", "France")]
        [InlineData("26 BIS", "Paris", "France")]
        public void Should_NotEquals_Operator_Returns_False(string street, string city, string country)
        {
            // arrange
            var first = new Address(street, city, country);
            var second = new Address(street, city, country);

            // act
            var equals = first != second;

            // assert
            equals.Should().BeFalse();
        }

        [Theory]
        [InlineData("26", "Paris", "France")]
        [InlineData("26 BIS", "Paris", "France")]
        public void Should_GetHashCode_Returns_Same_HashCode_For_EqualValueObjects(string street, string city, string country)
        {
            // arrange
            var first = new Address(street, city, country);
            var second = new Address(street, city, country);

            // act
            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            // assert
            firstHashCode.Should().Be(secondHashCode);
        }

        [Fact]
        public void Should_GetHashCode_Returns_Distinct_HashCode_For_NotEqualValueObjects()
        {
            // arrange
            var first = new Address("street1", "city1", "country1");
            var second = new Address("street2", "city2", "country2");

            // act
            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            // assert
            firstHashCode.Should().NotBe(secondHashCode);
        }
    }
}
