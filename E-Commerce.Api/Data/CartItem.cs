using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Api.Data
{
    public class CartItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a non-negative integer.")]
        public int Quantity { get; set; }

        [Required]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
