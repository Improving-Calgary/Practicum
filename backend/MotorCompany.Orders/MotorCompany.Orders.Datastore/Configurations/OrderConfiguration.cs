using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MotorCompany.Orders.Datastore.SQLServer.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Core.Order>
    {
        public void Configure(EntityTypeBuilder<Core.Order> builder)
        {
            builder.Property(e => e.Id);
            builder.Property(e => e.CustomerId).IsRequired();
            builder.Property(e => e.VehicleId).IsRequired();
            builder.Property(e => e.CreationDate).IsRequired();
        }
    }
}
