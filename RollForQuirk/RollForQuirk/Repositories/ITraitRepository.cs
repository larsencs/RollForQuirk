using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface ITraitRepository
    {
        void AddTraitsToCharacter(CharacterTrait trait);
        int CountTraits();
        List<Trait> GetAllTraits();
        List<Trait> GetCharacterTraits(int id);
        List<Trait> GetRandomTraits();
        Trait GetTraitById(int id);
    }
}