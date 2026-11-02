using System.ComponentModel.DataAnnotations;

namespace Bloque2_BusinessLayer.DTOs
{
    public class ProductCreateDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
