using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;
namespace EXON.SubData.Repositories
{
    public   interface  ITestRepository:IRepository<TEST>
    {
    }
    public class TestRepository : RepositoryBase<TEST>, ITestRepository
    {
        public TestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
