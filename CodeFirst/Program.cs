using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var person = new Person
                {
                    LastName = "Doe",
                    FirstName = "John",
                    IsActive = true,
                    PersonType = new PersonType { TypeName = "PersonTypeA" }
                };
                person.Phones.Add(new Phone { PhoneNumber = "123-446-7890" });
                person.Phones.Add(new Phone { PhoneNumber = "123-446-7891" });

                context.People.Add(person);
                context.SaveChanges();
            }
        }
    }
}
