using MotorCompany.Orders.Core.Commands;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MotorCompany.Orders.Core.Tests.GivenWhenThen
{
    [TestClass]
    public class WhenCreatingInValidOrder : CreateOrderCommandHandlerTestSpec
    {
        public override void Given()
        {
            base.Given();

            _command = new CreateOrderCommand(-1, -21);
        }

        [TestMethod]
        public void ThenShouldFail()
        {
            _result.Failed.Should().BeTrue();
        }

        [TestMethod]
        public void ThenShouldReturnNoOrder()
        {
            _result.Value.Should().BeNull();
        }

        [TestMethod]
        public void ThenShouldReturnErrors()
        {
            _result.Errors.Should().HaveCount(2);
        }
    }   
}
