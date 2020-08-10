using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.SubModel
{
  public   class Common
    {
        public static string GetConnectString(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            EntityConnectionStringBuilder entityConnection = new EntityConnectionStringBuilder(config.ConnectionStrings.ConnectionStrings[key].ConnectionString);
            return entityConnection.ProviderConnectionString;
        }
    }
}
