using MediatR;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.Core.Commands
{
    public class PauseCommand : IRequest<IResult>
    {
        public PauseCommand(int id)
        {
            Id = id;
        }

        private PauseCommand()
        {
        }

        public int Id { get; }
    }
}
