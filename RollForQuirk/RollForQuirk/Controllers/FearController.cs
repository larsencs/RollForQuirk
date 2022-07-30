using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FearController : ControllerBase
    {
        private readonly IFearRepository _fearRepository;

        public FearController(IFearRepository fearRepository)
        {
            _fearRepository = fearRepository;
        }

        [HttpGet]
        public IActionResult GetRandom()
        { 
            var fear = _fearRepository.GetRandom();

            return Ok(fear);
        }
    }
}
