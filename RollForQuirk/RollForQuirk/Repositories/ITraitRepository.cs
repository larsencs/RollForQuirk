using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface ITraitRepository
    {
        List<Trait> GetAllTraits();
        Trait GetTraitById(int id);
    }
}