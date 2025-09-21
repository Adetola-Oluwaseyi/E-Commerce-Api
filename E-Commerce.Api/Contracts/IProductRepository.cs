using E_Commerce.Api.Models.Products;

namespace E_Commerce.Api.Contracts
{
    public interface IProductRepository
    {
        Task<Object> GetAllProductsAsync(int pageNo = 1, int pageSize = 20);
        Task<GetProductDto?> GetProductByIdAsync(Guid productId);
        Task AddProductAsync(ProductDto product);
        Task UpdateProductAsync(ProductDto product);
        Task DeleteProductAsync(Guid productId);
        Task<bool> Exists(Guid productId);
    }
}
