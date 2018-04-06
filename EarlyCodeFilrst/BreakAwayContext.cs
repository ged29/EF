using EarlyCodeFilrst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyCodeFilrst
{
    public class BreakAwayContext : DbContext
    {
        public BreakAwayContext() : base("name=BreakAwayCtx")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BreakAwayContext>());
        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DestinationConfig());
            modelBuilder.Configurations.Add(new LodgingConfig());
            modelBuilder.Configurations.Add(new TripConfig());
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new AddressConfig());
            modelBuilder.Configurations.Add(new PersonalInfoConfig());
            
            base.OnModelCreating(modelBuilder);
        }

        public static void Test()
        {
            var destination = new Destination
            {
                Name = "Bali",
                Country = "Indonesia",
                Description = "EcoTourism at its best in exquisite Bali"
            };

            var trip = new Trip
            {
                CostUSD = 800,
                StartDate = new DateTime(2011, 9, 1),
                EndDate = new DateTime(2011, 9, 14)
            };

            var person = new Person
            {
                FirstName = "Rowan",
                LastName = "Miller",
                SocialSecurityNumber = 12345678
            };

            using (var context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);
                context.Trips.Add(trip);
                context.People.Add(person);
                context.SaveChanges();
            }
        }
    }
}
