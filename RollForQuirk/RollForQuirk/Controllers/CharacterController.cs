using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Models;
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

        [HttpGet("[action]/{id}")]
        public IActionResult GetByCharacterId(int id)
        { 
            var character = _charRepo.GetByCharacterId(id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);

        }

        [HttpPost]
        public IActionResult AddCharacter(Character character)
        { 
            _charRepo.AddCharacter(character);

            return Ok(character);
        }

        [HttpPut("{id}")]
        public IActionResult EditCharacter(Character character, int id)
        {
            if (character.Id != id)
            {
                return BadRequest();
            }
            _charRepo.EditCharacter(character);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete( int id)
        {
    
            _charRepo.Delete(id);
            return NoContent();
        }
    }
}
