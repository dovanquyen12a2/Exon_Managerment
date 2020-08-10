using EXON.SubData.Infrastructures;
using System;
using System.Linq;

namespace EXON.SubData.Services
{
    public class SystemTimeService
    {
        private IDbFactory dbFactory;

        public SystemTimeService()
        {
            dbFactory = new DbFactory();
        }

        public static DateTime Now
        {
            get
            {
                try
                {
                    return GetDateTimeServer();
                }
                catch
                { throw new Exception("Not Connected Server"); }
            }
        }

        private static DateTime GetDateTimeServer()
        {
            return (new MTAQuizDbContext()).Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
        }
    }
}