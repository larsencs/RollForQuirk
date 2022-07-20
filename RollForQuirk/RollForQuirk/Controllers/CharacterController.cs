using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _charRepo;

        public CharacterController(ICharacterRepository charRepo)
        {
            _charRepo = charRepo;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetByUser(int id)
        {
            var character = _charRepo.GetCharactersByUser(id);

            if (character == null)
            { 
                return NotFound();
            }

            return Ok(character);
        }
    }
}
