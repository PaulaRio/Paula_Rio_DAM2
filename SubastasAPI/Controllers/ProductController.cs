using AutoMapper;
using SubastasAPI.Controllers.SubastasAPI.Controllers;
using SubastasAPI.Models.DTOs.Products;
using SubastasAPI.Models.Entity;
using SubastasAPI.Repository;
using SubastasAPI.Repository.IRepository;

namespace SubastasAPI.Controllers
{
    public class ProductController : BaseController<ProductEntity, ProductDTO, CreateProductDTO>
    {
        public ProductController(IProductRepository ProductRepository,
            IMapper mapper, ILogger<ProductController> logger)
            : base(ProductRepository, mapper, logger)
        {
        }
    }
}
