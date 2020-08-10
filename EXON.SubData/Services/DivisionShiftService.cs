using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System;
using System.Collections.Generic;

namespace EXON.SubData.Services
{
    public interface IDivisionShiftService
    {
        DIVISION_SHIFTS Add(DIVISION_SHIFTS DIVISION_SHIFTS);

        void Update(DIVISION_SHIFTS DIVISION_SHIFTS);

        DIVISION_SHIFTS Delete(int id);

        IEnumerable<DIVISION_SHIFTS> GetAll();

        IEnumerable<DIVISION_SHIFTS> GetByShift(int ShiftID);

        DIVISION_SHIFTS GetByShiftAndRoomTest(int ShiftID, int RoomTestID);

        DIVISION_SHIFTS GetById(int id);

        void Save();

        DIVISION_SHIFTS GetDivisionShift(int shiftID, int roomID);
        void UpdateStatus(int _divisionShiftID, int sTATUS_ARR);
    }

    public class DivisionShiftService : IDivisionShiftService
    {
        private IDivisionShiftRepository _DivisionShiftRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public DivisionShiftService()
        {
            dbFactory = new DbFactory();
            this._DivisionShiftRepository = new DivisionShiftRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public DIVISION_SHIFTS Add(DIVISION_SHIFTS DIVISION_SHIFTS)
        {
            return _DivisionShiftRepository.Add(DIVISION_SHIFTS);
        }

        public DIVISION_SHIFTS Delete(int id)
        {
            return _DivisionShiftRepository.Delete(id);
        }

        public IEnumerable<DIVISION_SHIFTS> GetAll()
        {
            return _DivisionShiftRepository.GetAll();
        }

        public DIVISION_SHIFTS GetById(int id)
        {
            return _DivisionShiftRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(DIVISION_SHIFTS DIVISION_SHIFTS)
        {
            _DivisionShiftRepository.Update(DIVISION_SHIFTS);
        }

        public IEnumerable<DIVISION_SHIFTS> GetByShift(int ShiftID)
        {
            return _DivisionShiftRepository.GetMulti(x => x.ShiftID == ShiftID);
        }

        public DIVISION_SHIFTS GetByShiftAndRoomTest(int ShiftID, int RoomTestID)
        {
            return _DivisionShiftRepository.GetSingleByCondition(x => x.ShiftID == ShiftID && x.RoomTestID == RoomTestID);
        }

        public DIVISION_SHIFTS GetDivisionShift(int shiftID, int roomID)
        {
            return _DivisionShiftRepository.GetSingleByCondition(x => x.ShiftID == shiftID && x.RoomTestID == roomID);
        }

        public void UpdateStatus(int _divisionShiftID, int sTATUS_ARR)
        {
            DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
            ds = _DivisionShiftRepository.GetSingleById(_divisionShiftID);
            ds.Status = sTATUS_ARR;
            _DivisionShiftRepository.Update(ds);
            _unitOfWork.Commit();

        }
        public DIVISION_SHIFTS GetByShiftID(int ShiftID)
        {
            return _DivisionShiftRepository.GetSingleByCondition(x => x.ShiftID == ShiftID);
        }
    }
}