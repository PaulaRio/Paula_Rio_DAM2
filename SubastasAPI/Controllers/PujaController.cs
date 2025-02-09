using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubastasAPI.Controllers.SubastasAPI.Controllers;
using SubastasAPI.Models.DTOs.Puja;
using SubastasAPI.Models.Entity;
using SubastasAPI.Repository;
using SubastasAPI.Repository.IRepository;

namespace SubastasAPI.Controllers
{
    public class PujaController : BaseController<PujaEntity,PujaDTO,CreatePujaDTO>
    {
        public PujaController(IPujaRepository PujaRepository,
            IMapper mapper, ILogger<PujaController> logger)
            : base(PujaRepository, mapper, logger)
        {
            _pujaRepository = PujaRepository;
        }
        private readonly IPujaRepository _pujaRepository;
        
        [HttpPost("{productId}/addPuja")]
        public async Task<IActionResult> AddPujaToProduct(int productId, [FromBody] CreatePujaDTO newPujaDto)
        {
            try
            {
                var newPuja = _mapper.Map<PujaEntity>(newPujaDto);
                var success = await _pujaRepository.AddPujaToProduct(productId, newPuja);

                if (!success) return NotFound("Producto no encontrado");

                return Ok(_mapper.Map<PujaDTO>(newPuja));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar la puja al producto");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("top/{productId}")]
        public async Task<IActionResult> GetTopPuja(int productId)
        {
           
                var topPuja = await _pujaRepository.GetTopPuja(productId);

                return Ok(_mapper.Map<PujaDTO>(topPuja));
         
            
        }


    }
}
