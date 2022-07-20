using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public class TraitRepository : BaseRepository
    {
        public TraitRepository(IConfiguration configuration) : base(configuration){}

        public List<Trait> GetAllTraits()
        {
            List<Trait> traits = new List<Trait>();
            using (var conn = Connection)
            { 
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, CharacterTrait
                                        FROM Trait";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Trait trait = new Trait() 
                            {
                                Id=reader.GetInt32(reader.GetOrdinal("Id")),
                                CharacterTrait=reader.GetString(reader.GetOrdinal("CharacterTrait"))
                            };
                            traits.Add(trait);
                        }
                    }
                }
            }
            return traits;
        }

        public Trait GetTraitById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, CharacterTrait
                                        FROM Trait
                                        WHERE Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var trait = new Trait() 
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            CharacterTrait = reader.GetString(reader.GetOrdinal("CharacterTrait"))
                        };

                        return trait;
                    }
                    return null;
                }
        }
        }
    }

}
