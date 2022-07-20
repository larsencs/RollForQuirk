using Microsoft.Extensions.Configuration;
using RollForQuirk.Models;

namespace RollForQuirk.Repositories
{
    public class UserProfileRepository : BaseRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public UserProfile GetByFirebaseId(string firebaseId)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Email, FirebaseId
                                        FROM UserProfile
                                        WHERE FirebaseId = @id";

                    cmd.Parameters.AddWithValue("@id", firebaseId);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    { 
                        var userProfile = new UserProfile() 
                        {
                            Id=reader.GetInt32(reader.GetOrdinal("Id")),
                            Email=reader.GetString(reader.GetOrdinal("Email")),
                            FirebaseId=reader.GetString(reader.GetOrdinal("FirebaseId"))
                        };

                        return userProfile;
                    }
                    return null;
                }
            }
        }
    }
}
