using System;
using System.Collections.Generic;
using EXON.SubModel.Models;
using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using System.Linq;

namespace EXON.SubData.Services
{
    public interface IExaminationcouncilStaffService
    {
        EXAMINATIONCOUNCIL_STAFFS Add(EXAMINATIONCOUNCIL_STAFFS EXAMINATIONCOUNCIL_STAFFS);

        void Update(EXAMINATIONCOUNCIL_STAFFS EXAMINATIONCOUNCIL_STAFFS);

        EXAMINATIONCOUNCIL_STAFFS Delete(int id);

        IEnumerable<EXAMINATIONCOUNCIL_STAFFS> GetAll();

        EXAMINATIONCOUNCIL_STAFFS GetById(int id);

        void Save();
        bool Login(string _username, string pass);
        bool LoginAtCenter(string _username, string pass);
        IEnumerable<EXAMINATIONCOUNCIL_STAFFS> GetMutilByAccAtCenter(string _username, string pass);
        EXAMINATIONCOUNCIL_STAFFS GetByStaffID(int staffID);
    }

    public class ExaminationcouncilStaffService : IExaminationcouncilStaffService
    {
        private IExaminationcouncilStaffRepository _ExaminationcouncilStaffRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;
        public ExaminationcouncilStaffService()
        {
            dbFactory = new DbFactory();
            this._ExaminationcouncilStaffRepository = new ExaminationcouncilStaffRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }
        public EXAMINATIONCOUNCIL_STAFFS Add(EXAMINATIONCOUNCIL_STAFFS _EXAMINATIONCOUNCIL_STAFFS)
        {
            return _ExaminationcouncilStaffRepository.Add(_EXAMINATIONCOUNCIL_STAFFS);
        }

        public EXAMINATIONCOUNCIL_STAFFS Delete(int id)
        {
            return _ExaminationcouncilStaffRepository.Delete(id);
        }

      
        public EXAMINATIONCOUNCIL_STAFFS GetStaffByLogin(string _user, string _pass)
        {
            EXAMINATIONCOUNCIL_STAFFS staff = _ExaminationcouncilStaffRepository.GetSingleByCondition(x => x.UserName == _user && x.Password == _pass);
            return staff;
        }

        public IEnumerable<EXAMINATIONCOUNCIL_STAFFS> GetAll()
        {
            return _ExaminationcouncilStaffRepository.GetAll();
        }


        public EXAMINATIONCOUNCIL_STAFFS GetById(int id)
        {
            return _ExaminationcouncilStaffRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(EXAMINATIONCOUNCIL_STAFFS EXAMINATIONCOUNCIL_STAFFS)
        {
            _ExaminationcouncilStaffRepository.Update(EXAMINATIONCOUNCIL_STAFFS);
        }


        public bool Login(string _username, string pass)
        {
            try
            {
                EXAMINATIONCOUNCIL_STAFFS staff = _ExaminationcouncilStaffRepository.GetSingleByCondition(x => x.UserName == _username);
                if (staff != null)
                {
                    if (staff.Password == pass)
                    {
                        return true;
                    }
                    else return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool LoginAtCenter(string _username, string pass)
        {
            try
            {
                List<EXAMINATIONCOUNCIL_STAFFS> lststaff = _ExaminationcouncilStaffRepository.GetMulti(x => x.UserName == _username && x.Password==pass).ToList();
   
                if (lststaff.Count > 0)
                {

                    return true;

                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<EXAMINATIONCOUNCIL_STAFFS> GetMutilByAccAtCenter(string _username, string pass)
        {
            return    _ExaminationcouncilStaffRepository.GetMulti(x => x.UserName == _username && x.Password == pass);
        }
        public EXAMINATIONCOUNCIL_STAFFS GetByStaffID(int staffID)
        {
            return _ExaminationcouncilStaffRepository.GetSingleByCondition(x => x.StaffID == staffID);
        }
    }
}
