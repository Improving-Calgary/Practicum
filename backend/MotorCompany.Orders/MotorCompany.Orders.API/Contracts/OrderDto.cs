using System;

namespace MotorCompany.Orders.API.Contracts
{
    public class OrderDto
    {
        private OrderDto() { }

        public int Id { get; private set; }

        public DateTime CreationDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompleteDate { get; set; }

        public int State { get; set; }

        public int CustomerId { get; set; }

        public int VehicleId { get; set; }
    }
}
