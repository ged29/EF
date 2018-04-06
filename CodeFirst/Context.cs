using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Context : DbContext
    {
        public Context() : base("name=Chapter2")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Person> People { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PersonCompanies> PersonCompanies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PersonCompaniesMap());
            modelBuilder.Configurations.Add(new PersonTypeMap());
            modelBuilder.Configurations.Add(new CompanyMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
