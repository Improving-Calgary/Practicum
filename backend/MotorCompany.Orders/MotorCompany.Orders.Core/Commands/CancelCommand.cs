using MediatR;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.Core.Commands
{
    public class CancelCommand : IRequest<IResult>
    {
        public CancelCommand(int id)
        {
            Id = id;
        }

        private CancelCommand()
        {
        }

        public int Id { get; }
    }
}
