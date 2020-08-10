using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.SubData.Repositories
{
    public interface IAnswerRepository : IRepository<ANSWER>
    {

    }

    public class AnswerRepository : RepositoryBase<ANSWER>, IAnswerRepository
    {
        public AnswerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
    
}
