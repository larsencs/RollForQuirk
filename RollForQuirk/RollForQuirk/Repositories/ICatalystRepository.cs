using RollForQuirk.Models;

namespace RollForQuirk.Repositories
{
    public interface ICatalystRepository
    {
        Catalyst GetRandom();
    }
}