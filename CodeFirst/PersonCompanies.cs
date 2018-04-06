using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class PersonCompanies
    {
        public int PersonId { get; set; }
        public int CompanyId { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }

    public class PersonCompaniesMap : EntityTypeConfiguration<PersonCompanies>
    {
        public PersonCompaniesMap()
        {
            HasKey(pc => new { pc.PersonId, pc.CompanyId });            
        }
    }
}
