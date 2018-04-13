using System;
using System.Data.Entity.ModelConfiguration;

namespace EarlyCodeFilrst.Models
{
    public class InternetSpecial
    {
        public int InternetSpecialId { get; set; }

        public int Nights { get; set; }
        public decimal CostUSD { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int AccommodationId { get; set; }
        public Lodging Accommodation { get; set; }
    }

    public class InternetSpecialConfig : EntityTypeConfiguration<InternetSpecial>
    {
        public InternetSpecialConfig()
        {
            HasRequired(internetSpecial => internetSpecial.Accommodation)
                .WithMany(lodging => lodging.InternetSpecials)
                .HasForeignKey(internetSpecial => internetSpecial.AccommodationId);
        }
    }
}