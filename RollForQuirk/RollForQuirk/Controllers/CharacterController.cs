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
        
        [HttpGet("{firebaseId}")]
        public IActionResult GetByUser(string firebaseId)
        {
            var character = _charRepo.GetCharactersByUser(firebaseId);

            if (character == null)
            { 
                return NotFound();
            }

            return Ok(character);
        }
    }
}
