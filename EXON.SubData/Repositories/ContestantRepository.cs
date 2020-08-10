using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IContestantRepository : IRepository<CONTESTANT>
    {
    }

    public class ContestantRepository : RepositoryBase<CONTESTANT>, IContestantRepository
    {
        public ContestantRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}