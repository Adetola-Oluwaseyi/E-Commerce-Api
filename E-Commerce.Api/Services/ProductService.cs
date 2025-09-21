using E_Commerce.Api.Contracts;
using E_Commerce.Api.Data;
using E_Commerce.Api.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;

        }
        public async Task AddProduct(ProductDto product)
        {
            await _repository.AddProductAsync(product);
        }

        public async Task<string> DeleteProduct(Guid productId)
        {
            try
            {
                await _repository.DeleteProductAsync(productId);
            }
            catch (DbUpdateConcurrencyException e)
            {
                var entry = e.Entries.SingleOrDefault();
                var product = (Product)entry.Entity;
                entry.State = EntityState.Detached;
                if (_repository.Exists(productId))
                {
                    return "This product has been updated.";
                }

                return "This product has already been deleted.";
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "This product has been deleted.";
        }

        public async Task<object> GetProductsAsync(int pageNo, int pageSize)
        {
            return await _repository.GetAllProductsAsync(pageNo, pageSize);
        }

    }
}
