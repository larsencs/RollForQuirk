using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using RollForQuirk.Utils;

namespace RollForQuirk.Repositories
{
    public class StressRepository : BaseRepository, IStressRepository
    {
        public StressRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Stress GetRandom()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 Id, StressedCharacteristic
                                        FROM Stress
                                        ORDER BY NEWID()";

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var stress = new Stress()
                        {
                            Id = DbUtils.GetNullableInt(reader, "Id"),
                            StressedCharacteristic = DbUtils.GetNullableString(reader, "StressedCharacteristic")
                        };

                        return stress;
                    }
                    return null;
                }
            }
        }
    }
}
