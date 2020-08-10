using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;

namespace EXON.SubData.Services
{
    public interface IStaffService
    {
        
        STAFF Add(STAFF STAFF);

        void Update(STAFF STAFF);

        STAFF Delete(int id);

        IEnumerable<STAFF> GetAll();

        STAFF GetById(int id);

        void Save();
      

    }

    public class StaffService : IStaffService
    {
        private IStaffRepository _StaffRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public StaffService()
        {
            dbFactory = new DbFactory();
            this._StaffRepository = new StaffRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public STAFF Add(STAFF STAFF)
        {
            return _StaffRepository.Add(STAFF);
        }

        public STAFF Delete(int id)
        {
            return _StaffRepository.Delete(id);
        }

        public IEnumerable<STAFF> GetAll()
        {
            return _StaffRepository.GetAll();
        }

        public STAFF GetById(int id)
        {
            return _StaffRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(STAFF STAFF)
        {
            _StaffRepository.Update(STAFF);
        }
       

     
    }
}