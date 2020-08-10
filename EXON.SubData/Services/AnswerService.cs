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
    public interface IAnswerService
    {
        ANSWER Add(ANSWER ANSWER);

        void Update(ANSWER ANSWER);

        ANSWER Delete(int id);

        IEnumerable<ANSWER> GetAll();

        ANSWER GetById(int id);

        void Save();
        IEnumerable<ANSWER> getAllByAnswerID(int AnswerID);
        ANSWER GetbySubQuestionID(int subQuestionID,int AnswerID);
    }

    public class AnswerService : IAnswerService
    {
        private IAnswerRepository _AnswerRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public AnswerService()
        {
            dbFactory = new DbFactory();
            this._AnswerRepository = new AnswerRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ANSWER Add(ANSWER ANSWER)
        {
            return _AnswerRepository.Add(ANSWER);
        }

        public ANSWER Delete(int id)
        {
            return _AnswerRepository.Delete(id);
        }

        public IEnumerable<ANSWER> GetAll()
        {
            return _AnswerRepository.GetAll();
        }

        public ANSWER GetById(int id)
        {
            return _AnswerRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ANSWER ANSWER)
        {
            _AnswerRepository.Update(ANSWER);
        }

        public IEnumerable<ANSWER> getAllByAnswerID(int AnswerID)
        {
            return _AnswerRepository.GetMulti(x => x.AnswerID == AnswerID);
        }

        public ANSWER GetbySubQuestionID(int subQuestionID, int AnswerID)
        {
            return _AnswerRepository.GetSingleByCondition(x => x.SubQuestionID == subQuestionID && x.AnswerID==AnswerID);
        }
    }
}
