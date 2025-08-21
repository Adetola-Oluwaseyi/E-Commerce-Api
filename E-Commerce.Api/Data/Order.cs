using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Api.Data
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
