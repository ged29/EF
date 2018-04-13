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
            modelBuilder.Configurations.Add(new InternetSpecialConfig());
            modelBuilder.Configurations.Add(new PersonPhotoConfig());

            base.OnModelCreating(modelBuilder);
        }

        public static void Test()
        {
#if false
            var destination = new Destination
            {
                Name = "Bali",
                Country = "Indonesia",
                Description = "EcoTourism at its best in exquisite Bali",
                Lodgings = new List<Lodging> {
                    new Lodging{ Name = "Lodging1", Owner = "OwnerA", MilesFromNearestAirport = 150 },
                    //new Lodging{ Name = "Lodging2", Owner = "OwnerA", MilesFromNearestAirport = 50 },
                    new Resort { Name = "Top Notch Resort and Spa", MilesFromNearestAirport=30, Activities="Spa, Hiking, Skiing, Ballooning"}
                }
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
                PersonId = 12345678,
                Photo = new PersonPhoto { Photo = new Byte[0], Caption = "Some caption here" }
            };

            using (var context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);
                context.Trips.Add(trip);
                context.People.Add(person);
                context.SaveChanges();
            }

            using (var context = new BreakAwayContext())
            {
                var rez = context.People.Include("Photo").ToArray();
            }
#endif
            InsertResort();
            InsertHostel();
            GetAllLodgings();
        }

        private static void InsertResort()
        {
            var resort = new Resort
            {
                Name = "Top Notch Resort and Spa",
                MilesFromNearestAirport = 30,
                Activities = "Spa, Hiking, Skiing, Ballooning",
                Destination = new Destination
                {
                    Name = "Stowe, Vermont",
                    Country = "USA"
                }
            };

            using (var context = new BreakAwayContext())
            {
                context.Lodgings.Add(resort);
                context.SaveChanges();
            }
        }

        private static void InsertHostel()
        {
            var hostel = new Hostel
            {
                Name = "AAA Budget Youth Hostel",
                MilesFromNearestAirport = 25,
                PrivateRoomsAvailable = false,
                Destination = new Destination
                {
                    Name = "Hanksville, Vermont",
                    Country = "USA"
                }
            };

            using (var context = new BreakAwayContext())
            {
                context.Lodgings.Add(hostel);
                context.SaveChanges();
            }
        }

        private static void GetAllLodgings()
        {
            using (var context = new BreakAwayContext())
            {
                var lodgings = context.Lodgings.ToList();
                foreach (var lodging in lodgings)
                {
                    Console.WriteLine("Name: {0} Type: {1}", lodging.Name, lodging.GetType().ToString());
                }
            }

            Console.ReadKey();
        }
    }
}