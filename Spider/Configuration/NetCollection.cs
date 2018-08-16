using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Spider.Configuration
{
    public class NetCollection : ConfigurationElementCollection
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NetConfigElement)element).id;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new NetConfigElement();
        }

        public NetConfigElement this[int i]
        {
            get
            {
                return (NetConfigElement)base.BaseGet(i);
            }
        }

        public NetConfigElement this[string key]
        {
            get
            {
                return (NetConfigElement)base.BaseGet(key);
            }
        }
    }
}
