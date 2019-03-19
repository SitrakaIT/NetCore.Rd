using NetCore.Rd.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace NetCore.Rd.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>();
            modelBuilder.Entity<Apartment>();
        }
    }
}