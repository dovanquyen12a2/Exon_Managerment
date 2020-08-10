using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IShiftPauseRepository : IRepository<SHIFTSPAUSE>
    {

    }

    public class ShiftPauseRepository : RepositoryBase<SHIFTSPAUSE>, IShiftPauseRepository
    {
        public  ShiftPauseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}