using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelingFundamentals.Recipe25
{
    public class PictureCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; private set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; private set; }

        [ForeignKey("ParentCategoryId")]
        public PictureCategory ParentCategory { get; set; }

        public List<PictureCategory> SubCategories { get; set; }

        public PictureCategory()
        {
            SubCategories = new List<PictureCategory>();
        }
    }
}
