using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SpiderApp.entity
{
    [XmlRoot("IPList")]
    public class IPList
    {
        [XmlElement("_IP")]
        public List<_IP> DataSource { get; set; }
    }

    [XmlType("_IP")]
    public class _IP
    {
        [XmlAttribute("ip")]
        public string ip { get; set; }

     
    }
    }
