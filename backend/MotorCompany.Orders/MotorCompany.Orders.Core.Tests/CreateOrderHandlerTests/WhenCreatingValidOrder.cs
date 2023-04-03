using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorCompany.Orders.Core.Commands;
using MotorCompany.Orders.Core.Tests.GivenWhenThen;
using MotorCompany.Orders.Core.Utility;
using NSubstitute;

namespace MotorCompany.Orders.Core.Tests.CreateOrderHandlerTests
{
    [TestClass]
    public class WhenCreatingValidOrder : CreateOrderCommandHandlerTestSpec
    {
        public override void Given()
        {
            base.Given();

            _command = new CreateOrderCommand(1, 1);

            _repo.Add(Arg.Any<Order>())
                .Returns(Result.Success()
                .For(Order.Create(_command.CustomerId, _command.VehicleId).Value));

        }

        [TestMethod]
        public void ThenShouldSucceeded()
        {
            _result.Succeeded.Should().BeTrue();
        }

        [TestMethod]
        public void ThenShouldReturnCreatedOrder()
        {
            _result.Value.Should().NotBeNull();
        }
    }
}
