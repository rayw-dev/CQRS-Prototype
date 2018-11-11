using CQRS_Prototype.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Prototype.Persistence.EntityFramework
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerAddressHistory> CustomerAddressHistories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
