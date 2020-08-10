using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace EXON.SubData.Services
{
    public interface IContestantShiftService
    {
        CONTESTANTS_SHIFTS Add(CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS);

        void Update(CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS);

        CONTESTANTS_SHIFTS Delete(int id);

        IEnumerable<CONTESTANTS_SHIFTS> GetAll();

        IEnumerable<CONTESTANTS_SHIFTS> GetAllByDivisionShiftID(int DivisionShiftID);

        IEnumerable<CONTESTANTS_SHIFTS> GetAllBySchedule(int ScheduleId);

        IEnumerable<CONTESTANTS_SHIFTS> GetAllByScheduleShift(int ScheduleId, int ShiftId);

        IEnumerable<CONTESTANTS_SHIFTS> GetAllByContestantID(int ContestantID);
        CONTESTANTS_SHIFTS GetById(int id);

        void Save();
        List<int> ListContestantShiftID(int _divisionShiftID);
        CONTESTANTS_SHIFTS GetByContestantID(int _divisionShiftID, int userID);
        void UpdateTimeStartForContestantShift(int _divisionShiftID, int timeNowStartTest);
        void UpdateStatusForContestantShift(int _divisionShiftID, int status);
       
        CONTESTANTS_SHIFTS GetFirstByDivisionShiftID(int _divisionShiftID);
    }

    public class ContestantShiftService : IContestantShiftService
    {
        private IContestantShiftRepository _ContestantShiftRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestantShiftService()
        {
            dbFactory = new DbFactory();
            this._ContestantShiftRepository = new ContestantShiftRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public CONTESTANTS_SHIFTS Add(CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS)
        {
            return _ContestantShiftRepository.Add(CONTESTANTS_SHIFTS);
        }

        public CONTESTANTS_SHIFTS Delete(int id)
        {
            return _ContestantShiftRepository.Delete(id);
        }
     
        public List<CONTESTANT> GetlistContestantByShitfID(int _shiftID)
        {
            List<CONTESTANT> result = new List<CONTESTANT>();
            MTAQuizDbContext Db = new MTAQuizDbContext();

            try
            {
                var listContestantID = (from obj in _ContestantShiftRepository
                    .GetMulti(x => x.DIVISION_SHIFTS.ShiftID == _shiftID)
                                        select obj.ContestantID).ToList();
                result = (from obj in Db.CONTESTANTS
                          where listContestantID.Contains(obj.ContestantID)
                          select obj).ToList();
                return result;
            }
            catch
            {
                return result;
            }
        }

        public IEnumerable<CONTESTANTS_SHIFTS> GetAll()
        {
            return _ContestantShiftRepository.GetAll();
        }

        public CONTESTANTS_SHIFTS GetById(int id)
        {
            return _ContestantShiftRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS)
        {
            _ContestantShiftRepository.Update(CONTESTANTS_SHIFTS);
        }

        public IEnumerable<CONTESTANTS_SHIFTS> GetAllByDivisionShiftID(int DivisionShiftID)
        {
            return _ContestantShiftRepository.GetMulti(x => x.DivisionShiftID == DivisionShiftID);
        }

        public IEnumerable<CONTESTANTS_SHIFTS> GetAllBySchedule(int ScheduleId)
        {
            return _ContestantShiftRepository.GetMulti(x => x.ScheduleID == ScheduleId);
        }
       
        public IEnumerable<CONTESTANTS_SHIFTS> GetAllByScheduleShift(int ScheduleId, int ShiftId)
        {
            return _ContestantShiftRepository.GetMulti(x => x.ScheduleID == ScheduleId && x.DivisionShiftID == ShiftId);
        }

        public CONTESTANTS_SHIFTS GetContestantShiftByShiftAndContestant(int contestantid, int _shiftID)
        {
            return _ContestantShiftRepository.GetSingleByCondition(x => x.DIVISION_SHIFTS.ShiftID == _shiftID && x.ContestantID == contestantid);
        }

        public List<int> ListContestantShiftID(int _divisionShiftID)
        {
            List<int> result = new List<int>();
            result = (from obj in _ContestantShiftRepository.GetAll().Where(x => x.DivisionShiftID == _divisionShiftID)
                      select obj.ContestantShiftID
                      ).ToList();
            return result;
        }

        public CONTESTANTS_SHIFTS GetByContestantID(int _divisionShiftID, int userID)
        {
            return _ContestantShiftRepository.GetSingleByCondition(x => x.DivisionShiftID == _divisionShiftID && x.ContestantID == userID);
        }

        public void UpdateTimeStartForContestantShift(int _divisionShiftID, int timeNowStartTest)
        {
          List<CONTESTANTS_SHIFTS> lst =   GetAllByDivisionShiftID(_divisionShiftID).ToList();
            foreach(CONTESTANTS_SHIFTS item in lst)
            {
                item.TimeStarted = timeNowStartTest;
                Update(item);
            }
            Save();
        }
        public void UpdateStatusForContestantShift(int _divisionShiftID, int status)
        {
            List<CONTESTANTS_SHIFTS> lst = GetAllByDivisionShiftID(_divisionShiftID).ToList();
            foreach (CONTESTANTS_SHIFTS item in lst)
            {
                if(item.Status!=4001)
                {
                    item.Status = status;
                    Update(item);
                }
               
            }
            Save();
        }
        public IEnumerable<CONTESTANTS_SHIFTS> GetAllByContestantID(int ContestantID)
        {
            return _ContestantShiftRepository.GetMulti(x => x.ContestantID == ContestantID);
        }

        public CONTESTANTS_SHIFTS GetFirstByDivisionShiftID(int _divisionShiftID)
        {
            return _ContestantShiftRepository.GetMulti(x => x.DivisionShiftID == _divisionShiftID).FirstOrDefault();
        }
    }
}