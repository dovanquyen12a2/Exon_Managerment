using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IAnswersheetWritingRepository : IRepository<ANSWERSHEET_WRITING>
    {
    }

    public class AnswersheetWritingRepository : RepositoryBase<ANSWERSHEET_WRITING>, IAnswersheetWritingRepository
    {
        public AnswersheetWritingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}