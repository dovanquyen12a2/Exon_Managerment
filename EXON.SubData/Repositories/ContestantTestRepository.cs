using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IContestantTestRepository : IRepository<CONTESTANTS_TESTS>

    {
    }

    public class ContestantTestRepository : RepositoryBase<CONTESTANTS_TESTS>, IContestantTestRepository
    {
        public ContestantTestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}