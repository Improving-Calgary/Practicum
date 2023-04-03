using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MotorCompany.Orders.Core.Tests.OrderTests
{
    [TestClass]
    public class WhenOrderStateIsBeingChangedToComplete
    {
        private Order _sut;

        public WhenOrderStateIsBeingChangedToComplete()
        {
            _sut = Order.Create(1, 1).Value;
        }

        [TestMethod]
        public void ShouldChangeStateToComplete()
        {
            _sut.Start();

            _sut.Complete();

            _sut.State.Should().Be(EnumOrderStates.Complete);
        }

        [TestMethod]
        public void ShouldNotAllowStateChangeIfNotStarted()
        {
            var result = _sut.Complete();

            _sut.State.Should().NotBe(EnumOrderStates.Complete);
        }

        [TestMethod]
        public void ShouldFailIfNotStarted()
        {
            var result = _sut.Complete();

            result.Failed.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFailureErrorCodeForCompleteIfNotStarted()
        {
            var result = _sut.Complete();

            result.Errors.FirstOrDefault()?.Detail.Should().Be("Order must be started.");
        }
    }
}
