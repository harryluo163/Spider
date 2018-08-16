using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SpiderApp.entity
{
    [XmlRoot("bddatalist")]
    public class bddatalist
    {
        [XmlElement("bddata")]
        public List<bddata> DataSource { get; set; }
    }


    [XmlType("bddata")]
    public class bddata
    {
        public bddata()
        {
            id = "";
            spiderTime = "";
            spiderIP = "";
            spiderUser = "";
            spiderMAC = "";
            phone = "";
            isUse = "";
            isUse = "";
            issm = "";
            gcar = "";
            yhhd = "";
        }
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlAttribute("spiderTime")]
        public string spiderTime { get; set; }

        [XmlAttribute("spiderIP")]
        public string spiderIP { get; set; }

        [XmlAttribute("spiderUser")]
        public string spiderUser { get; set; }

        [XmlAttribute("spiderMAC")]
        public string spiderMAC { get; set; }

        [XmlAttribute("phone")]
        public string phone { get; set; }


        [XmlAttribute("isUse")]
        public string isUse { get; set; }

        [XmlAttribute("issm")]
        public string issm { get; set; }

        [XmlAttribute("gcar")]
        public string gcar { get; set; }



        [XmlAttribute("yhhd")]
        public string yhhd { get; set; }

    }
}
