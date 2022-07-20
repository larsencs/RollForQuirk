using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface ICharacterRepository
    {
        List<Character> GetCharactersByUser(int id);
    }
}