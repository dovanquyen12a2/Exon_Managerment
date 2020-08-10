using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface ISubjectRepository : IRepository<SUBJECT>
    {
    }

    public class SubjectRepository : RepositoryBase<SUBJECT>, ISubjectRepository
    {
        public SubjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}