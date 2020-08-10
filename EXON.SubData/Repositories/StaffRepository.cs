using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IStaffRepository : IRepository<STAFF>
    {
    }

    public class StaffRepository : RepositoryBase<STAFF>, IStaffRepository
    {
        public StaffRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}