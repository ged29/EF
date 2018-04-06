using System.Data.Entity.ModelConfiguration;

namespace EarlyCodeFilrst.Models
{
    public class Measurement
    {
        public decimal Reading { get; set; }
        public string Units { get; set; }
    }

    public class PersonalInfo
    {
        public Measurement Weight { get; set; }
        public Measurement Height { get; set; }
        public string DietryRestrictions { get; set; }

        public PersonalInfo()
        {
            Weight = new Measurement();
            Height = new Measurement();
        }
    }

    public class PersonalInfoConfig : ComplexTypeConfiguration<PersonalInfo>
    {
        public PersonalInfoConfig()
        {
            Property(p => p.DietryRestrictions).HasMaxLength(200);
        }
    }
}