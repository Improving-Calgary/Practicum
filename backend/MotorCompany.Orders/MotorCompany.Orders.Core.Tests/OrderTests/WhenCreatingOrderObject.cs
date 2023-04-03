using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MotorCompany.Orders.Core.Tests.OrderTests
{
    [TestClass]
    public class WhenCreatingOrderObject
    {
        [TestMethod]
        public void ShouldNotAllowOrderCreationForInvalidParams()
        {
            var result = Order.Create(0, 1);

            result.Value.Should().BeNull();
        }

        [TestMethod]
        public void ShouldFailOrderCreationForInvalidParams()
        {
            var result = Order.Create(0, 1);

            result.Failed.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFailureErrorCodeForInvalidCustomer()
        {
            var result = Order.Create(0, 1);

            result.Errors.FirstOrDefault()?.Detail.Should().Be("Customer id must be valid.");
        }
    }
}
