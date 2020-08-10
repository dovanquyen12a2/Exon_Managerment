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
    public interface IAnswersheetSpeakingService
    {
        ANSWERSHEET_SPEAKING Add(ANSWERSHEET_SPEAKING ANSWERSHEET_SPEAKING);

        void Update(ANSWERSHEET_SPEAKING ANSWERSHEET_SPEAKING);

        ANSWERSHEET_SPEAKING Delete(int id);

        IEnumerable<ANSWERSHEET_SPEAKING> GetAll();

        ANSWERSHEET_SPEAKING GetById(int id);

        ANSWERSHEET_SPEAKING GetByAnwsersheetID(int anwsersheetID);

        void Save();
    }

    public class AnswersheetSpeakingService : IAnswersheetSpeakingService
    {
        private IAnswersheetSpeakingRepository _AnswersheetSpeakingRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public AnswersheetSpeakingService()
        {
            dbFactory = new DbFactory();
            this._AnswersheetSpeakingRepository = new AnswersheetSpeakingRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ANSWERSHEET_SPEAKING Add(ANSWERSHEET_SPEAKING ANSWERSHEET_SPEAKING)
        {
            return _AnswersheetSpeakingRepository.Add(ANSWERSHEET_SPEAKING);
        }

        public ANSWERSHEET_SPEAKING Delete(int id)
        {
            return _AnswersheetSpeakingRepository.Delete(id);
        }

        public IEnumerable<ANSWERSHEET_SPEAKING> GetAll()
        {
            return _AnswersheetSpeakingRepository.GetAll();
        }

        public ANSWERSHEET_SPEAKING GetById(int id)
        {
            return _AnswersheetSpeakingRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ANSWERSHEET_SPEAKING ANSWERSHEET_SPEAKING)
        {
            _AnswersheetSpeakingRepository.Update(ANSWERSHEET_SPEAKING);
        }

        public ANSWERSHEET_SPEAKING GetByAnwsersheetID(int anwsersheetID)
        {
            return _AnswersheetSpeakingRepository.GetSingleByCondition(x => x.AnswerSheetID == anwsersheetID);
        }
    }
}
