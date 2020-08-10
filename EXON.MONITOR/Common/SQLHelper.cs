using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.MONITOR.Common
{
    public class SQLHelper
    {
        SqlConnection conn;
        public SQLHelper(string connectString)
        {
            conn = new SqlConnection(connectString);
        }
        public bool IsConnection
        {
            get
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
