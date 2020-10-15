using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.xUnitTests
{
    public class CustomerControllerXTests
    {
        [Fact]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            //result.Should().BeOfType<NotFound>();
            result.Should().BeAssignableTo<NotFound>();
        }

        [Fact]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(5);

            result.Should().BeOfType<Ok>();
            //result.Should().BeAssignableTo<NotFound>();
        }
    }
}
