
using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.SubData.Services
{
    public interface IContestantPauseService
    {
        CONTESTANTPAUSE Add(CONTESTANTPAUSE CONTESTANTPAUSE);

        void Update(CONTESTANTPAUSE CONTESTANTPAUSE);

        CONTESTANTPAUSE Delete(int id);

        IEnumerable<CONTESTANTPAUSE> GetAll();

        CONTESTANTPAUSE GetById(int id);

        void Save();

    }

    public class ContestantPauseService : IContestantPauseService
    {
        private IContestanPauseRepository  _CONTESTANTPAUSERepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestantPauseService()
        {
            dbFactory = new DbFactory();
            this._CONTESTANTPAUSERepository = new ContestanPauseRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public CONTESTANTPAUSE Add(CONTESTANTPAUSE CONTESTANTPAUSE)
        {
            return _CONTESTANTPAUSERepository.Add(CONTESTANTPAUSE);
        }

        public CONTESTANTPAUSE Delete(int id)
        {
            return _CONTESTANTPAUSERepository.Delete(id);
        }

        public IEnumerable<CONTESTANTPAUSE> GetAll()
        {
            return _CONTESTANTPAUSERepository.GetAll();
        }

        public CONTESTANTPAUSE GetById(int id)
        {
            return _CONTESTANTPAUSERepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CONTESTANTPAUSE CONTESTANTPAUSE)
        {
            _CONTESTANTPAUSERepository.Update(CONTESTANTPAUSE);
        }




    }
}



