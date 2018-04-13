using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EarlyCodeFilrst.Models
{
    public class Trip
    {
        public Guid Indentifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CostUSD { get; set; }

        public List<Activity> Activities { get; set; }

        public byte[] RowVersion { get; set; }
    }

    public class TripConfig : EntityTypeConfiguration<Trip>
    {
        public TripConfig()
        {
            HasKey(p => p.Indentifier);
            Property(p => p.Indentifier).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.RowVersion).IsRowVersion();

            HasMany(p => p.Activities)
                .WithMany(p => p.Trips)
                .Map(m =>
                {
                    m.ToTable("TripActivities");
                    m.MapLeftKey("TripIndentifier");
                    m.MapRightKey("ActivityId");
                });
        }
    }
}
