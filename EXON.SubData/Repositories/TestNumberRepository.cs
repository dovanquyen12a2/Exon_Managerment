using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface ITestNumberRepository : IRepository<TESTNUMBER>
    {
    }

    public class TestNumberRepository : RepositoryBase<TESTNUMBER>, ITestNumberRepository
    {
        public TestNumberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}