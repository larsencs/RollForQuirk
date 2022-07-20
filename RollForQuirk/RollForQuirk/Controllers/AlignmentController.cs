using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlignmentController : ControllerBase
    {
        private readonly IAlignmentRepository _alignmentRepo;

        public AlignmentController(IAlignmentRepository alignmentRepo)
        {
            _alignmentRepo = alignmentRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_alignmentRepo.GetAllAlignments());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var alignment = _alignmentRepo.GetAlignmentById(id);

            if (alignment == null)
            {
                return NotFound();
            }
            return Ok(alignment);
        }

    }
}
