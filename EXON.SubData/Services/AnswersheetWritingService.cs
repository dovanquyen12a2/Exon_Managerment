using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.SubData.Services
{
    public interface IAnswersheetWritingService
    {
        ANSWERSHEET_WRITING Add(ANSWERSHEET_WRITING ANSWERSHEET_WRITING);

        void Update(ANSWERSHEET_WRITING ANSWERSHEET_WRITING);

        ANSWERSHEET_WRITING Delete(int id);

        IEnumerable<ANSWERSHEET_WRITING> GetAll();

        ANSWERSHEET_WRITING GetById(int id);

        ANSWERSHEET_WRITING GetByAnwsersheetID(int anwsersheetID);

        void Save();
    }

    public class AnswersheetWritingService : IAnswersheetWritingService
    {
        private IAnswersheetWritingRepository _AnswersheetWritingRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public AnswersheetWritingService()
        {
            dbFactory = new DbFactory();
            this._AnswersheetWritingRepository = new AnswersheetWritingRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ANSWERSHEET_WRITING Add(ANSWERSHEET_WRITING ANSWERSHEET_WRITING)
        {
            return _AnswersheetWritingRepository.Add(ANSWERSHEET_WRITING);
        }

        public ANSWERSHEET_WRITING Delete(int id)
        {
            return _AnswersheetWritingRepository.Delete(id);
        }

        public IEnumerable<ANSWERSHEET_WRITING> GetAll()
        {
            return _AnswersheetWritingRepository.GetAll();
        }

        public ANSWERSHEET_WRITING GetById(int id)
        {
            return _AnswersheetWritingRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ANSWERSHEET_WRITING ANSWERSHEET_WRITING)
        {
            _AnswersheetWritingRepository.Update(ANSWERSHEET_WRITING);
        }

        public ANSWERSHEET_WRITING GetByAnwsersheetID(int anwsersheetID)
        {
            return _AnswersheetWritingRepository.GetSingleByCondition(x => x.AnswerSheetID == anwsersheetID);
        }
    }
}
