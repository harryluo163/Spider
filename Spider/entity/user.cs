using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SpiderApp.entity
{

    [XmlRoot("userList")]
    public class userList
    {
        [XmlElement("user")]
        public List<user> DataSource { get; set; }
    }

    [XmlType("user")]
    public  class user
    {
        [XmlAttribute("userName")]
        public string userName { get; set; }
        
        [XmlAttribute("psw")]
        public string psw { get; set; }
        
        [XmlAttribute("token")]
        public string token { get; set; }
        [XmlAttribute("cookie")]
        public string cookie { get; set; }
    }
}
