namespace E_Commerce.Api.Data
{
    public class Cart
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
