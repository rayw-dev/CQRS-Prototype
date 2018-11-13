using CQRS_Prototype.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS_Prototype.Persistence.EntityFramework.Configurations
{
    public class CustomerShippingAddressConfiguration : IEntityTypeConfiguration<CustomerShippingAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerShippingAddress> builder)
        {
            builder.ToTable("CustomerShippingAddress");
            builder.HasIndex(o => new { o.AddressId, o.CustomerId }).IsUnique();
        }
    }
}
