using CQRS_Prototype.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS_Prototype.Persistence.EntityFramework.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(pk => pk.Id);
            builder.Property(pk => pk.Id).ValueGeneratedOnAdd();
            builder.HasOne<Address>().WithMany().HasForeignKey(o => o.BillingAddressId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany<CustomerAddressHistory>().WithOne().HasForeignKey(o => o.AddressId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany<CustomerAddressHistory>().WithOne().HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany<CustomerShippingAddress>().WithOne().HasForeignKey(o => o.AddressId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany<CustomerShippingAddress>().WithOne().HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
