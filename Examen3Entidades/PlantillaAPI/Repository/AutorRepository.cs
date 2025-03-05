using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PlantillaAPI.Data;
using PlantillaAPI.Models.Entity;
using PlantillaAPI.Repository.IRepository;

namespace PlantillaAPI.Repository
{
    public class AutorRepository : IAutorRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string AutorEntityCacheKey = "AutorEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        
        public AutorRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(AutorEntityCacheKey);
        }


        public async Task<bool> CreateAsync(AutorEntity AutorEntity)
        {
            _context.Autor.Add(AutorEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var AutorEntity = await GetAsync(id);
            if (AutorEntity == null)
                return false;

            _context.Autor.Remove(AutorEntity);
            return await Save();
        }
        

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Autor.AnyAsync(c => c.Id == id);
        }

        public async Task<ICollection<AutorEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(AutorEntityCacheKey, out ICollection<AutorEntity> AutoresCached))
                return AutoresCached;

            var autoresFromDb = await _context.Autor.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(AutorEntityCacheKey, autoresFromDb, cacheEntryOptions);
            return autoresFromDb;
        }

        public async Task<AutorEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(AutorEntityCacheKey, out ICollection<AutorEntity> AutorCached))
            {
                var AutorEntity = AutorCached.FirstOrDefault(c => c.Id == id);
                if (AutorEntity != null)
                    return AutorEntity;
            }

            return await _context.Autor.FirstOrDefaultAsync(c => c.Id == id);
        }

       
        public async Task<bool> UpdateAsync(AutorEntity AutorEntity)
        {
            //AutorEntity.CreatedDate = DateTime.Now;
            _context.Update(AutorEntity);
            return await Save();
        }
    }
}
