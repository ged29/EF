using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<PersonCompanies> PersonCompanies { get; set; }
    }

    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            HasMany(p => p.PersonCompanies).WithRequired().HasForeignKey(pc => pc.CompanyId);
        }
    }
}
