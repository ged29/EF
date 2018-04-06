using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirst
{
    public class Person
    {
        public Person()
        {
            Phones = new HashSet<Phone>();
        }

        public int PersonId { get; set; }

        //[MaxLength(30, ErrorMessage = "First name cannot be longer than 30")]
        public string FirstName { get; set; }

        //[MaxLength(30, ErrorMessage = "Last name cannot be longer than 30")]
        public string LastName { get; set; }

        //[StringLength(1, MinimumLength = 1)]
        //[Column(TypeName = "char")]
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? HeightInFeet { get; set; }
        public byte[] Photo { get; set; }
        public bool IsActive { get; set; }
        public int? NumberOfCars { get; set; }

        public int? PersonTypeId { get; set; }
        public virtual PersonType PersonType { get; set; }

        public virtual ICollection<PersonCompanies> PersonCompanies { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }

    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            Property(p => p.FirstName).HasMaxLength(30).IsRequired();
            Property(p => p.LastName).HasMaxLength(30).IsRequired();
            Property(p => p.MiddleName).HasMaxLength(1).IsFixedLength().IsUnicode(false);
            Property(p => p.BirthDate).IsOptional();
            Property(p => p.HeightInFeet).HasPrecision(4, 2);
            Property(p => p.Photo).IsVariableLength().HasMaxLength(4000);

            HasMany(p => p.Phones)
                .WithRequired()
                .HasForeignKey(phone => phone.PersonId);

            HasMany(p => p.PersonCompanies).WithRequired().HasForeignKey(pc => pc.PersonId);

            //HasMany(p => p.Companies)
            //    .WithMany(c => c.People)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("PersonId");
            //        m.MapRightKey("CompanyId");
            //    });
        }
    }
}