using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PlantillaAPI.Data;
using PlantillaAPI.Models.Entity;
using PlantillaAPI.Repository.IRepository;

namespace PlantillaAPI.Repository
{
    public class ObjectRepository : IObjectRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string ObjectEntityCacheKey = "ObjectEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        
        public ObjectRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(ObjectEntityCacheKey);
        }


        public async Task<bool> CreateAsync(ObjectEntity ObjectEntity)
        {
            _context.Object.Add(ObjectEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ObjectEntity = await GetAsync(id);
            if (ObjectEntity == null)
                return false;

            _context.Object.Remove(ObjectEntity);
            return await Save();
        }
        

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Object.AnyAsync(c => c.Id == id);
        }

        public async Task<ICollection<ObjectEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(ObjectEntityCacheKey, out ICollection<ObjectEntity> LibrosCached))
                return LibrosCached;

            var objetosFromDb = await _context.Object.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(ObjectEntityCacheKey, objetosFromDb, cacheEntryOptions);
            return objetosFromDb;
        }

        public async Task<ObjectEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(ObjectEntityCacheKey, out ICollection<ObjectEntity> ObjectCached))
            {
                var ObjectEntity = ObjectCached.FirstOrDefault(c => c.Id == id);
                if (ObjectEntity != null)
                    return ObjectEntity;
            }

            return await _context.Object.FirstOrDefaultAsync(c => c.Id == id);
        }

       
        public async Task<bool> UpdateAsync(ObjectEntity ObjectEntity)
        {
            _context.Update(ObjectEntity);
            return await Save();
        }
    }
}
