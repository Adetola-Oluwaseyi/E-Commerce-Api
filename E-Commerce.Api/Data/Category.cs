using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Api.Data
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = string.Empty;
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
