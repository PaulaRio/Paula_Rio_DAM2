

using AgularAPI.Models.DTOs;
using AngularAPI.Controllers.AngularAPI.Controllers;
using AngularAPI.Models.Entity;
using AngularAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : BaseController<HouseEntity, HouseDTO, CreateHouseDTO>
    {
        public HouseController(IHouseRepository HouseRepository,
            IMapper mapper, ILogger<HouseController> logger)
            : base(HouseRepository, mapper, logger)
        {

        }
    }
}
