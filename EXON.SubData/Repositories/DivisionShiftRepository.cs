using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IDivisionShiftRepository : IRepository<DIVISION_SHIFTS>
    {
    }

    public class DivisionShiftRepository : RepositoryBase<DIVISION_SHIFTS>, IDivisionShiftRepository
    {
        public DivisionShiftRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}