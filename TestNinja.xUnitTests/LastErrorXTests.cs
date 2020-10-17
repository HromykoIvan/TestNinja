using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.xUnitTests
{
    public class LastErrorXTests
    {
        [Fact]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var errorLogger = new ErrorLogger();

            errorLogger.Log("a");

            errorLogger.LastError.Should().Be("a");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var errorLogger = new ErrorLogger();
            Action func = () => errorLogger.Log(error);

            func.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var errorLogger = new ErrorLogger();
            var id = Guid.Empty;
            errorLogger.ErrorLogged += (sender, args) => { id = args; };
            errorLogger.Log("a");

            //id.Should().NotBe(Guid.Empty);
            id.Should().NotBeEmpty();
        }
    }
}
