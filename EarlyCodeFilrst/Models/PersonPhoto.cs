using System.Data.Entity.ModelConfiguration;

namespace EarlyCodeFilrst.Models
{
    public class PersonPhoto
    {
        // primary key of the dependent be used as the foreign key
        public int PersonId { get; set; }
        public byte[] Photo { get; set; }
        public string Caption { get; set; }

        public Person PhotoOf { get; set; }
    }

    public class PersonPhotoConfig : EntityTypeConfiguration<PersonPhoto>
    {
        public PersonPhotoConfig()
        {
            ToTable("People");
            HasKey(p => p.PersonId);
            HasRequired(p => p.PhotoOf).WithRequiredDependent(p => p.Photo);
            Property(p => p.Photo).HasColumnType("image");
        }
    }
}