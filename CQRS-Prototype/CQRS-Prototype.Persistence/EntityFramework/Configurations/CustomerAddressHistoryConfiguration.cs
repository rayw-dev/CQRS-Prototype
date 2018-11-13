using CQRS_Prototype.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS_Prototype.Persistence.EntityFramework.Configurations
{
    public class CustomerAddressHistoryConfiguration : IEntityTypeConfiguration<CustomerAddressHistory>
    {
        public void Configure(EntityTypeBuilder<CustomerAddressHistory> builder)
        {
            builder.ToTable("CustomerAddressHistory");
            builder.HasIndex(o => new { o.AddressId, o.CustomerId, o.EffectiveFrom }).IsUnique();
        }
    }
}
