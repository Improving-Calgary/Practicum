using Xunit;
using FluentAssertions;
using System.Linq;

namespace MotorCompany.Orders.Core.Tests.ArrangeActAssert
{
    public class WhenCreatingOrderObject
    {
        [Fact]
        public void ShouldNotAllowOrderCreationForInvalidParams()
        {
            var result = Order.Create(0, 1);

            result.Value.Should().BeNull();
        }

        [Fact]
        public void ShouldFailOrderCreationForInvalidParams()
        {
            var result = Order.Create(0, 1);

            result.Failed.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnFailureErrorCodeForInvalidCustomer()
        {
            var result = Order.Create(0, 1);

            result.Errors.FirstOrDefault().Detail.Should().Be("Customer id must be valid.");
        }
    }
}
