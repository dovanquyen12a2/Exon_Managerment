using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IAnswersheetDetailRepository : IRepository<ANSWERSHEET_DETAILS>
    {
        
    }

    public class AnswersheetDetailRepository : RepositoryBase<ANSWERSHEET_DETAILS>, IAnswersheetDetailRepository
    {
        public AnswersheetDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}