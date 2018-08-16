using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Spider.Configuration
{
    public class NetConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("netCollection", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(NetCollection), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap, RemoveItemName = "remove")]
        public NetCollection proxyCollection
        {
            get
            {
                return (NetCollection)base["netCollection"];
            }
            set
            {
                base["netCollection"] = value;
            }
        }
    }
}
