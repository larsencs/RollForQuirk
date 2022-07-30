using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RollForQuirk.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter a name")]
        public string CharacterName { get; set; }
        [Required(ErrorMessage ="Choose a class")]
        public int ProfessionId { get; set; }
        [Required(ErrorMessage ="Choose a race")]
        public int RaceId { get; set; }
        [Required(ErrorMessage ="Choose an alignment")]
        public int AlignmentId { get; set; }
        [Required]
        public int UserProfileId { get; set; }

        public int StressId { get; set; }
        public int FearId { get; set; }
        public int FlawId { get; set; }

        public string CharacterDrive { get; set; }
        public string QuirkOne { get; set; }
        public string QuirkTwo { get; set; }
        public string QuirkThree { get; set; }

        public Race CharacterRace { get; set; }
        public Alignment CharacterAlignment { get; set; }
        public Profession CharacterProfession { get; set; }

        public Fear Fear { get; set; }
        public Stress Stress { get; set; }
        public Flaw Flaw { get; set; }



    }
}
