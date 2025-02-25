using System.ComponentModel.DataAnnotations;

namespace FirstMVCAPP.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Title is required")]
        [MinLength(2, ErrorMessage = "Product Title must have 2 or more character")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }


    }
}
