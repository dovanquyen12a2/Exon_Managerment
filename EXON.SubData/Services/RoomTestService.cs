using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;

namespace EXON.SubData.Services
{
    public interface IRoomTestService
    {
        ROOMTEST Add(ROOMTEST ROOMTEST);

        void Update(ROOMTEST ROOMTEST);

        ROOMTEST Delete(int id);

        IEnumerable<ROOMTEST> GetAll();

        IEnumerable<ROOMTEST> GetAll(string keyword);

        IEnumerable<ROOMTEST> GetAllByLocation(int locationID);

        ROOMTEST GetById(int id);

        void Save();
    }

    public class RoomTestService : IRoomTestService
    {
        private IRoomTestRepository _RoomTestRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public RoomTestService()
        {
            dbFactory = new DbFactory();
            this._RoomTestRepository = new RoomTestRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ROOMTEST Add(ROOMTEST ROOMTEST)
        {
            return _RoomTestRepository.Add(ROOMTEST);
        }

        public ROOMTEST Delete(int id)
        {
            return _RoomTestRepository.Delete(id);
        }

        public IEnumerable<ROOMTEST> GetAll()
        {
            return _RoomTestRepository.GetAll();
        }

        public ROOMTEST GetById(int id)
        {
            return _RoomTestRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ROOMTEST ROOMTEST)
        {
            _RoomTestRepository.Update(ROOMTEST);
        }

        public IEnumerable<ROOMTEST> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _RoomTestRepository.GetMulti(x => x.RoomTestName.Contains(keyword));
            else return _RoomTestRepository.GetAll();
        }

        public IEnumerable<ROOMTEST> GetAllByLocation(int locationID)
        {
            return _RoomTestRepository.GetMulti(x => x.LocationID == locationID);
        }

     
    }
}