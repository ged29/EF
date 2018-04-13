using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EarlyCodeFilrst.Models
{
    public abstract class Lodging
    {
        public int LodgingId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        //public bool IsResort { get; set; }
        public decimal MilesFromNearestAirport { get; set; }

        public int? PrimaryContactId { get; set; }
        public Person PrimaryContact { get; set; }

        public int? SecondaryContactId { get; set; }
        public Person SecondaryContact { get; set; }

        public int LocationId { get; set; }
        public Destination Destination { get; set; }
        public List<InternetSpecial> InternetSpecials { get; set; }
    }

    public class LodgingConfig : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfig()
        {            
            Property(p => p.Name).HasMaxLength(200).IsRequired();
            Property(p => p.Owner).IsUnicode(false);
            Property(p => p.MilesFromNearestAirport).HasPrecision(8, 1);

            HasOptional(p => p.PrimaryContact)
                .WithMany(p => p.PrimaryContactFor)
                .HasForeignKey(p => p.PrimaryContactId);

            HasOptional(p => p.SecondaryContact)
                .WithMany(p => p.SecondaryContactFor)
                .HasForeignKey(p => p.SecondaryContactId);

            //Map<Lodging>(lodgingMap => lodgingMap.Requires("IsResort").HasValue(false));
            //Map<Resort>(resortMap => resortMap.Requires("IsResort").HasValue(true));
            //Map<Lodging>(lodgingMap => lodgingMap.ToTable("Lodgings"));
            //Map<Resort>(resortMap => resortMap.ToTable("Resort"));
            Map<Resort>(m => m.ToTable("Resort"));
            Map<Hostel>(m => m.ToTable("Hostel"));
        }
    }
}