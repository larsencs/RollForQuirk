using RollForQuirk.Models;
using System.Collections.Generic;

namespace RollForQuirk.Repositories
{
    public interface IAlignmentRepository
    {
        Alignment GetAlignmentById(int id);
        List<Alignment> GetAllAlignments();
    }
}