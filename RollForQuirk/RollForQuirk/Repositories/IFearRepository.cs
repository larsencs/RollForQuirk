using RollForQuirk.Models;

namespace RollForQuirk.Repositories
{
    public interface IFearRepository
    {
        Fear GetRandom();
    }
}