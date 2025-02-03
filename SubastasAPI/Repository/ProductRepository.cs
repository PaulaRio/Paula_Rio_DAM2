using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SubastasAPI.Data;
using SubastasAPI.Models.Entity;
using SubastasAPI.Repository.IRepository;

namespace SubastasAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string ProductEntityCacheKey = "ProductEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public ProductRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
            {
                ClearCache();
            }
            return result;
        }

        public void ClearCache()
        {
            _cache.Remove(ProductEntityCacheKey);
        }

        public async Task<ICollection<ProductEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(ProductEntityCacheKey, out ICollection<ProductEntity> ProductsCached))
                return ProductsCached;

            var ProductsFromDb = await _context.Product.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(ProductEntityCacheKey, ProductsFromDb, cacheEntryOptions);
            return ProductsFromDb;
        }

        public async Task<ProductEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(ProductEntityCacheKey, out ICollection<ProductEntity> ProductsCached))
            {
                var ProductEntity = ProductsCached.FirstOrDefault(c => c.Id == id);
                if (ProductEntity != null)
                    return ProductEntity;
            }

            return await _context.Product.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Product.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(ProductEntity ProductEntity)
        {
            //HouseEntity.CreatedDate = DateTime.Now;
            _context.Product.Add(ProductEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(ProductEntity ProductEntity)
        {
            _context.Update(ProductEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ProductEntity = await GetAsync(id);
            if (ProductEntity == null)
                return false;

            _context.Product.Remove(ProductEntity);
            return await Save();
        }
    }
}
