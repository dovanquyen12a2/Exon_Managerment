using System;
using System.Collections.Generic;
using System.Linq;
using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;

namespace EXON.SubData.Services
{
    public interface ITestService
    {
        TEST Add(TEST _Test);

        void Update(TEST _Test);

        TEST Delete(int id);

        IEnumerable<TEST> GetAll();

        TEST GetById(int id);

        void Save();
        IEnumerable<TEST> GetByBagOfTestID(int bagID);
    }

    public class TestService : ITestService
    {
        private TestRepository _TestRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public TestService()
        {
            dbFactory = new DbFactory();
            this._TestRepository = new TestRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public TEST Add(TEST _Test)
        {
            return _TestRepository.Add(_Test);
        }

        public TEST Delete(int id)
        {
            return _TestRepository.Delete(id);
        }

        public IEnumerable<TEST> GetAll()
        {
            return _TestRepository.GetAll();
        }

        public TEST GetById(int id)
        {
            return _TestRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TEST _Test)
        {
            _TestRepository.Update(_Test);
        }
        public IEnumerable<TEST> GetByBagOfTestID(int bagID)
        {
            return _TestRepository.GetMulti(x => x.BagOfTestID == bagID);
        }
    }

}
