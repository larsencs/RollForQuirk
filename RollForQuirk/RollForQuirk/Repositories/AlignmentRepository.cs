using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public class AlignmentRepository : BaseRepository
    {
        public AlignmentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Alignment> GetAllAlignments()
        {
            var alignments = new List<Alignment>();

            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, CharacterAlignment
                                        FROM Alignment";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var alignment = new Alignment() 
                            
                            {
                                Id=reader.GetInt32(reader.GetOrdinal("Id")),
                                CharacterAlignment=reader.GetString(reader.GetOrdinal("CharacterAlignment"))
                            };
                            alignments.Add(alignment);
                        }
                    }
                }
            }

                return alignments;
        }

        public Alignment GetAlignmentById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, CharacterAlignment
                                        FROM Alignment
                                        WHERE Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var alignment = new Alignment() 
                        {
                            Id=reader.GetInt32(reader.GetOrdinal("Id")),
                            CharacterAlignment=reader.GetString(reader.GetOrdinal("CharacterAlignment"))
                        };

                        return alignment;
                    }
                    return null;
                }
            }
        }
    }
}
