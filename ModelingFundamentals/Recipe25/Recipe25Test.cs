using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingFundamentals.Recipe25
{
    static class Recipe25Test
    {
        static void Run()
        {
            using (var context = new Recipe25Context())
            {
                var louvre = new PictureCategory { Name = "Louvre" };
                louvre.SubCategories.Add(new PictureCategory { Name = "Egyptian Antiquites" });
                louvre.SubCategories.Add(new PictureCategory { Name = "Sculptures" });
                louvre.SubCategories.Add(new PictureCategory { Name = "Paintings" });

                var paris = new PictureCategory { Name = "Paris" };
                paris.SubCategories.Add(louvre);

                var vacation = new PictureCategory { Name = "Summer Vacation" };
                vacation.SubCategories.Add(paris);

                context.PictureCategories.Add(paris);
                context.SaveChanges();
            }
        }
    }
}
