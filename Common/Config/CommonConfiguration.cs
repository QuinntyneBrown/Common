using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Config
{
    public class CommonConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("internalSecret")]
        public string InternalSecret
        {
            get { return (string)this["internalSecret"]; }
            set { this["internalSecret"] = value; }
        }

        public static CommonConfiguration Config
        {
            get { return ConfigurationManager.GetSection("commonConfiguration") as CommonConfiguration; }
        }
    }
}
