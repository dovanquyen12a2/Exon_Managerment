using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;

namespace EXON.SubData.Services
{
    public interface IContestantService
    {
        CONTESTANT Add(CONTESTANT CONTESTANT);

        void Update(CONTESTANT CONTESTANT);

        CONTESTANT Delete(int id);

        IEnumerable<CONTESTANT> GetAll();
        IEnumerable<CONTESTANT> GetMultiByUnit(string _unit);

        CONTESTANT GetById(int id);

        void Save();
        CONTESTANT GetSigleByUserCode(string userCode);
    }

    public class ContestantService : IContestantService
    {
        private IContestantRepository _ContestantRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestantService()
        {
            dbFactory = new DbFactory();
            this._ContestantRepository = new ContestantRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public CONTESTANT Add(CONTESTANT CONTESTANT)
        {
            return _ContestantRepository.Add(CONTESTANT);
        }

        public CONTESTANT Delete(int id)
        {
            return _ContestantRepository.Delete(id);
        }

        public IEnumerable<CONTESTANT> GetAll()
        {
            return _ContestantRepository.GetAll();
        }

        public CONTESTANT GetById(int id)
        {
            return _ContestantRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }


        public IEnumerable<CONTESTANT> GetMultiByUnit(string _unit)
        {
           return _ContestantRepository.GetMulti(x => x.Unit == _unit);
        }
        public void Update(CONTESTANT CONTESTANT)
        {
            _ContestantRepository.Update(CONTESTANT);
        }

        public bool UpdateContestant(CONTESTANT _contestant)
        {
            try
            {
                _ContestantRepository.Update(_contestant);
           
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CONTESTANT GetSigleByUserCode(string userCode)
        {
            return _ContestantRepository.GetSingleByCondition(x => x.ContestantCode == userCode);
        }
    }
}