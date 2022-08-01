using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface IQuirkRepository
    {
        List<Quirk> GetRandom();
        List<Quirk> GetTwoRandom();
    }
}