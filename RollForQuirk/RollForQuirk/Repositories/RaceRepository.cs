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

        public List<Race> GetAllRaces()
        { 
            var races = new List<Race>();

            using (var conn = Connection)
            { 
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, CharacterRace
                                        FROM Race";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var race = new Race() 
                            {
                                Id=reader.GetInt32(reader.GetOrdinal("Id")),
                                CharacterRace=reader.GetString(reader.GetOrdinal("CharacterRace"))
                            };

                            races.Add(race);
                        }
                    }
                }
            }

                return races;
        }

        public Race GetRaceById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, CharacterRace
                                        FROM Race
                                        WHERE Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);


                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    { 
                        var race = new Race() 
                        {
                            Id=reader.GetInt32(reader.GetOrdinal("Id")),
                            CharacterRace=reader.GetString(reader.GetOrdinal("CharacterRace"))
                        };

                        return race;
                    }
                    return null;
                }
            }
        }
    }
}
