using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IRoomTestRepository : IRepository<ROOMTEST>
    {
    }

    public class RoomTestRepository : RepositoryBase<ROOMTEST>, IRoomTestRepository
    {
        public RoomTestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}