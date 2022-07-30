using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using RollForQuirk.Utils;

namespace RollForQuirk.Repositories
{
    public class FlawRepository : BaseRepository, IFlawRepository
    {
        public FlawRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Flaw GetRandom()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 Id, FlawCharacteristic
                                        FROM Flaw
                                        ORDER BY NEWID()";

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var flaw = new Flaw()
                        {
                            Id = DbUtils.GetNullableInt(reader, "Id"),
                            FlawCharacteristic = DbUtils.GetNullableString(reader, "FlawCharacteristic")
                        };

                        return flaw;
                    }
                    return null;
                }
            }
        }
    }
}
