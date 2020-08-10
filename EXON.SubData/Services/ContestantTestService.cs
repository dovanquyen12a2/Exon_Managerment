using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;

namespace EXON.SubData.Services
{
    public interface IContestantTestService
    {
        CONTESTANTS_TESTS Add(CONTESTANTS_TESTS CONTESTANTS_TESTS);

        void Update(CONTESTANTS_TESTS CONTESTANTS_TESTS);

        CONTESTANTS_TESTS Delete(int id);

        IEnumerable<CONTESTANTS_TESTS> GetAll();

     
        CONTESTANTS_TESTS GetByContestantShiftId(int id);

        void Save();
    }

    public class ContestantTestService : IContestantTestService
    {
        private IContestantTestRepository _ContestantTestRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestantTestService()
        {
            dbFactory = new DbFactory();
            this._ContestantTestRepository = new ContestantTestRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public CONTESTANTS_TESTS Add(CONTESTANTS_TESTS CONTESTANTS_TESTS)
        {
            return _ContestantTestRepository.Add(CONTESTANTS_TESTS);
        }

        public CONTESTANTS_TESTS Delete(int id)
        {
            return _ContestantTestRepository.Delete(id);
        }

        public IEnumerable<CONTESTANTS_TESTS> GetAll()
        {
            return _ContestantTestRepository.GetAll();
        }

       

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CONTESTANTS_TESTS CONTESTANTS_TESTS)
        {
            _ContestantTestRepository.Update(CONTESTANTS_TESTS);
        }

        public CONTESTANTS_TESTS GetByContestantShiftId(int id)
        {
            return _ContestantTestRepository.GetSingleByCondition(x => x.ContestantShiftID == id);
        }
    }
}