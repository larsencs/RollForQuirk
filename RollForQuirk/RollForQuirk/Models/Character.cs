using System.Collections.Generic;

namespace RollForQuirk.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public int ProfessionId { get; set; }
        public int RaceId { get; set; }
        public int AlignmentId { get; set; }
        public int UserProfileId { get; set; }

        public List<Trait> Traits { get; set; }
        public Race CharacterRace { get; set; }
        public Alignment CharacterAlignment { get; set; }
        public Profession CharacterProfession { get; set; }

    }
}
