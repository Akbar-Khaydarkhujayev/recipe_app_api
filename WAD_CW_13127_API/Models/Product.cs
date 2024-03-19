using System.ComponentModel.DataAnnotations;

namespace WAD_CW_13127_API.Models
{
    public class Product
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
    }
}
