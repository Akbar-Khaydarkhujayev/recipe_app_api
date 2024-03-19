using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WAD_CW_13127_API.Models
{
    public class Recipe
    {
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Details is required")]
        public string? Details { get; set; }
        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product? Product { get; set; }
    }
}
