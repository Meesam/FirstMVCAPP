using System.ComponentModel.DataAnnotations;

namespace FirstMVCAPP.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [MinLength(2, ErrorMessage = "Category Name must have 2 or more character")]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}
