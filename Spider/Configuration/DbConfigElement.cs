using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Spider.Configuration
{
    class DbConfigElement : ConfigurationElement
    {
        private static ConfigurationPropertyCollection _properties;

        private static ConfigurationProperty _name;
        private static ConfigurationProperty _encryptedString;
        private static ConfigurationProperty _plainString;

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        public string Name
        {
            get { return (string)this["name"]; }
        }
        public string EncryptedString
        {
            get { return (string)this["encryptedString"]; }
        }
        public string PlainString
        {
            get { return (string)this["plainString"]; }
        }

        static DbConfigElement()
        {
            // Initialize the _name 
            _name = new ConfigurationProperty("name", typeof(string), "",
                ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);
            _encryptedString = new ConfigurationProperty("encryptedString", typeof(string), "",
                ConfigurationPropertyOptions.IsRequired);
            _plainString = new ConfigurationProperty("plainString", typeof(string), "",
                ConfigurationPropertyOptions.IsRequired);

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_name);
            _properties.Add(_encryptedString);
            _properties.Add(_plainString);
        }
    }
}
