
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
    public interface IDivisionShiftPauseService
    {
        DIVSIONSHIFT_PAUSE Add(DIVSIONSHIFT_PAUSE DIVSIONSHIFT_PAUSE);

        void Update(DIVSIONSHIFT_PAUSE DIVSIONSHIFT_PAUSE);

        DIVSIONSHIFT_PAUSE Delete(int id);

        IEnumerable<DIVSIONSHIFT_PAUSE> GetAll();

        DIVSIONSHIFT_PAUSE GetById(int id);

        void Save();

    }

    public class DivisionShiftPauseService : IDivisionShiftPauseService
    {
        private IDivsionShiftPauseRepository _DIVSIONSHIFT_PAUSERepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public DivisionShiftPauseService()
        {
            dbFactory = new DbFactory();
            this._DIVSIONSHIFT_PAUSERepository = new DivsionShiftPauseRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public DIVSIONSHIFT_PAUSE Add(DIVSIONSHIFT_PAUSE DIVSIONSHIFT_PAUSE)
        {
            return _DIVSIONSHIFT_PAUSERepository.Add(DIVSIONSHIFT_PAUSE);
        }

        public DIVSIONSHIFT_PAUSE Delete(int id)
        {
            return _DIVSIONSHIFT_PAUSERepository.Delete(id);
        }

        public IEnumerable<DIVSIONSHIFT_PAUSE> GetAll()
        {
            return _DIVSIONSHIFT_PAUSERepository.GetAll();
        }

        public DIVSIONSHIFT_PAUSE GetById(int id)
        {
            return _DIVSIONSHIFT_PAUSERepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(DIVSIONSHIFT_PAUSE DIVSIONSHIFT_PAUSE)
        {
            _DIVSIONSHIFT_PAUSERepository.Update(DIVSIONSHIFT_PAUSE);
        }




    }
}




