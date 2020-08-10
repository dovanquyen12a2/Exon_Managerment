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
    public interface IViolationService
    {
        VIOLATION Add(VIOLATION _VIOLATION);

        void Update(VIOLATION _VIOLATION);

        VIOLATION Delete(int id);

        IEnumerable<VIOLATION> GetAll();

        VIOLATION GetById(int id);

        void Save();
    }

    public class ViolationService : IViolationService
    {
        private ViolationRepository _ViolationRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ViolationService()
        {
            dbFactory = new DbFactory();
            this._ViolationRepository = new ViolationRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public VIOLATION Add(VIOLATION _VIOLATION)
        {
            return _ViolationRepository.Add(_VIOLATION);
        }

        public VIOLATION Delete(int id)
        {
            return _ViolationRepository.Delete(id);
        }

        public IEnumerable<VIOLATION> GetAll()
        {
            return _ViolationRepository.GetAll();
        }

        public VIOLATION GetById(int id)
        {
            return _ViolationRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(VIOLATION _VIOLATION)
        {
            _ViolationRepository.Update(_VIOLATION);
        }
    }
    }
