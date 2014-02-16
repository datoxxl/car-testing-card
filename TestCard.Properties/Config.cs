using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace TestCard.Properties
{
    public static class Config
    {
        public static string DefaultCulture
        {
            get
            {
                return (ConfigurationManager.GetSection("system.web/globalization") as GlobalizationSection).Culture;
            }
        }

        public static string FilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["FilePath"];
            }
        }
    }
}
