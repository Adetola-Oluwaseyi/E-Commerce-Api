using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Api.Data
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be a non-negative integer.")]
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid? CategoryId { get; set; }

        // Navigation property
        public Category Category { get; set; }
    }
}
