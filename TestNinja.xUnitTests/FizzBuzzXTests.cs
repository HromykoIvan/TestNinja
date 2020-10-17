using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.xUnitTests
{
    public class FizzBuzzXTests
    {
        [Theory]
        [InlineData(15, "FizzBuzz")]
        [InlineData(12, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(2, "2")]
        public void GetOutput_WhenCalled_ReturnNumberAsString(int a, string expected)
        {
            var result = FizzBuzz.GetOutput(a);

            result.Should().Be(expected);
        }
    }
}
