using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;

namespace EXON.SubData.Services
{
    public interface IAnswersheetDetailService
    {
        ANSWERSHEET_DETAILS Add(ANSWERSHEET_DETAILS ANSWERSHEET_DETAILS);

        void Update(ANSWERSHEET_DETAILS ANSWERSHEET_DETAILS);

        ANSWERSHEET_DETAILS Delete(int id);

        IEnumerable<ANSWERSHEET_DETAILS> GetAll();

        ANSWERSHEET_DETAILS GetById(int id);

        void Save();
        IEnumerable <ANSWERSHEET_DETAILS> getAllByAnswerID(int answerSheetID);
    }

    public class AnswersheetDetailService : IAnswersheetDetailService
    {
        private IAnswersheetDetailRepository _AnswersheetDetailRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public AnswersheetDetailService()
        {
            dbFactory = new DbFactory();
            this._AnswersheetDetailRepository = new AnswersheetDetailRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ANSWERSHEET_DETAILS Add(ANSWERSHEET_DETAILS ANSWERSHEET_DETAILS)
        {
            return _AnswersheetDetailRepository.Add(ANSWERSHEET_DETAILS);
        }

        public ANSWERSHEET_DETAILS Delete(int id)
        {
            return _AnswersheetDetailRepository.Delete(id);
        }

        public IEnumerable<ANSWERSHEET_DETAILS> GetAll()
        {
            return _AnswersheetDetailRepository.GetAll();
        }

        public ANSWERSHEET_DETAILS GetById(int id)
        {
            return _AnswersheetDetailRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ANSWERSHEET_DETAILS ANSWERSHEET_DETAILS)
        {
            _AnswersheetDetailRepository.Update(ANSWERSHEET_DETAILS);
        }

        public IEnumerable<ANSWERSHEET_DETAILS> getAllByAnswerID(int answerSheetID)
        {
          return  _AnswersheetDetailRepository.GetMulti(x => x.AnswerSheetID == answerSheetID);
        }
    }
}