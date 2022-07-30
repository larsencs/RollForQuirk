using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using System.Collections.Generic;
using RollForQuirk.Utils;

namespace RollForQuirk.Repositories
{
    public class DriveRepository : BaseRepository, IDriveRepository
    {
        public DriveRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Drive GetRandom()
        {
            
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 Id, DriveTrait
                                        FROM Drive
                                        ORDER BY NEWID()";

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var drive = new Drive()
                            {
                                Id = DbUtils.GetNullableInt(reader, "Id"),
                                DriveTrait = DbUtils.GetNullableString(reader, "DriveTrait")
                            };
                            return drive;
                            
                        }
                        return null;
                    }
                }
            }
            

        }
    }
}
