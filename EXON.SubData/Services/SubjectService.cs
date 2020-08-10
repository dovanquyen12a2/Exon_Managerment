using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;

namespace EXON.SubData.Services
{
    public interface ISubjectService
    {
        SUBJECT Add(SUBJECT SUBJECT);

        void Update(SUBJECT SUBJECT);

        SUBJECT Delete(int id);

        IEnumerable<SUBJECT> GetAll();

        SUBJECT GetById(int id);

        void Save();
    }

    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _SUBJECTRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public SubjectService()
        {
            dbFactory = new DbFactory();
            this._SUBJECTRepository = new SubjectRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public SUBJECT Add(SUBJECT SUBJECT)
        {
            return _SUBJECTRepository.Add(SUBJECT);
        }

        public SUBJECT Delete(int id)
        {
            return _SUBJECTRepository.Delete(id);
        }

        public IEnumerable<SUBJECT> GetAll()
        {
            return _SUBJECTRepository.GetAll();
        }       

        public SUBJECT GetById(int id)
        {
            return _SUBJECTRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SUBJECT SUBJECT)
        {
            _SUBJECTRepository.Update(SUBJECT);
        }
    }
}