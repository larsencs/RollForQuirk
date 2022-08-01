using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface IDriveRepository
    {
        Drive GetRandom();
    }
}