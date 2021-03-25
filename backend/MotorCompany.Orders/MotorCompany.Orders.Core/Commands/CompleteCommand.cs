using MediatR;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.Core.Commands
{
    public class CompleteCommand : IRequest<IResult>
    {
        public CompleteCommand(int id)
        {
            Id = id;
        }

        private CompleteCommand()
        {
        }

        public int Id { get; }
    }
}
