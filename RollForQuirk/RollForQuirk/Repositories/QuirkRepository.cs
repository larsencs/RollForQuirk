using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using RollForQuirk.Utils;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public class QuirkRepository : BaseRepository, IQuirkRepository
    {
        public QuirkRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Quirk> GetRandom()
        {
            var quirks = new List<Quirk>();
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 Id, CharacterQuirk
                                        FROM Quirk
                                        ORDER BY NEWID()";


                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var quirk = new Quirk()
                            {
                                Id = DbUtils.GetNullableInt(reader, "Id"),
                                CharacterQuirk = DbUtils.GetNullableString(reader, "CharacterQuirk")
                            };

                            quirks.Add(quirk);
                        }
                    }
                }
            }
            return quirks;
        }

        public List<Quirk> GetTwoRandom()
        {
            var quirks = new List<Quirk>();
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 2 Id, CharacterQuirk
                                        FROM Quirk
                                        ORDER BY NEWID()";


                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var quirk = new Quirk()
                            {
                                Id = DbUtils.GetNullableInt(reader, "Id"),
                                CharacterQuirk = DbUtils.GetNullableString(reader, "CharacterQuirk")
                            };

                            quirks.Add(quirk);
                        }
                    }
                }
            }
            return quirks;
        }

        public List<Quirk> GetMultipleQuirks(int index)
        { 
            var quirks = new List<Quirk>();

            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP (@num) Id, CharacterQuirk
                                        FROM Quirk
                                        ORDER BY NEWID()";

                    cmd.Parameters.AddWithValue("@num", index);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var quirk = new Quirk()
                            {
                                Id = DbUtils.GetNullableInt(reader, "Id"),
                                CharacterQuirk = DbUtils.GetNullableString(reader, "CharacterQuirk")
                            };

                            quirks.Add(quirk);
                        }
                    }

                }

                
            }

                return quirks;
        }

    }


}

