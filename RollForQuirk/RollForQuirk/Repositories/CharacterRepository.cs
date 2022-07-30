using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using System.Collections.Generic;
using RollForQuirk.Utils;

namespace RollForQuirk.Repositories
{
    public class CharacterRepository : BaseRepository, ICharacterRepository
    {
        public CharacterRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Character> GetCharactersByUser(string firebaseId)
        {
            var characterList = new List<Character>();

            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id AS CharacterId, c.CharacterName, c.ProfessionId, c.RaceId,
                                               c.AlignmentId, c.UserProfileId, c.FlawId, c.FearId, c.StressId,
                                               c.CharacterDrive, c.QuirkOne, c.QuirkTwo, c.QuirkThree

                                               up.FirebaseId,

                                               r.Id as RaceId, r.CharacterRace,

                                               p.Id as ProfessionId, p.CharacterProfession,

                                               a.Id as AlignmentId, a.CharacterAlignment,
                                        
                                               fe.Id AS fearId, fe.FearCharacteristic,

                                               fl.Id as flawId, fl.FlawCharacteristic,

                                               st.Id as stressId, st.StressedCharacteristic

                                        FROM Character c
                                        LEFT JOIN UserProfile up ON up.Id = c.UserProfileId
                                        LEFT JOIN Race r ON r.Id = RaceId
                                        LEFT JOIN Profession p ON p.Id = ProfessionId
                                        LEFT JOIN Alignment a ON a.Id = AlignmentId
                                        LEFT JOIN Fear fe ON fe.Id = FearId
                                        LEFT JOIN Flaw fl ON fl.Id = FlawId
                                        LEFT JOIN Stress st ON st.Id = StressId
                                        WHERE up.FirebaseId LIKE @id
                                        ORDER BY c.Id DESC";

                    cmd.Parameters.AddWithValue("@id", firebaseId);

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            var character = new Character()
                            {
                                Id = DbUtils.GetNullableInt(reader, "CharacterId"),
                                CharacterName = DbUtils.GetNullableString(reader, "CharacterName"),
                                ProfessionId = DbUtils.GetNullableInt(reader, "ProfessionId"),
                                RaceId = DbUtils.GetNullableInt(reader, "RaceId"),
                                AlignmentId = DbUtils.GetNullableInt(reader, "AlignmentId"),
                                UserProfileId = DbUtils.GetNullableInt(reader, "UserProfileId"),
                                FlawId = DbUtils.GetNullableInt(reader, "FlawId"),
                                FearId = DbUtils.GetNullableInt(reader, "FearId"),
                                StressId = DbUtils.GetNullableInt(reader, "StressId"),
                                CharacterRace = new Race()
                                {
                                    Id = DbUtils.GetNullableInt(reader, "raceId"),
                                    CharacterRace = DbUtils.GetNullableString(reader, "CharacterRace")
                                },
                                CharacterAlignment = new Alignment()
                                {
                                    Id = DbUtils.GetNullableInt(reader, "alignmentId"),
                                    CharacterAlignment = DbUtils.GetNullableString(reader, "CharacterAlignment")
                                },
                                CharacterProfession = new Profession()
                                {
                                    Id = DbUtils.GetNullableInt(reader, "professionId"),
                                    CharacterProfession = DbUtils.GetNullableString(reader, "CharacterProfession")
                                },
                                Fear = new Fear()
                                {
                                    Id = DbUtils.GetNullableInt(reader, "fearId"),
                                    FearCharacteristic = DbUtils.GetNullableString(reader, "FearCharacteristic")
                                },
                                Flaw = new Flaw()
                                {
                                    Id = DbUtils.GetNullableInt(reader, "flawId"),
                                    FlawCharacteristic = DbUtils.GetNullableString(reader, "FlawCharacteristic")
                                },
                                Stress = new Stress()
                                {
                                    Id = DbUtils.GetNullableInt(reader, "stressId"),
                                    StressedCharacteristic = DbUtils.GetNullableString(reader, "StressedCharacteristic")
                                }

                            };

                            characterList.Add(character);
                        }
                    }

                }
            }

            return characterList;
        }

        public Character GetByCharacterId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id AS CharacterId, c.CharacterName, c.ProfessionId, c.RaceId,
                                               c.AlignmentId, c.UserProfileId, c.FlawId, c.FearId, c.StressId,
                                               c.CharacterDrive, c.QuirkOne, c.QuirkTwo, c.QuirkThree

                                               up.FirebaseId,

                                               r.Id as RaceId, r.CharacterRace,

                                               p.Id as ProfessionId, p.CharacterProfession,

                                               a.Id as AlignmentId, a.CharacterAlignment,
                                        
                                               fe.Id AS fearId, fe.FearCharacteristic,

                                               fl.Id as flawId, fl.FlawCharacteristic,

                                               st.Id as stressId, st.StressedCharacteristic

                                        FROM Character c
                                        LEFT JOIN UserProfile up ON up.Id = c.UserProfileId
                                        LEFT JOIN Race r ON r.Id = RaceId
                                        LEFT JOIN Profession p ON p.Id = ProfessionId
                                        LEFT JOIN Alignment a ON a.Id = AlignmentId
                                        LEFT JOIN Fear fe ON fe.Id = FearId
                                        LEFT JOIN Flaw fl ON fl.Id = FlawId
                                        LEFT JOIN Stress st ON st.Id = StressId
                                        WHERE c.Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var character = new Character()
                        {
                            Id = DbUtils.GetNullableInt(reader, "CharacterId"),
                            CharacterName = DbUtils.GetNullableString(reader, "CharacterName"),
                            ProfessionId = DbUtils.GetNullableInt(reader, "ProfessionId"),
                            RaceId = DbUtils.GetNullableInt(reader, "RaceId"),
                            AlignmentId = DbUtils.GetNullableInt(reader, "AlignmentId"),
                            UserProfileId = DbUtils.GetNullableInt(reader, "UserProfileId"),
                            FlawId = DbUtils.GetNullableInt(reader, "FlawId"),
                            FearId = DbUtils.GetNullableInt(reader, "FearId"),
                            StressId = DbUtils.GetNullableInt(reader, "StressId"),
                            CharacterRace = new Race()
                            {
                                Id = DbUtils.GetNullableInt(reader, "raceId"),
                                CharacterRace = DbUtils.GetNullableString(reader, "CharacterRace")
                            },
                            CharacterAlignment = new Alignment()
                            {
                                Id = DbUtils.GetNullableInt(reader, "alignmentId"),
                                CharacterAlignment = DbUtils.GetNullableString(reader, "CharacterAlignment")
                            },
                            CharacterProfession = new Profession()
                            {
                                Id = DbUtils.GetNullableInt(reader, "professionId"),
                                CharacterProfession = DbUtils.GetNullableString(reader, "CharacterProfession")
                            },
                            Fear = new Fear()
                            {
                                Id = DbUtils.GetNullableInt(reader, "fearId"),
                                FearCharacteristic = DbUtils.GetNullableString(reader, "FearCharacteristic")
                            },
                            Flaw = new Flaw()
                            {
                                Id = DbUtils.GetNullableInt(reader, "flawId"),
                                FlawCharacteristic = DbUtils.GetNullableString(reader, "FlawCharacteristic")
                            },
                            Stress = new Stress()
                            {
                                Id = DbUtils.GetNullableInt(reader, "stressId"),
                                StressedCharacteristic = DbUtils.GetNullableString(reader, "StressedCharacteristic")
                            }

                        };

                        return character;
                    }
                    return null;

                }
            }
        }

        public void AddCharacter(Character character)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Character (CharacterName, ProfessionId, RaceId, AlignmentId, UserProfileId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@character, @prof, @race, @align, @user)";

                    cmd.Parameters.AddWithValue("@character", character.CharacterName);
                    cmd.Parameters.AddWithValue("@prof", character.ProfessionId);
                    cmd.Parameters.AddWithValue("@race", character.RaceId);
                    cmd.Parameters.AddWithValue("@align", character.AlignmentId);
                    cmd.Parameters.AddWithValue("@user", character.UserProfileId);

                    character.Id = (int)cmd.ExecuteScalar();
                }

                conn.Close();
            }
        }

        public void EditCharacter(Character character)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Character
                                        SET CharacterName=@charName
                                        WHERE Id=@id";

                    cmd.Parameters.AddWithValue("@id", character.Id);
                    cmd.Parameters.AddWithValue("@charName", character.CharacterName);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Character
                                        WHERE Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
