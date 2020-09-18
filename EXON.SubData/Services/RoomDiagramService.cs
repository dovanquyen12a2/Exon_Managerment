using EXON.SubData.Infrastructures;
using EXON.SubData.Repositories;
using EXON.SubModel.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Xml;

namespace EXON.SubData.Services
{
    public interface IRoomDiagramService
    {
        ROOMDIAGRAM Add(ROOMDIAGRAM ROOMDIAGRAM);

        void Update(ROOMDIAGRAM ROOMDIAGRAM);

        ROOMDIAGRAM Delete(int id);

        IEnumerable<ROOMDIAGRAM> GetAll();

        ROOMDIAGRAM GetById(int id);

        void Save();
        List<int> ListRoomDiaID(int _roomTestID);
        ROOMDIAGRAM GetByComputername(string computerName);
        IEnumerable<ROOMDIAGRAM> GetAllByRoomTest(int _roomTestID); 
        List<ROOMDIAGRAM> GetListRoomByDs(int _divisionShiftID, int _roomTestID);
        void UpdateStatusbyAgent(int _roomTestID);
    }

    public class RoomDiagramService : IRoomDiagramService
    {
        private IRoomDiagramRepository _RoomDiagramRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public RoomDiagramService()
        {
            dbFactory = new DbFactory();
            this._RoomDiagramRepository = new RoomDiagramRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ROOMDIAGRAM Add(ROOMDIAGRAM ROOMDIAGRAM)
        {
            return _RoomDiagramRepository.Add(ROOMDIAGRAM);
        }

        public ROOMDIAGRAM Delete(int id)
        {
            return _RoomDiagramRepository.Delete(id);
        }

        public IEnumerable<ROOMDIAGRAM> GetAll()
        {
            return _RoomDiagramRepository.GetAll();
        }

        public ROOMDIAGRAM GetById(int id)
        {
            return _RoomDiagramRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ROOMDIAGRAM ROOMDIAGRAM)
        {
            _RoomDiagramRepository.Update(ROOMDIAGRAM);
        }

        public List<int> ListRoomDiaID(int _roomTestID)
        {
            List<int> result = new List<int>();
            result = (from obj in _RoomDiagramRepository.GetMulti(x => x.RoomTestID == _roomTestID)
                      select obj.RoomDiagramID
                     ).ToList();
            return result; 
        }

        public ROOMDIAGRAM GetByComputername(string computerName)
        {
            return _RoomDiagramRepository.GetSingleByCondition(x => x.ComputerName==computerName);
        }

        
        IEnumerable<ROOMDIAGRAM> IRoomDiagramService.GetAllByRoomTest(int _roomTestID)
        {
            return _RoomDiagramRepository.GetMulti(x => x.RoomTestID == _roomTestID);
        }

        public List<ROOMDIAGRAM> GetListRoomByDs(int _divisionShiftID, int _roomTestID)
        {
            MTAQuizDbContext Db = new MTAQuizDbContext();
            List<ROOMDIAGRAM> result = new List<ROOMDIAGRAM>();

            ROOMDIAGRAM rd = new ROOMDIAGRAM();

                var room = (from obj2 in Db.CONTESTANTS_SHIFTS
                            where (obj2.DivisionShiftID == _divisionShiftID)
                            select obj2.RoomDiagramID).ToList();
                result = (from obj1 in Db.ROOMDIAGRAMS
                          where (obj1.RoomTestID == _roomTestID)
                             && !room.Contains(obj1.RoomDiagramID)
                          select obj1).ToList();
                return result;
       }
        public static int ConvertDateTimeToUnix(DateTime dt)
        {
            return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }
        public static DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }
        public static DateTime GetDateTimeServer()
        {
            MTAQuizDbContext db = new MTAQuizDbContext();
            return db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
        }
        public void UpdateStatusbyAgent(int _roomTestID)
        {
            using (MTAQuizDbContext db = new MTAQuizDbContext())
            {
                DateTime dt = new DateTime();
                List<ROOMDIAGRAM> listRd = new List<ROOMDIAGRAM>();
                XmlDocument xdoc = new XmlDocument();
                int current;
                int timecheck;
                try
                {
                    listRd = db.ROOMDIAGRAMS.Where(x => x.RoomTestID == _roomTestID).ToList();
                    if (listRd.Count > 0)
                    {
                        foreach (ROOMDIAGRAM rd in listRd)
                        {
                            if (rd.Description != null)
                            {
                                xdoc.LoadXml(rd.Description);

                                XmlNodeList nodelist = xdoc.DocumentElement.SelectNodes("Computer");
                                foreach (XmlNode node in nodelist)
                                {
                                    dt = Convert.ToDateTime(node.FirstChild.InnerText);
                                    timecheck =ConvertDateTimeToUnix(dt);
                                    current = ConvertDateTimeToUnix(GetDateTimeServer());
                                    if (current - timecheck > 180)
                                    {
                                        rd.Status = 4002;

                                    }
                                    else if (current - timecheck < 180)
                                    {
                                        if (rd.Status == 4003)
                                        {
                                            rd.Status = 4003;
                                        }
                                        else
                                        {
                                            rd.Status = 4001;
                                        }
                                    }


                                }
                            }
                            else
                            {
                                if (rd.Status == 4003)
                                {
                                    rd.Status = 4003;
                                }
                                else
                                {
                                    rd.Status = 4002;
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                }

                catch 
                {
                }

            }
        }
    }
  
       
    }

