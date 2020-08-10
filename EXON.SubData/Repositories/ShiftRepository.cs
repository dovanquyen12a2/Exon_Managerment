using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IShiftRepository : IRepository<SHIFT>
    {
    }

    public class ShiftRepository : RepositoryBase<SHIFT>, IShiftRepository
    {
        public ShiftRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}