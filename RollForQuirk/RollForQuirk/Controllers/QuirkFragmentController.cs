using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuirkFragmentController : ControllerBase
    {
        private readonly IQuirkFragmentRepository _quirkFragmentRepository;

        public QuirkFragmentController(IQuirkFragmentRepository quirkFragmentRepository)
        {
            this._quirkFragmentRepository = quirkFragmentRepository;
        }

        [HttpGet("{index}")]
        public IActionResult GetRandom(int index)
        { 
            var fragment = _quirkFragmentRepository.GetRandom(index);
            return Ok(fragment);
        }
    }
}
