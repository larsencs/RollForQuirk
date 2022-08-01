using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StressController : ControllerBase
    {
        private readonly IStressRepository _stressRepository;

        public StressController(IStressRepository stressRepository)
        {
            this._stressRepository = stressRepository;
        }

        [HttpGet]
        public IActionResult GetRandom()
        {
            var stress = _stressRepository.GetRandom();

            return Ok(stress);
        }
    }
}
