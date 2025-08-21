using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Api.Data
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int Quantity { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price at purchase must be a positive number.")]
        public decimal PriceatPurchase { get; set; }

        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
