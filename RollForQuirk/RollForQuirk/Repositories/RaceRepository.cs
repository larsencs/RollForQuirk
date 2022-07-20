using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public class RaceRepository : BaseRepository
    {
        public RaceRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Profession> GetAllProfessions()
        { 
            var professions = new List<Profession>();

            using (var conn = Connection)
            { 
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, CharacterProfession
                                        FROM Profession";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var profession = new Profession() 
                            {
                                Id=reader.GetInt32(reader.GetOrdinal("Id")),
                                CharacterProfession=reader.GetString(reader.GetOrdinal("CharacterProfession"))
                            };

                            professions.Add(profession);
                        }
                    }
                }
            }

                return professions;
        }

        public Profession GetProfessionById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, CharacterProfession
                                        FROM Profession
                                        WHERE Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);


                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    { 
                        var profession = new Profession() 
                        {
                            Id=reader.GetInt32(reader.GetOrdinal("Id")),
                            CharacterProfession=reader.GetString(reader.GetOrdinal("CharacterProfession"))
                        };

                        return profession;
                    }
                    return null;
                }
            }
        }
    }
}
