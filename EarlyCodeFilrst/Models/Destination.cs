using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace EarlyCodeFilrst.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }

        //[Required, MinLength(3), MaxLength(200)]
        public string Name { get; set; }

        public string Country { get; set; }

        //[MaxLength(500)]
        public string Description { get; set; }

        //[Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public List<Lodging> Lodgings { get; set; }
    }

    public class DestinationConfig : EntityTypeConfiguration<Destination>
    {
        public DestinationConfig()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(200);
            Property(p => p.Description).HasMaxLength(500);
            Property(p => p.Photo).HasColumnType("image");
            HasMany(d => d.Lodgings).WithRequired(l => l.Destination);
        }
    }
}
