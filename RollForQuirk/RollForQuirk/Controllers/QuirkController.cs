using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Models;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuirkController : ControllerBase
    {
        private readonly IQuirkFragmentRepository _quirkFragmentRepository;
        private readonly IQuirkRepository _quirkRepository;

        public QuirkController(IQuirkFragmentRepository quirkFragmentRepository, IQuirkRepository quirkRepository)
        {
            _quirkFragmentRepository = quirkFragmentRepository;
            _quirkRepository = quirkRepository;
        }

        [HttpGet]
        public IActionResult GetRandom()
        {
            var quirk = _quirkRepository.GetRandom();

            return Ok(quirk);
        }

        [HttpGet("[action]")]
        public IActionResult GetTwoRandom()
        { 
            var quirks = _quirkRepository.GetTwoRandom();

            return Ok(quirks);
        }

        [HttpGet("[action]/{index}")]
        public IActionResult GetMultiple(int index)
        {
            var quirks = _quirkRepository.GetMultipleQuirks(index);

            return Ok(quirks);
        }
    }
}
