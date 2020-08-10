using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.SubData.Infrastructures;
using EXON.SubModel.Models;
namespace EXON.SubData.Repositories
{
   public interface IExaminationcouncilStaffRepository: IRepository<EXAMINATIONCOUNCIL_STAFFS>
    {
    }
    public class ExaminationcouncilStaffRepository : RepositoryBase<EXAMINATIONCOUNCIL_STAFFS>, IExaminationcouncilStaffRepository
    {
        public ExaminationcouncilStaffRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
