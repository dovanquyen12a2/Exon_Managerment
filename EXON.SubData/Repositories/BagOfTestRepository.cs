using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
     public  interface IBagOfTestRepository : IRepository<BAGOFTEST> { }

    public class BagOfTestRepository : RepositoryBase<BAGOFTEST>, IBagOfTestRepository
    {
        public BagOfTestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
