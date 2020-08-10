using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IContestantShiftRepository : IRepository<CONTESTANTS_SHIFTS>
    {
    }

    public class ContestantShiftRepository : RepositoryBase<CONTESTANTS_SHIFTS>, IContestantShiftRepository
    {
        public ContestantShiftRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}