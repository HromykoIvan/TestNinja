using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.xUnitTests
{
    public class MathxTests
    {
        //SetUp
        private Fundamentals.Math _math;
        public MathxTests()
        {
            _math = new Fundamentals.Math();
        }

        [Theory(Skip = "Because I wanted to!")]
        [InlineData(1, 2, 3)]
        public void Add_WhenCalled_ReturnSumOfArguments(int a, int b, int expectedResult)
        {
            var result = _math.Add(a, b);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 1, 2)]
        [InlineData(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            result.Should().Equal(new[] { 1, 3, 5 });
        }
    }
}
