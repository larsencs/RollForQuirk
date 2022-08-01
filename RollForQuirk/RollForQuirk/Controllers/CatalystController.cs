using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalystController : ControllerBase
    {

        private readonly ICatalystRepository _catalystRepository;

        public CatalystController(ICatalystRepository catalystRepository)
        {
            _catalystRepository = catalystRepository;
        }

        [HttpGet]
        public IActionResult GetRandom()
        { 
            var catalyst = _catalystRepository.GetRandom();

            return Ok(catalyst);
        }
    }
}
