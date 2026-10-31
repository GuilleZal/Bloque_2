using System.ComponentModel.DataAnnotations;

namespace Practico_Bloque2_ApiGestion.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
