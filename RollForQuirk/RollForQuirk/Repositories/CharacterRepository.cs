using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using System.Collections.Generic;

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
                                               c.AlignmentId, c.UserProfileId,

                                               up.FirebaseId,

                                               r.Id as RaceId, r.CharacterRace,

                                               p.Id as ProfessionId, p.CharacterProfession,

                                               a.Id as AlignmentId, a.CharacterAlignment

                                        FROM Character c
                                        LEFT JOIN UserProfile up ON up.Id = c.UserProfileId
                                        LEFT JOIN Race r ON r.Id = RaceId
                                        LEFT JOIN Profession p ON p.Id = ProfessionId
                                        LEFT JOIN Alignment a ON a.Id = AlignmentId
                                        WHERE up.FirebaseId LIKE @id";

                    cmd.Parameters.AddWithValue("@id", firebaseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {

                            var character = new Character()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CharacterId")),
                                CharacterName = reader.GetString(reader.GetOrdinal("CharacterName")),
                                ProfessionId = reader.GetInt32(reader.GetOrdinal("ProfessionId")),
                                RaceId = reader.GetInt32(reader.GetOrdinal("RaceId")),
                                AlignmentId = reader.GetInt32(reader.GetOrdinal("AlignmentId")),
                                UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                                CharacterRace= new Race() 
                                {
                                    Id=reader.GetInt32(reader.GetOrdinal("RaceId")),
                                    CharacterRace=reader.GetString(reader.GetOrdinal("CharacterRace"))
                                },
                                CharacterProfession=new Profession() 
                                {
                                    Id=reader.GetInt32(reader.GetOrdinal("ProfessionId")),
                                    CharacterProfession=reader.GetString(reader.GetOrdinal("CharacterProfession"))
                                },
                                CharacterAlignment=new Alignment() 
                                {
                                    Id=reader.GetInt32(reader.GetOrdinal("AlignmentId")),
                                    CharacterAlignment=reader.GetString(reader.GetOrdinal("CharacterAlignment"))
                                },
                                Traits = new List<Trait>()
                                
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
                                               c.AlignmentId, c.UserProfileId,

                                               up.FirebaseId,

                                               r.Id as RaceId, r.CharacterRace,

                                               p.Id as ProfessionId, p.CharacterProfession,

                                               a.Id as AlignmentId, a.CharacterAlignment

                                        FROM Character c
                                        LEFT JOIN UserProfile up ON up.Id = c.UserProfileId
                                        LEFT JOIN Race r ON r.Id = RaceId
                                        LEFT JOIN Profession p ON p.Id = ProfessionId
                                        LEFT JOIN Alignment a ON a.Id = AlignmentId
                                        WHERE c.Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var character = new Character()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("CharacterId")),
                            CharacterName = reader.GetString(reader.GetOrdinal("CharacterName")),
                            ProfessionId = reader.GetInt32(reader.GetOrdinal("ProfessionId")),
                            RaceId = reader.GetInt32(reader.GetOrdinal("RaceId")),
                            AlignmentId = reader.GetInt32(reader.GetOrdinal("AlignmentId")),
                            UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                            CharacterRace = new Race()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("RaceId")),
                                CharacterRace = reader.GetString(reader.GetOrdinal("CharacterRace"))
                            },
                            CharacterProfession = new Profession()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ProfessionId")),
                                CharacterProfession = reader.GetString(reader.GetOrdinal("CharacterProfession"))
                            },
                            CharacterAlignment = new Alignment()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("AlignmentId")),
                                CharacterAlignment = reader.GetString(reader.GetOrdinal("CharacterAlignment"))
                            },
                            Traits = new List<Trait>()

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
    }
}
