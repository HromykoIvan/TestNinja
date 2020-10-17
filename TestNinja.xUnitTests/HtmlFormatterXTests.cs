using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.xUnitTests
{
    public class HtmlFormatterXTests
    {
        [Fact]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            //result.Should().Be("<strong>abc</strong>");

            using (new AssertionScope())
            {
                result.Should().StartWith("<strong>");
                result.Should().EndWith("</strong>");
                result.Should().Contain("abc", Exactly.Once());
            }
        }
    }
}
