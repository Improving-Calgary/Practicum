using MediatR;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.Core.Commands
{
    public class StartCommand : IRequest<IResult>
    {
        public StartCommand(int id)
        {
            Id = id;
        }

        private StartCommand()
        {
        }

        public int Id { get; }
    }
}
