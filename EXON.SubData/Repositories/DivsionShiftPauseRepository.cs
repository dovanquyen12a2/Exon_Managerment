using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IDivsionShiftPauseRepository : IRepository<DIVSIONSHIFT_PAUSE>
    {

    }

    public class DivsionShiftPauseRepository : RepositoryBase<DIVSIONSHIFT_PAUSE>, IDivsionShiftPauseRepository
    {
        public DivsionShiftPauseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}