using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Spider.Configuration
{
    public class NetConfigElement : ConfigurationElement
    {
        /// <summary>
        /// ID
        /// </summary>
        [ConfigurationProperty("id", IsRequired = true, DefaultValue = "")]
        public string id
        {
            get
            {
                return (string)base["id"];
            }
            set
            {
                base["id"] = (string)value;
            }
        }
        
        /// <summary>
        /// encryptedString
        /// </summary>
        [ConfigurationProperty("encryptedString", IsRequired = true, DefaultValue = "U1ezh4GlVx2b6BVsQjVqelFw1m28/Hx4NteNQnG6IFRTaWbjZizqkP48679OFd54")]
        public string encryptedString
        {
            get
            {
                return (string)base["encryptedString"];
            }
            set
            {
                base["encryptedString"] = value;
            }
        }

        /// <summary>
        /// proxyEntity
        /// </summary>
        public ProxyEntity proxyEntity {

            get {
                return _proxyEntity;
            }
            set {
                _proxyEntity = value;                
            }
        }
        private ProxyEntity _proxyEntity;

        /// <summary>
        /// begTime
        /// </summary>
        [ConfigurationProperty("begTime", IsRequired = true, DefaultValue = 17)]
        public int begTime
        {
            get
            {
                return (int)base["begTime"];
            }
            set
            {
                base["begTime"] = value;
            }
        }

        /// <summary>
        /// EndTime
        /// </summary>
        [ConfigurationProperty("endTime", IsRequired = true, DefaultValue = 8)]
        public int endTime
        {
            get
            {
                return (int)base["endTime"];
            }
            set
            {
                base["endTime"] = value;
            }
        }


        /// <summary>
        /// seqNo
        /// </summary>
        [ConfigurationProperty("seqNo", IsRequired = true, DefaultValue = 0)]
        public int seqNo
        {
            get
            {
                return (int)base["seqNo"];
            }
            set
            {
                base["seqNo"] = value;
            }
        }

        /// <summary>
        /// jumpIp
        /// </summary>
        [ConfigurationProperty("jumpIp", IsRequired = true, DefaultValue = false)]
        public bool jumpIp
        {
            get
            {
                return (bool)base["jumpIp"];
            }
            set
            {
                base["jumpIp"] = value;
            }
        }

        /// <summary>
        /// proxy
        /// </summary>
        [ConfigurationProperty("proxy", IsRequired = true, DefaultValue = false)]
        public bool proxy
        {
            get
            {
                return (bool)base["proxy"];
            }
            set
            {
                base["proxy"] = value;
            }
        }
        
        /// <summary>
        /// currUse
        /// </summary>
        [ConfigurationProperty("currUse", IsRequired = true, DefaultValue = false)]
        public bool currUse
        {
            get
            {
                return (bool)base["currUse"];
            }
            set
            {
                base["currUse"] = value;
            }
        }

        /// <summary>
        /// netStatus
        /// </summary>
        [ConfigurationProperty("netStatus", IsRequired = true, DefaultValue = true)]
        public bool netStatus
        {
            get
            {
                return (bool)base["netStatus"];
            }
            set
            {
                base["netStatus"] = value;
            }
        }

        /// <summary>
        /// msmq
        /// </summary>
        [ConfigurationProperty("msmq", IsRequired = true, DefaultValue = true)]
        public bool msmq
        {
            get
            {
                return (bool)base["msmq"];
            }
            set
            {
                base["msmq"] = value;
            }
        }
    }
}