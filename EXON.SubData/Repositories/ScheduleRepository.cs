using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;

namespace EXON.SubData.Repositories
{
    public interface IScheduleRepository : IRepository<SCHEDULE>
    {
    }

    public class ScheduleRepository : RepositoryBase<SCHEDULE>, IScheduleRepository
    {
        public ScheduleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}