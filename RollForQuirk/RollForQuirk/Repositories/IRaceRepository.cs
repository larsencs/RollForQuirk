using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface IRaceRepository
    {
        List<Race> GetAllRaces();
        Race GetRaceById(int id);
    }
}