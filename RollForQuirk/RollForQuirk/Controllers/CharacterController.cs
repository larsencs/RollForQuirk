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
        private readonly ITraitRepository _traitRepo;

        public CharacterController(ICharacterRepository charRepo, ITraitRepository traitRepo)
        {
            _charRepo = charRepo;
            _traitRepo = traitRepo;
        }

        [HttpGet("{firebaseId}")]
        public IActionResult GetByUser(string firebaseId)
        {
            var character = _charRepo.GetCharactersByUser(firebaseId);

            foreach(var c in character)
            {
                var traits = _traitRepo.GetCharacterTraits(c.Id);
                c.Traits = traits;
            }
            


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
            character.Traits = _traitRepo.GetCharacterTraits(id);

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
    }
}
