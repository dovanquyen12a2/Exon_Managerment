using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.SubModel.Models;
using EXON.SubData.Infrastructures;

namespace EXON.SubData.Repositories
{
    public interface IViolationContestantRepository : IRepository<VIOLATIONS_CONTESTANTS>
    {
    }
    public class ViolationContestantRepository : RepositoryBase<VIOLATIONS_CONTESTANTS>, IViolationContestantRepository
    {
        public ViolationContestantRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
 
}
