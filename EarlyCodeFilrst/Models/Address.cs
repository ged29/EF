using System.Data.Entity.ModelConfiguration;

namespace EarlyCodeFilrst.Models
{
    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class AddressConfig : ComplexTypeConfiguration<Address>
    {
        public AddressConfig()
        {
            Property(p => p.StreetAddress).HasMaxLength(150).HasColumnName("StreetAddress");
            Property(p => p.City).HasMaxLength(50).HasColumnName("City");
            Property(p => p.State).HasMaxLength(3).HasColumnName("State");
            Property(p => p.ZipCode).HasMaxLength(5).HasColumnName("ZipCode");
        }
    }
}