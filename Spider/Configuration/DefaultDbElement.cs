using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Spider.Configuration
{
    class DefaultDbElement : ConfigurationElement 
    {
        private static ConfigurationPropertyCollection _properties;
        private static ConfigurationProperty _value;

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }

        static DefaultDbElement()
        {
            _value = new ConfigurationProperty("value", typeof(string), "",
                ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_value);
        }
    }
}
