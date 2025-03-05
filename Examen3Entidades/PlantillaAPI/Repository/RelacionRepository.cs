using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PlantillaAPI.Data;
using PlantillaAPI.Models.Entity;
using PlantillaAPI.Repository.IRepository;

namespace PlantillaAPI.Repository
{
    public class RelacionRepository : IRelacionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string RelacionEntityCacheKey = "RelacionEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;

        public RelacionRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(RelacionEntityCacheKey);
        }


        public async Task<bool> CreateAsync(RelacionEntity RelacionEntity)
        {
            _context.Relacion.Add(RelacionEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var RelacionEntity = await GetAsync(id);
            if (RelacionEntity == null)
                return false;

            _context.Relacion.Remove(RelacionEntity);
            return await Save();
        }


        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Relacion.AnyAsync(c => c.Id == id);
        }

        public async Task<ICollection<RelacionEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(RelacionEntityCacheKey, out ICollection<RelacionEntity> LibrosCached))
                return LibrosCached;

            var objetosFromDb = await _context.Relacion.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(RelacionEntityCacheKey, objetosFromDb, cacheEntryOptions);
            return objetosFromDb;
        }

        public async Task<RelacionEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(RelacionEntityCacheKey, out ICollection<RelacionEntity> RelacionCached))
            {
                var RelacionEntity = RelacionCached.FirstOrDefault(c => c.Id == id);
                if (RelacionEntity != null)
                    return RelacionEntity;
            }

            return await _context.Relacion.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<bool> UpdateAsync(RelacionEntity RelacionEntity)
        {
            _context.Update(RelacionEntity);
            return await Save();
        }
    }
}
