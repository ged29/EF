using System.Data.Entity;

namespace ModelingFundamentals.Recipe25
{
    public class Recipe25Context : DbContext
    {
        public DbSet<PictureCategory> PictureCategories { get; set; }

        public Recipe25Context() : base("name=EFRecipesEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PictureCategory>()
                        .HasMany(cat => cat.SubCategories)
                        .WithOptional(cat => cat.ParentCategory);
        }
    }
}
