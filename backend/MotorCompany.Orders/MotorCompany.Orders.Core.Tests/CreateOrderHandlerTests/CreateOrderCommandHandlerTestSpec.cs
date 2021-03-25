using MotorCompany.Orders.Core.Commands;
using MotorCompany.Orders.Core.Commands.Handlers;
using NSubstitute;
using System.Threading;
using MotorCompany.Orders.Core.Utility;
using System.Threading.Tasks;
using System;

namespace MotorCompany.Orders.Core.Tests.GivenWhenThen
{
    public class CreateOrderCommandHandlerTestSpec : TestSpec<CreateOrderCommandHandler>
    {
        internal IUnitOfWork _uow;
        internal IRepository<Order> _repo;
        internal IResult<Order> _result;
        internal CreateOrderCommand _command;

        public override void Given()
        {
            _repo = Substitute.For<IRepository<Order>>();

            _uow = new TestHelperUnitOfWork(_repo);
         
            Sut = new CreateOrderCommandHandler(_uow);
        }

        public override void When()
        {
            _result = Sut.Handle(_command, CancellationToken.None).Result;
        }

        internal class TestHelperUnitOfWork : IUnitOfWork
        {
            internal IRepository<Order> _repo;

            public TestHelperUnitOfWork(IRepository<Order> repo)
            {
                _repo = repo;
            }

            public IRepositoryReadOnly<T> GetRepository<T>() where T : class
            {
                return _repo as IRepositoryReadOnly<T>;
            }

            public async Task<IResult<T>> TransactionScope<T>(Func<IRepository<T>, IResult<T>> transaction) where T : class
            {
                return transaction(_repo as IRepository<T>);
            }
        }
    }
}
