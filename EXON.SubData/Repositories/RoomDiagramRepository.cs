using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IRoomDiagramRepository : IRepository<ROOMDIAGRAM>
    {
    }

    public class RoomDiagramRepository : RepositoryBase<ROOMDIAGRAM>, IRoomDiagramRepository
    {
        public RoomDiagramRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
