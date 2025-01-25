using BasicAPI.Data;
using BasicAPI.Models.Entity;
using BasicAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BasicAPI.Repository
{
    public class GhibliRepository : IGhibliRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string GhibliEntityCacheKey = "LibroEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public GhibliRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(GhibliEntityCacheKey);
        }

        public async Task<ICollection<GhibliEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(GhibliEntityCacheKey, out ICollection<GhibliEntity> LibrosCached))
                return LibrosCached;

            var librosFromDb = await _context.Ghibli.OrderBy(c => c.Title).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(GhibliEntityCacheKey, librosFromDb, cacheEntryOptions);
            return librosFromDb;
        }

        public async Task<GhibliEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(GhibliEntityCacheKey, out ICollection<GhibliEntity> GhibliCached))
            {
                var GhibliEntity = GhibliCached.FirstOrDefault(c => c.Id == id);
                if (GhibliEntity != null)
                    return GhibliEntity;
            }

            return await _context.Ghibli.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Ghibli.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(GhibliEntity GhibliEntity)
        {
            _context.Ghibli.Add(GhibliEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(GhibliEntity GhibliEntity)
        {
            GhibliEntity.ReleaseDate = DateTime.Now;
            _context.Update(GhibliEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var GhibliEntity = await GetAsync(id);
            if (GhibliEntity == null)
                return false;

            _context.Ghibli.Remove(GhibliEntity);
            return await Save();
        }

    }
}
