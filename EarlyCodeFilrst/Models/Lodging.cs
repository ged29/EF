using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace EarlyCodeFilrst.Models
{
    public class Lodging
    {
        public int LodgingId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public bool IsResort { get; set; }
        public decimal MilesFromNearestAirport { get; set; }
        
        public Destination Destination { get; set; }
    }

    public class LodgingConfig : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfig()
        {
            Property(p => p.Name).HasMaxLength(200).IsRequired();
            Property(p => p.Owner).IsUnicode(false);
            Property(p => p.MilesFromNearestAirport).HasPrecision(8, 1);
        }
    }
}
