using MotorCompany.Orders.Core.Commands;
using Xunit;
using FluentAssertions;

namespace MotorCompany.Orders.Core.Tests.GivenWhenThen
{
    public class WhenCreatingInValidOrder : CreateOrderCommandHandlerTestSpec
    {
        public override void Given()
        {
            base.Given();

            _command = new CreateOrderCommand(-1, -21);
        }

        [Fact]
        public void ThenShouldFail()
        {
            _result.Failed.Should().BeTrue();
        }

        [Fact]
        public void ThenShouldReturnNoOrder()
        {
            _result.Value.Should().BeNull();
        }

        [Fact]
        public void ThenShouldReturnErrors()
        {
            _result.Errors.Should().HaveCount(2);
        }
    }   
}
