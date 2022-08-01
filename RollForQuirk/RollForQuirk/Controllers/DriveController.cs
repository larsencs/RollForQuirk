using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollForQuirk.Repositories;

namespace RollForQuirk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriveController : ControllerBase
    {
        private readonly IDriveRepository _driveRepository;

        public DriveController(IDriveRepository driveRepository)
        {
            _driveRepository = driveRepository;
        }
        [HttpGet]
        public IActionResult GetRandom()
        { 
            var drive = _driveRepository.GetRandom();

            return Ok(drive);
        }
    }
}
