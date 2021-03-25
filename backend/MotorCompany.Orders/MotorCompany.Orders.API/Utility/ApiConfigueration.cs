using MotorCompany.Orders.Datastore.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace MotorCompany.Orders.API.Utility
{
    public class ApiConfigueration : IApiConfigueration
    {
        private readonly OrderDbContext _dbContext;

        public ApiConfigueration(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateDatabase()
        {
            _dbContext.Database.Migrate();
        }
    }
}