using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IAnswersheetRepository : IRepository<ANSWERSHEET>
    {
    }

    public class AnswersheetRepository : RepositoryBase<ANSWERSHEET>, IAnswersheetRepository
    {
        public AnswersheetRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}