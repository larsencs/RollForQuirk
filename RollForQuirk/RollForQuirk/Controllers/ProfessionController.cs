using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        private readonly IProfessionRepository _profRepo;

        public ProfessionController(IProfessionRepository profRepo)
        {
            _profRepo = profRepo;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_profRepo.GetAllProfessions());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var profession = _profRepo.GetProfessionById(id);

            if (profession == null)
            {
                return NotFound();
            }

            return Ok(profession);
        }
    }
}
