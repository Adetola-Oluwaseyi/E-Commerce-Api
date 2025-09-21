using E_Commerce.Api.Models.Products;

namespace E_Commerce.Api.Contracts
{
    public interface IProductService
    {
        public Task<object> GetProductsAsync(int pageNo, int pageSize);
        public Task<GetProductDto?> GetProductbyIdAsync(Guid productId);
        public Task<string> DeleteProduct(Guid productId);
        public Task AddProduct(ProductDto product);
    }
}
