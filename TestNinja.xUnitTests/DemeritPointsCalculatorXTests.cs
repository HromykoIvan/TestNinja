using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.xUnitTests
{
    public class DemeritPointsCalculatorXTests
    {
        public DemeritPointsCalculator _calculator;
        public DemeritPointsCalculatorXTests()
        {
            _calculator = new DemeritPointsCalculator();
        }
        [Theory]
        [InlineData(-5)]
        [InlineData(310)]
        public void CalculateDemeritPoints_SpeedOutOfRange_ThrowArgumentOutOfRangeException(int a)
        {

            Action func = () => _calculator.CalculateDemeritPoints(a);

            func.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(65, 0)]
        [InlineData(15, 0)]
        [InlineData(70, 1)]
        [InlineData(75, 2)]
        [InlineData(80, 3)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoint(int a, int expectedResult)
        {
            var result = _calculator.CalculateDemeritPoints(a);

            result.Should().Be(expectedResult);
        }
    }
}
