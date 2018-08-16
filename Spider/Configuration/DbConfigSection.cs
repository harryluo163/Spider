using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Spider.Configuration
{
    class DbConfigSection : ConfigurationSection
    {
               private static ConfigurationPropertyCollection _properties;
        protected override ConfigurationPropertyCollection Properties {
            get { return _properties; }
        }

        private static ConfigurationProperty _defaultDb;
        public DefaultDbElement DefaultDb {
            get { return (DefaultDbElement)this["defaultDb"]; }
        }

        /// <summary>
        ///对于defaultCollection类型的集合:
        ///1.必须用下面这种语法:get { return (DbCollection)base[_dbCollection]; },不能用this["db"]这种语法。
        ///2.构造函数中name参数的值为null或空字符串，要带上ConfigurationPropertyOptions.IsDefaultCollection
        ///3.集合的定义中要覆写CollectionType和ElementName两个属性
        /// </summary>
        public DbCollection DbCollection {
            get { return (DbCollection)base[_dbCollection]; }
        }
        private static ConfigurationProperty _dbCollection;


        static DbConfigSection() {
            _defaultDb = new ConfigurationProperty("defaultDb", typeof(DefaultDbElement), null, ConfigurationPropertyOptions.IsRequired);
            _dbCollection = new ConfigurationProperty("", typeof(DbCollection), null, ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsDefaultCollection);

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_defaultDb);
            _properties.Add(_dbCollection);
        }
    }
}
