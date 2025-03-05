using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PlantillaAPI.Data;
using PlantillaAPI.Models.Entity;
using PlantillaAPI.Repository.IRepository;

namespace PlantillaAPI.Repository
{
    public class GrupoRepository : IGrupoRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string GrupoEntityCacheKey = "GrupoEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        
        public GrupoRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(GrupoEntityCacheKey);
        }


        public async Task<bool> CreateAsync(GrupoEntity GrupoEntity)
        {
            _context.Grupo.Add(GrupoEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var GrupoEntity = await GetAsync(id);
            if (GrupoEntity == null)
                return false;

            _context.Grupo.Remove(GrupoEntity);
            return await Save();
        }
        

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Grupo.AnyAsync(c => c.Id == id);
        }

        public async Task<ICollection<GrupoEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(GrupoEntityCacheKey, out ICollection<GrupoEntity> GruposCached))
                return GruposCached;

            var gruposFromDb = await _context.Grupo.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(GrupoEntityCacheKey, gruposFromDb, cacheEntryOptions);
            return gruposFromDb;
        }

        public async Task<GrupoEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(GrupoEntityCacheKey, out ICollection<GrupoEntity> GrupoCached))
            {
                var GrupoEntity = GrupoCached.FirstOrDefault(c => c.Id == id);
                if (GrupoEntity != null)
                    return GrupoEntity;
            }

            return await _context.Grupo.FirstOrDefaultAsync(c => c.Id == id);
        }

       
        public async Task<bool> UpdateAsync(GrupoEntity GrupoEntity)
        {
            //GrupoEntity.CreatedDate = DateTime.Now;
            _context.Update(GrupoEntity);
            return await Save();
        }
    }
}
