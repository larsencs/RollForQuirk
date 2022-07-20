using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface IProfessionRepository
    {
        List<Profession> GetAllProfessions();
        Profession GetProfessionById(int id);
    }
}