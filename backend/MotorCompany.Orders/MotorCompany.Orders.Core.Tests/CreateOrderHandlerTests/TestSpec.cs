namespace MotorCompany.Orders.Core.Tests.CreateOrderHandlerTests
{
    public class TestSpec<T>
    {
        public T Sut { get; set; }

        public TestSpec()
        {
            Given();
            When();
        }

        public virtual void Given() { }

        public virtual void When() { }
    }
}
