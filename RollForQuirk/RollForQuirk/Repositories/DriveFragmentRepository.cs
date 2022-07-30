using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using RollForQuirk.Utils;

namespace RollForQuirk.Repositories
{
    public class DriveFragmentRepository : BaseRepository, IDriveFragmentRepository
    {
        public DriveFragmentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public DriveFragment GetRandom()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 Id, FragmentOne, FragmentTwo
                                        FROM DriveFragment
                                        ORDER BY NEWID()";

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var driveFragment = new DriveFragment()
                        {
                            Id = DbUtils.GetNullableInt(reader, "Id"),
                            FragmentOne = DbUtils.GetNullableString(reader, "FragmentOne"),
                            FragmentTwo = DbUtils.GetNullableString(reader, "FragmentTwo")
                        };

                        return driveFragment;
                    }
                    return null;
                }
            }
        }
    }
}
