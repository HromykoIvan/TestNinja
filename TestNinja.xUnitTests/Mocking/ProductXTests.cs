using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;
using Xunit;

namespace TestNinja.xUnitTests.Mocking
{
    public class ProductXTests
    {
        [Fact]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            var product = new Product { ListPrice = 100 };

            //no need Mock for thу Customer - it's very bad practice
            var result = product.GetPrice(new Customer { IsGold = true });

            result.Should().Be(70);
        }
    }
}
