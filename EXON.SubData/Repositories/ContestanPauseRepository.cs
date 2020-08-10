using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IContestanPauseRepository : IRepository<CONTESTANTPAUSE>
    {

    }

    public class ContestanPauseRepository : RepositoryBase<CONTESTANTPAUSE>, IContestanPauseRepository
    {
        public ContestanPauseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}