using RollForQuirk.Models;

namespace RollForQuirk.Repositories
{
    public interface IFlawRepository
    {
        Flaw GetRandom();
    }
}