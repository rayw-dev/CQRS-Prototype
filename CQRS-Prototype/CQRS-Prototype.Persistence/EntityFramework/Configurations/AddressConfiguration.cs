using CQRS_Prototype.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS_Prototype.Persistence.EntityFramework.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(pk => pk.Id);
            builder.Property(pk => pk.Id).ValueGeneratedOnAdd();
            builder.HasOne<Country>().WithMany().HasForeignKey(o => o.CountryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(i => new { i.FirstLine, i.PostalCode }).IsUnique();
        }
    }
}
