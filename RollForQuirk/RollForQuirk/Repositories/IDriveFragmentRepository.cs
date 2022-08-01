using RollForQuirk.Models;

namespace RollForQuirk.Repositories
{
    public interface IDriveFragmentRepository
    {
        DriveFragment GetRandom();
    }
}