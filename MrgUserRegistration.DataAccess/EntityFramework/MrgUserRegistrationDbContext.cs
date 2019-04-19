using MrgUserRegistration.DataAccess.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace MrgUserRegistration.DataAccess.EntityFramework
{
    public class MrgUserRegistrationDbContext : DbContext
    {
        public MrgUserRegistrationDbContext(DbContextOptions<MrgUserRegistrationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
