using MotorCompany.Orders.Datastore.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace MotorCompany.Orders.API.Utility
{
    public class ApiConfiguration : IApiConfiguration
    {
        private readonly OrderDbContext _dbContext;

        public ApiConfiguration(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateDatabase()
        {
            _dbContext.Database.Migrate();
        }
    }
}