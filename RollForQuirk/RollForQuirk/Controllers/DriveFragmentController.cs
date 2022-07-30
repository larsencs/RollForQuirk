using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriveFragmentController : ControllerBase
    {
        private readonly IDriveFragmentRepository _driveFragmentRepository;

        public DriveFragmentController(IDriveFragmentRepository driveFragmentRepository)
        {
            _driveFragmentRepository = driveFragmentRepository;
        }

        [HttpGet]
        public IActionResult GetRandom()
        {
            var fragments = _driveFragmentRepository.GetRandom();

            return Ok(fragments);
        }
    }
}
