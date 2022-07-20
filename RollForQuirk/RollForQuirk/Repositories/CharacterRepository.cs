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

        public List<Character> GetCharactersByUser(int id)
        {
            var characterList = new List<Character>();

            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, CharacterName, ProfessionId, RaceId,
                                               AlignmentId, UserProfileId
                                        FROM Character
                                        WHERE Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var character = new Character()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CharacterName = reader.GetString(reader.GetOrdinal("CharacterName")),
                                ProfessionId = reader.GetInt32(reader.GetOrdinal("ProfessionId")),
                                RaceId = reader.GetInt32(reader.GetOrdinal("RaceId")),
                                AlignmentId = reader.GetInt32(reader.GetOrdinal("AlignmentId")),
                                UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId"))
                            };
                            characterList.Add(character);
                        }
                    }

                }
            }

            return characterList;
        }
    }
}
