using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;

namespace EXON.SubData.Services
{
    public interface ITestNumberService
    {
        TESTNUMBER Add(TESTNUMBER TESTNUMBER);

        void Update(TESTNUMBER TESTNUMBER);

        TESTNUMBER Delete(int id);

        IEnumerable<TESTNUMBER> GetAll();

        TESTNUMBER GetById(int id);

        void Save();
     
    }

    public class TestNumberService : ITestNumberService
    {
        private ITestNumberRepository _TestNumberRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public TestNumberService()
        {
            dbFactory = new DbFactory();
            this._TestNumberRepository = new TestNumberRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public TESTNUMBER Add(TESTNUMBER TESTNUMBER)
        {
            return _TestNumberRepository.Add(TESTNUMBER);
        }

        public TESTNUMBER Delete(int id)
        {
            return _TestNumberRepository.Delete(id);
        }

        public IEnumerable<TESTNUMBER> GetAll()
        {
            return _TestNumberRepository.GetAll();
        }

        public TESTNUMBER GetById(int id)
        {
            return _TestNumberRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TESTNUMBER TESTNUMBER)
        {
            _TestNumberRepository.Update(TESTNUMBER);
        }

     
    }
}