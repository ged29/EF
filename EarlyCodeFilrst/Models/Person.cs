using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EarlyCodeFilrst.Models
{
    public class Person
    {
        public Person()
        {
            Address = new Address();
            Info = new PersonalInfo();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; } // HostPropertyName_PropertyName -> Address_StreetAddress
        public PersonalInfo Info { get; set; }

        public PersonPhoto Photo { get; set; }

        public List<Lodging> PrimaryContactFor { get; set; }
        public List<Lodging> SecondaryContactFor { get; set; }
        //public List<Reservation> Reservations { get; set; }

        public byte[] RowVersion { get; set; }
    }

    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            ToTable("People");
            HasKey(p => p.PersonId);
            Property(p => p.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    }
}