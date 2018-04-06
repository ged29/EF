using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirst
{
    public class PersonType
    {
        public int PersonTypeId { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }

    public class PersonTypeMap : EntityTypeConfiguration<PersonType>
    {
        public PersonTypeMap()
        {
            HasMany(pt => pt.People)
                .WithOptional(p => p.PersonType)
                .HasForeignKey(p => p.PersonTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}