using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using RollForQuirk.Utils;

namespace RollForQuirk.Repositories
{
    public class FearRepository : BaseRepository, IFearRepository
    {
        public FearRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Fear GetRandom()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 Id, FearCharacteristic
                                        FROM Fear
                                        ORDER BY NEWID()";

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var fear = new Fear()
                        {
                            Id = DbUtils.GetNullableInt(reader, "Id"),
                            FearCharacteristic = DbUtils.GetNullableString(reader, "FearCharacteristic")
                        };

                        return fear;
                    }
                    return null;
                }
            }
        }
    }
}
