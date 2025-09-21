using AutoMapper;
using AutoMapper.QueryableExtensions;
using E_Commerce.Api.Contracts;
using E_Commerce.Api.Data;
using E_Commerce.Api.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ECommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddProductAsync(ProductDto product)
        {
            var item = _mapper.Map<Product>(product);
            await _context.Products.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(Guid productId)
        {
            var item = await _context.Products.Where(u => u.Id == productId)
                .Select(u => new Product { Id = u.Id, RowVersion = u.RowVersion })
                .FirstOrDefaultAsync();

            if (item != null)
            {
                _context.Products.Remove(item);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<bool> Exists(Guid productId)
        {
            return await _context.Products.AnyAsync(u => u.Id == productId);
        }

        public async Task<Object> GetAllProductsAsync(int pageNo = 1, int pageSize = 20)
        {
            if (pageNo < 1) pageNo = 1;
            if (pageSize < 5) pageSize = 20;

            int maxPageSize = 100;
            if (pageSize > maxPageSize) pageSize = maxPageSize;

            int totalCount = await _context.Products.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var response = await _context.Products
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<GetProductsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new
            {
                Data = response,
                PageNumber = pageNo,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalCount = totalCount
            };
        }

        public async Task<GetProductDto?> GetProductByIdAsync(Guid productId)
        {
            return await _context.Products
                .Where(u => u.Id == productId)
                .ProjectTo<GetProductDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public Task UpdateProductAsync(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
