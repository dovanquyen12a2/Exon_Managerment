using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;
using EXON.Common;
using System.Linq;

namespace EXON.SubData.Services
{
    public interface IShiftService
    {
        SHIFT Add(SHIFT SHIFT);

        void Update(SHIFT SHIFT);

        SHIFT Delete(int id);

        IEnumerable<SHIFT> GetAll(int ContestId);


        IEnumerable<SHIFT> GetMultiByStartDate(int StartDate);

     SHIFT GetById(int id);

        void Save();
       SHIFT GetShiftNow(int timeNow, int logTime, int dIF_TIME, int supervisorID);
    }

    public class ShiftService : IShiftService
    {
        private IShiftRepository _ShiftRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;
      
        public ShiftService()
        {
            dbFactory = new DbFactory();
            this._ShiftRepository = new ShiftRepository(dbFactory);
           
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public SHIFT Add(SHIFT SHIFT)
        {
            return _ShiftRepository.Add(SHIFT);
        }

        public SHIFT Delete(int id)
        {
            return _ShiftRepository.Delete(id);
        }

        public IEnumerable<SHIFT> GetAll(int ContestId)
        {
            return _ShiftRepository.GetMulti(x => x.ContestID == ContestId);
        }
      public   IEnumerable<SHIFT> GetMultiByStartDate( int StartDate)
        {
           
            return _ShiftRepository.GetMulti(x => x.ShiftDate/86400 == StartDate/86400 );
        }
        public SHIFT GetById(int id)
        {
            return _ShiftRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SHIFT SHIFT)
        {
            _ShiftRepository.Update(SHIFT);
        }

        public SHIFT GetShiftNow(int timeNow, int logTime, int dIF_TIME, int supervisorID)
        {
            MTAQuizDbContext Db = new MTAQuizDbContext();
            int date = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now) / 86400;
                       SHIFT result = ( from obj in _ShiftRepository.GetMulti(x => x.StartTime < timeNow + dIF_TIME && (int)(x.ShiftDate / 86400) == date && timeNow < x.EndTime)
                           
                           from obj2 in Db.DIVISIONSHIFT_SUPERVISOR
                           where obj2.DIVISION_SHIFTS.ShiftID == obj.ShiftID && (obj2.SupervisorID == supervisorID)
                           select obj).FirstOrDefault();
            return result;

        }
    }
}