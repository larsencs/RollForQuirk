using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface ICharacterRepository
    {
        void AddCharacter(Character character);
        void EditCharacter(Character character);
        Character GetByCharacterId(int id);
        List<Character> GetCharactersByUser(string firebaseId);
    }
}