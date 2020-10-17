using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;
using Xunit;

namespace TestNinja.xUnitTests.Mocking
{
    public class EmployeeControllerXTests
    {
        public Mock<IEmployeeStorage> _storage;
        public EmployeeController _employeeController;
        public EmployeeControllerXTests()
        {
            _storage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_storage.Object);

        }
        
        [Fact]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            var result = _employeeController.DeleteEmployee(1);

            _storage.Verify(s => s.DeleteEmployee(1));
        }
    }
}
