using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Spider.Configuration
{
    class DbCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DbConfigElement();
        }
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((DbConfigElement)element).Name;
        }
        protected override string ElementName
        {
            get { return "db"; }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;  //AddRemoveClearMap|BasicMap;
            }
        }
        protected override bool ThrowOnDuplicate
        {
            get { return true; }
        }

        public DbConfigElement this[int index]
        {
            get { return (DbConfigElement)base.BaseGet(index); }
        }
        new public DbConfigElement this[string name]
        {
            get { return (DbConfigElement)base.BaseGet(name); }
        }
    }
}
