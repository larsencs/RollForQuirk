using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using RollForQuirk.Utils;

namespace RollForQuirk.Repositories
{
    public class CatalystRepository : BaseRepository, ICatalystRepository
    {
        public CatalystRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Catalyst GetRandom()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 Id, DriveCatalyst
                                        FROM Catalyst
                                        ORDER BY NEWID()";

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var catalyst = new Catalyst()
                        {
                            Id = DbUtils.GetNullableInt(reader, "Id"),
                            DriveCatalyst = DbUtils.GetNullableString(reader, "DriveCatalyst")
                        };

                        return catalyst;
                    }
                    return null;
                }
            }
        }
    }
}
