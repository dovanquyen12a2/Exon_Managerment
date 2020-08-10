using System;
using System.Collections.Generic;
using System.Linq;
using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;

namespace EXON.SubData.Services
{
    public interface IBagOfTestService
    {
        BAGOFTEST Add(BAGOFTEST _BagOfTest);

        void Update(BAGOFTEST _BagOfTest);

        BAGOFTEST Delete(int id);

        IEnumerable<BAGOFTEST> GetAll();

        BAGOFTEST GetById(int id);

        void Save();
        BAGOFTEST GetByDIvisionShiftID(int dsID);
    }

    public class BagOfTestService : IBagOfTestService
    {
        private BagOfTestRepository _BagOfTestRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public BagOfTestService()
        {
            dbFactory = new DbFactory();
            this._BagOfTestRepository = new BagOfTestRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public BAGOFTEST Add(BAGOFTEST _BagOfTest)
        {
            return _BagOfTestRepository.Add(_BagOfTest);
        }

        public BAGOFTEST Delete(int id)
        {
            return _BagOfTestRepository.Delete(id);
        }

        public IEnumerable<BAGOFTEST> GetAll()
        {
            return _BagOfTestRepository.GetAll();
        }

        public BAGOFTEST GetById(int id)
        {
            return _BagOfTestRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(BAGOFTEST _BagOfTest)
        {
            _BagOfTestRepository.Update(_BagOfTest);
        }
        public BAGOFTEST GetByDIvisionShiftID(int dsID)
        {
            //return _ContestantShiftRepository.GetMulti(x => x.DivisionShiftID == DivisionShiftID);
            return _BagOfTestRepository.GetSingleByCondition(x => x.DivisionShiftID == dsID);
        }
    }
}
