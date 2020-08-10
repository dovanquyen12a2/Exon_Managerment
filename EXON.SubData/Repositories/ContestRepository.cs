using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IContestRepository : IRepository<CONTEST>
    {
    }

    public class ContestRepository : RepositoryBase<CONTEST>, IContestRepository
    {
        public ContestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}