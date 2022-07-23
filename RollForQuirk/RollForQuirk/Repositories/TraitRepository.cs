using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public class TraitRepository : BaseRepository, ITraitRepository
    {
        public TraitRepository(IConfiguration configuration) : base(configuration) { }

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
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CharacterTrait = reader.GetString(reader.GetOrdinal("CharacterTrait"))
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

        public List<Trait> GetCharacterTraits(int id)
        {
            var traitList = new List<Trait>();

            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT t.Id AS TId, CharacterTrait, ct.TraitId, ct.CharacterId
                                        FROM Trait t
                                        JOIN CharacterTrait ct ON TraitId=t.Id
                                        WHERE CharacterId=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Trait trait = new Trait()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("TId")),
                                CharacterTrait = reader.GetString(reader.GetOrdinal("CharacterTrait"))
                            };
                            traitList.Add(trait);
                        }
                    }
                }
            }
                return traitList;
        }

        public int CountTraits()
        { 
            var count = 0;

            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT COUNT(CharacterTrait) FROM Trait";

                    count = (int)cmd.ExecuteScalar();
                }
            }

                return count;
        }

        public List<Trait> GetRandomTraits()
        {
            var traitList = new List<Trait>();

            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 3 Id, CharacterTrait
                                        FROM Trait
                                        ORDER BY NEWID()";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Trait trait = new Trait() 
                            {
                                Id=reader.GetInt32(reader.GetOrdinal("Id")),
                                CharacterTrait = reader.GetString(reader.GetOrdinal("CharacterTrait"))
                            };
                            traitList.Add(trait);
                        }
                    }
                }
            }

                return traitList;
        }
        public void AddTraitsToCharacter(CharacterTrait trait)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO CharacterTrait (TraitId, CharacterId)
                                        OUTPUT INSERTED.ID 
                                        VALUES (@traitId, @characterId)";

                    cmd.Parameters.AddWithValue("@traitId", trait.TraitId);
                    cmd.Parameters.AddWithValue("@characterId", trait.CharacterId);
                    

                    trait.Id = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }
        }

    }


}
