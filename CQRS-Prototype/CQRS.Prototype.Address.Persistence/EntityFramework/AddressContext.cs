using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Prototype.Address.Persistence.EntityFramework
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options)
            : base(options)
        {

        }

        public DbSet<Domain.Models.Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }
    }

    public class AddressConfiguration : IEntityTypeConfiguration<Domain.Models.Address>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(pk => pk.Id);
            builder.Property(pk => pk.Id).ValueGeneratedOnAdd();
            builder.HasIndex(i => new { i.FirstLine, i.PostalCode }).IsUnique();
        }
    }
}
