
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
    public interface IShiftPauseService
    {
        SHIFTSPAUSE Add(SHIFTSPAUSE SHIFTSPAUSE);

        void Update(SHIFTSPAUSE SHIFTSPAUSE);

        SHIFTSPAUSE Delete(int id);

        IEnumerable<SHIFTSPAUSE> GetAll();

        SHIFTSPAUSE GetById(int id);

        void Save();
      
    }

    public class ShiftPauseService : IShiftPauseService
    {
        private IShiftPauseRepository _SHIFTSPAUSERepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ShiftPauseService()
        {
            dbFactory = new DbFactory();
            this._SHIFTSPAUSERepository = new ShiftPauseRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public SHIFTSPAUSE Add(SHIFTSPAUSE SHIFTSPAUSE)
        {
            return _SHIFTSPAUSERepository.Add(SHIFTSPAUSE);
        }

        public SHIFTSPAUSE Delete(int id)
        {
            return _SHIFTSPAUSERepository.Delete(id);
        }

        public IEnumerable<SHIFTSPAUSE> GetAll()
        {
            return _SHIFTSPAUSERepository.GetAll();
        }

        public SHIFTSPAUSE GetById(int id)
        {
            return _SHIFTSPAUSERepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SHIFTSPAUSE SHIFTSPAUSE)
        {
            _SHIFTSPAUSERepository.Update(SHIFTSPAUSE);
        }

      

     
    }
}


