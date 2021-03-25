using MotorCompany.Orders.Core.Commands;
using Xunit;
using FluentAssertions;
using MotorCompany.Orders.Core.Utility;
using System.Threading.Tasks;
using NSubstitute;

namespace MotorCompany.Orders.Core.Tests.GivenWhenThen
{
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

        [Fact]
        public void ThenShouldSucceeded()
        {
            _result.Succeeded.Should().BeTrue();
        }

        [Fact]
        public void ThenShouldReturnCreatedOrder()
        {
            _result.Value.Should().NotBeNull();
        }
    }
}
