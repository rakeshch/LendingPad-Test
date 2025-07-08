using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }
    }
}
