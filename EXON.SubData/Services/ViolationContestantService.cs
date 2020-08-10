using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.SubModel.Models;
namespace EXON.SubData.Services
{
    public interface IViolationContestantService
    {
        VIOLATIONS_CONTESTANTS Add(VIOLATIONS_CONTESTANTS _VIOLATIONSCONTESTANTS);

        void Update(VIOLATIONS_CONTESTANTS _VIOLATIONSCONTESTANTS);

        VIOLATIONS_CONTESTANTS Delete(int id);

        IEnumerable<VIOLATIONS_CONTESTANTS> GetAll();

        VIOLATIONS_CONTESTANTS GetById(int id);

        void Save();
        IEnumerable<VIOLATIONS_CONTESTANTS> GetByConstestshiftID(int contestantShiftID);
    }

    public class ViolationContestantService : IViolationContestantService
    {
        private ViolationContestantRepository _ViolationContestantRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ViolationContestantService()
        {
            dbFactory = new DbFactory();
            this._ViolationContestantRepository = new ViolationContestantRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public VIOLATIONS_CONTESTANTS Add(VIOLATIONS_CONTESTANTS _VIOLATIONSCONTESTANTS)
        {
            return _ViolationContestantRepository.Add(_VIOLATIONSCONTESTANTS);
        }

        public VIOLATIONS_CONTESTANTS Delete(int id)
        {
            return _ViolationContestantRepository.Delete(id);
        }

        public IEnumerable<VIOLATIONS_CONTESTANTS> GetAll()
        {
            return _ViolationContestantRepository.GetAll();
        }

        public VIOLATIONS_CONTESTANTS GetById(int id)
        {
            return _ViolationContestantRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(VIOLATIONS_CONTESTANTS _VIOLATIONSCONTESTANTS)
        {
            _ViolationContestantRepository.Update(_VIOLATIONSCONTESTANTS);
        }
      public   IEnumerable<VIOLATIONS_CONTESTANTS> GetByConstestshiftID(int contestantShiftID)
        {
            return _ViolationContestantRepository.GetMulti(x => x.ContestantShiftID == contestantShiftID);
        }
    }

  
}
