using SubastasAPI.Data;
using SubastasAPI.Models.Entity;
using SubastasAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace SubastasAPI.Repository
{
    public class PujaRepository : IPujaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string PujaEntityCacheKey = "PujaEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public PujaRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(PujaEntityCacheKey);
        }

        public async Task<ICollection<PujaEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(PujaEntityCacheKey, out ICollection<PujaEntity> PujaCached))
                return PujaCached;

            var pujasFromDb = await _context.Puja.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(PujaEntityCacheKey, pujasFromDb, cacheEntryOptions);
            return pujasFromDb;
        }

        public async Task<PujaEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(PujaEntityCacheKey, out ICollection<PujaEntity> PujaCached))
            {
                var PujaEntity = PujaCached.FirstOrDefault(c => c.Id == id);
                if (PujaEntity != null)
                    return PujaEntity;
            }

            return await _context.Puja.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Puja.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(PujaEntity PujaEntity)
        {
            _context.Puja.Add(PujaEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(PujaEntity PujaEntity)
        {
            
            _context.Update(PujaEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var PujaEntity = await GetAsync(id);
            if (PujaEntity == null)
                return false;

            _context.Puja.Remove(PujaEntity);
            return await Save();
        }

        public async Task<bool> AddPujaToProduct(int productId, PujaEntity PujaEntity)
        {
            var product = await _context.Product.Include(p => p.Pujas)
                                                 .FirstOrDefaultAsync(p => p.Id == productId);

            product.Pujas.Add(PujaEntity); 
            return await Save();
        }
        public async Task<PujaEntity?> GetTopPuja(int productId)
        {
            return await _context.Puja
                .Where(p => p.IdProduct == productId)
                .OrderByDescending(p => p.Bid)
                .FirstOrDefaultAsync();
        }



    }
}
