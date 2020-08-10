using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IAnswersheetSpeakingRepository : IRepository<ANSWERSHEET_SPEAKING>
    {
    }

    public class AnswersheetSpeakingRepository : RepositoryBase<ANSWERSHEET_SPEAKING>, IAnswersheetSpeakingRepository
    {
        public AnswersheetSpeakingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}