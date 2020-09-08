using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScooterBookingWebApp.Models
{
    public class ScooterDbContext : DbContext
    {
        public ScooterDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer
                (new MigrateDatabaseToLatestVersion<ScooterDbContext, Migrations.Configuration>());
        }
        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<BookedScooter> BookedScooters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}