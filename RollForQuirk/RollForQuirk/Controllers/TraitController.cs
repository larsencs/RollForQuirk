using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraitController : ControllerBase
    {
        private readonly ITraitRepository _traitRepo;

        public TraitController(ITraitRepository traitRepo)
        {
            _traitRepo = traitRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_traitRepo.GetAllTraits());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            var trait = _traitRepo.GetTraitById(id);

            if (trait == null)
            {
                return NotFound();
            }
            return Ok(trait);
        }
    }
}
