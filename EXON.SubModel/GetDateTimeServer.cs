using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.SubModel.Models;
namespace EXON.SubModel
{
   public class GetDateTimeServer
    {

        public static DateTime GetDateTime()
        {
            MTAQuizDbContext db = new MTAQuizDbContext();
            return db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
        }
    }
}
