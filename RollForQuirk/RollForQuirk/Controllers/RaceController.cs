using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {

        private readonly IRaceRepository _raceRepo;

        public RaceController(IRaceRepository raceRepo)
        {
            _raceRepo = raceRepo;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_raceRepo.GetAllRaces());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            var race = _raceRepo.GetRaceById(id);

            if (race == null)
            {
                return NotFound();
            }

              return Ok(race);
        }
    }
}
