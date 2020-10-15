using FluentAssertions;
using System;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.xUnitTests
{
    public class ReservationxTests
    {
        [Fact]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            result.Should().BeTrue();
        }
    }
}
