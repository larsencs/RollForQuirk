using RollForQuirk.Models;

namespace RollForQuirk.Repositories
{
    public interface IStressRepository
    {
        Stress GetRandom();
    }
}