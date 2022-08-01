using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlawController : ControllerBase
    {

        private readonly IFlawRepository _flawRepository;

        public FlawController(IFlawRepository flawRepository)
        {
            _flawRepository = flawRepository;
        }

        [HttpGet]
        public IActionResult GetRandom()
        {
            var flaw = _flawRepository.GetRandom();

            return Ok(flaw);
        }
    }
}
