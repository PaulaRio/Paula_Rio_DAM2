using SubastasAPI.Models.Entity;

namespace SubastasAPI.Repository.IRepository
{
    public interface IPujaRepository : IRepository<PujaEntity>
    {
        Task<bool> AddPujaToProduct(int productId, PujaEntity newPuja);
        Task<PujaEntity> GetTopPuja(int productId);
       
    }
}
