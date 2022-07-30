using RollForQuirk.Models;

namespace RollForQuirk.Repositories
{
    public interface IQuirkFragmentRepository
    {
        QuirkFragment GetRandom();
    }
}