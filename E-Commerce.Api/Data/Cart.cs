using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Api.Data
{
    public class Cart
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }
    }
}
