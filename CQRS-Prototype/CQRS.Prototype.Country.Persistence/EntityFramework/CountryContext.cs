using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Prototype.Country.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Prototype.Country.Persistence.EntityFramework
{
    public class CountryContext:DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options)
        {

        }

        public DbSet<Domain.Models.Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
        }
    }

    public class CountryConfiguration : IEntityTypeConfiguration<Domain.Models.Country>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(pk => pk.Id);
            builder.Property(pk => pk.Id).ValueGeneratedOnAdd();
            builder.HasIndex(i => new { i.EnglishName, i.Alpha3Code }).IsUnique();
        }
    }
}
