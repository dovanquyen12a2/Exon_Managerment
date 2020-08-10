using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;

namespace EXON.SubData.Services
{
    public interface IAnswersheetService
    {
        ANSWERSHEET Add(ANSWERSHEET ANSWERSHEET);

        void Update(ANSWERSHEET ANSWERSHEET);

        ANSWERSHEET Delete(int id);

        IEnumerable<ANSWERSHEET> GetAll();

        double GetScore(int contestantTest);

        ANSWERSHEET GetById(int id);
        ANSWERSHEET GetByContestantTestID(int contestantTestID);
        void Save();
    }

    public class AnswersheetService : IAnswersheetService
    {
        private IAnswersheetRepository _AnswersheetRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public AnswersheetService()
        {
            dbFactory = new DbFactory();
            this._AnswersheetRepository = new AnswersheetRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ANSWERSHEET Add(ANSWERSHEET ANSWERSHEET)
        {
            return _AnswersheetRepository.Add(ANSWERSHEET);
        }

        public ANSWERSHEET Delete(int id)
        {
            return _AnswersheetRepository.Delete(id);
        }

        public IEnumerable<ANSWERSHEET> GetAll()
        {
            return _AnswersheetRepository.GetAll();
        }

        public ANSWERSHEET GetById(int id)
        {
            return _AnswersheetRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ANSWERSHEET ANSWERSHEET)
        {
            _AnswersheetRepository.Update(ANSWERSHEET);
        }

        public double GetScore(int contestantTest)
        {
            ANSWERSHEET ans = _AnswersheetRepository.GetSingleByCondition(x => x.ContestantTestID == contestantTest);
            if (ans != null)
            {
                return ans.TestScores.HasValue ? ans.TestScores.Value : 0;
            }
            else return 0;
        }

        public ANSWERSHEET GetByContestantTestID(int contestantTestID)
        {
            return _AnswersheetRepository.GetSingleByCondition(x => x.ContestantTestID == contestantTestID);
        }
    }
}