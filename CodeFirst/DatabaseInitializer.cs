using System.Data.Entity;

namespace CodeFirst
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            context.Companies.Add(new Company { Name = "My Company" });
            base.Seed(context);
        }
    }
}
