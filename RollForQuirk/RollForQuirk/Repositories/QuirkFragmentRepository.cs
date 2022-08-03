using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;
using RollForQuirk.Utils;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public class QuirkFragmentRepository : BaseRepository, IQuirkFragmentRepository
    {
        public QuirkFragmentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<QuirkFragment> GetRandom(int index)
        {
            var quirkList = new List<QuirkFragment>();

            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP (@index) Id, FragmentOne, FragmentTwo
                                        FROM QuirkFragment
                                        ORDER BY NEWID()";

                    cmd.Parameters.AddWithValue("@index", index);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var quirkFragment = new QuirkFragment()
                            {
                                Id = DbUtils.GetNullableInt(reader, "Id"),
                                FragmentOne = DbUtils.GetNullableString(reader, "FragmentOne"),
                                FragmentTwo = DbUtils.GetNullableString(reader, "FragmentTwo")
                            };
                            quirkList.Add(quirkFragment);
                        }
                    }

                }
            }

            return quirkList;


        }
    }
}
