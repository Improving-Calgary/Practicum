namespace MotorCompany.Orders.Core.Utility
{
    public class Error : IError
    {
        public Error(string detail)
        {
            Detail = detail;
        }

        public string Detail { get; }
    }
}
