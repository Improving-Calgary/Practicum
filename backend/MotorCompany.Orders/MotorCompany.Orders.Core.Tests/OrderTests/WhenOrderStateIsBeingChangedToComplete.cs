using Xunit;
using FluentAssertions;
using System.Linq;
using System;

namespace MotorCompany.Orders.Core.Tests.ArrangeActAssert
{
    public class WhenOrderStateIsBeingChangedToComplete : IDisposable
    {
        private Order _sut;

        public WhenOrderStateIsBeingChangedToComplete()
        {
            _sut = Order.Create(1, 1).Value;
        }

        [Fact]
        public void ShouldChangeStateToComplete()
        {
            _sut.Start();

            _sut.Complete();

            _sut.State.Should().Be(EnumOrderStates.Complete);
        }

        [Fact]
        public void ShouldNotAllowStateChangeIfNotStarted()
        {
            var result = _sut.Complete();

            _sut.State.Should().NotBe(EnumOrderStates.Complete);
        }

        [Fact]
        public void ShouldFailIfNotStarted()
        {
            var result = _sut.Complete();

            result.Failed.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnFailureErrorCodeForCompleteIfNotStarted()
        {
            var result = _sut.Complete();

            result.Errors.FirstOrDefault().Detail.Should().Be("Order must be started.");
        }

        public void Dispose()
        {
            _sut = null;
        }
    }
}
