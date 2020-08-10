using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.SubData.Repositories
{
    public interface IViolationRepository : IRepository<VIOLATION>
    {
    }
    public class ViolationRepository : RepositoryBase<VIOLATION>, IViolationRepository
    {
        public ViolationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
  
}
