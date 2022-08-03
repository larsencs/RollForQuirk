using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface IQuirkFragmentRepository
    {
        List<QuirkFragment> GetRandom(int index);
    }
}