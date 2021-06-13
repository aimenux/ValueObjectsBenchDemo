using System;
using FluentAssertions;
using Lib.ValueObjects.WayA;
using Xunit;

namespace Tests.ValueObjects.WayA
{
    public class DateTests
    {
        [Theory]
        [InlineData(2021, 07, 03)]
        [InlineData(2021, 09, 05)]
        public void Should_Equals_Method_Returns_True(int year, int month, int days)
        {
            // arrange
            var first = new Date(new DateTimeOffset(new DateTime(year, month, days)));
            var second = new Date(new DateTimeOffset(new DateTime(year, month, days)));

            // act
            var equals = first.Equals(second);

            // assert
            equals.Should().BeTrue();
        }

        [Fact]
        public void Should_Equals_Method_Returns_False()
        {
            // arrange
            var first = new Date(new DateTimeOffset(new DateTime(2021, 12, 01)));
            var second = new Date(new DateTimeOffset(new DateTime(2021, 12, 02)));

            // act
            var equals = first.Equals(second);

            // assert
            equals.Should().BeFalse();
        }

        [Theory]
        [InlineData(2021, 07, 03)]
        [InlineData(2021, 09, 05)]
        public void Should_Equals_Operator_Returns_True(int year, int month, int days)
        {
            // arrange
            var first = new Date(new DateTimeOffset(new DateTime(year, month, days)));
            var second = new Date(new DateTimeOffset(new DateTime(year, month, days)));

            // act
            var equals = first == second;

            // assert
            equals.Should().BeTrue();
        }

        [Fact]
        public void Should_Equals_Operator_Returns_False()
        {
            // arrange
            var first = new Date(new DateTimeOffset(new DateTime(2021, 12, 01)));
            var second = new Date(new DateTimeOffset(new DateTime(2021, 12, 02)));

            // act
            var equals = first == second;

            // assert
            equals.Should().BeFalse();
        }

        [Fact]
        public void Should_NotEquals_Operator_Returns_True()
        {
            // arrange
            var first = new Date(new DateTimeOffset(new DateTime(2021, 12, 01)));
            var second = new Date(new DateTimeOffset(new DateTime(2021, 12, 02)));

            // act
            var equals = first != second;

            // assert
            equals.Should().BeTrue();
        }

        [Theory]
        [InlineData(2021, 07, 03)]
        [InlineData(2021, 09, 05)]
        public void Should_NotEquals_Operator_Returns_False(int year, int month, int days)
        {
            // arrange
            var first = new Date(new DateTimeOffset(new DateTime(year, month, days)));
            var second = new Date(new DateTimeOffset(new DateTime(year, month, days)));

            // act
            var equals = first != second;

            // assert
            equals.Should().BeFalse();
        }

        [Theory]
        [InlineData(2021, 07, 03)]
        [InlineData(2021, 09, 05)]
        public void Should_GetHashCode_Returns_Same_HashCode_For_EqualValueObjects(int year, int month, int days)
        {
            // arrange
            var first = new Date(new DateTimeOffset(new DateTime(year, month, days)));
            var second = new Date(new DateTimeOffset(new DateTime(year, month, days)));

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
            var first = new Date(new DateTimeOffset(new DateTime(2021, 12, 01)));
            var second = new Date(new DateTimeOffset(new DateTime(2021, 12, 02)));

            // act
            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            // assert
            firstHashCode.Should().NotBe(secondHashCode);
        }
    }
}
