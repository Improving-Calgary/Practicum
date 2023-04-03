namespace MotorCompany.Orders.API.Contracts
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }

        public int VehicleId { get; set; }
    }
}
