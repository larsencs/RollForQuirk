using RollForQuirk.Models;

namespace RollForQuirk.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetByFirebaseId(string firebaseId);
    }
}