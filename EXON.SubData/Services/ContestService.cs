using EXON.Common;
using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System;
using System.Collections.Generic;

namespace EXON.SubData.Services
{
    public interface IContestService
    {
        CONTEST Add(CONTEST CONTEST);

        void Update(CONTEST CONTEST);

        CONTEST Delete(int id);

        IEnumerable<CONTEST> GetAll();

        IEnumerable<CONTEST> GetAll(string keyword);

        IEnumerable<CONTEST> GetAllAccepted();

        CONTEST GetById(int id);

        void Save();
    }

    public class ContestService : IContestService
    {
        private IContestRepository _ContestRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestService()
        {
            dbFactory = new DbFactory();
            this._ContestRepository = new ContestRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public CONTEST Add(CONTEST CONTEST)
        {
            return _ContestRepository.Add(CONTEST);
        }

        public CONTEST Delete(int id)
        {
            return _ContestRepository.Delete(id);
        }

        public IEnumerable<CONTEST> GetAll()
        {
            return _ContestRepository.GetAll();
        }

        public IEnumerable<CONTEST> GetAllAccepted()
        {
            int endDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
            return _ContestRepository
                .GetMulti(x => x.Status != (int)ContestStatus.New &&
                x.EndDate.Value > endDate);
        }

        public CONTEST GetById(int id)
        {
            return _ContestRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CONTEST CONTEST)
        {
            _ContestRepository.Update(CONTEST);
        }

        public IEnumerable<CONTEST> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _ContestRepository.GetMulti(x => x.ContestName.Contains(keyword));
            else return _ContestRepository.GetAll();
        }
    }
}