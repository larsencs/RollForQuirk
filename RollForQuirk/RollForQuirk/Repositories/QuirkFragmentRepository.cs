using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using RollForQuirk.Utils;

namespace RollForQuirk.Repositories
{
    public class QuirkFragmentRepository : BaseRepository, IQuirkFragmentRepository
    {
        public QuirkFragmentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public QuirkFragment GetRandom()
        {


            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 Id, FragmentOne, FragmentTwo
                                        FROM QuirkFragment
                                        ORDER BY NEWID()";

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var quirkFragment = new QuirkFragment()
                        {
                            Id = DbUtils.GetNullableInt(reader, "Id"),
                            FragmentOne = DbUtils.GetNullableString(reader, "FragmentOne"),
                            FragmentTwo = DbUtils.GetNullableString(reader, "FragmentTwo")
                        };
                        return quirkFragment;
                    }
                    return null;
                }
            }


        }
    }
}
