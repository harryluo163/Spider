using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Serialization;

namespace Spider.Spider
{
    [XmlRoot("PageUrlEntityList")]
    public class PageUrlEntityList
    {
        [XmlElement("PageUrlEntity")]
        public List<PageUrlEntity> DataSource { get; set; }
    }
    [XmlType("PageUrlEntity")]
    public class PageUrlEntity
    {
        public PageUrlEntity()
        {

            ID = "";
            KeyWord = "";
            ProgramName = "";
            SpiderDate = "";
            PID = "";
            SType = "";
            SiteUrl = "";
            SourUrl = "";
            Url = "";
            UrlType = "";
            UrlPara = "";
            EnCode = "";
            APara = "";
            CookieContent = new CookieContainer();
            AContent = "";
        
            TrySpiderTimes = 0;
            Depth = 0;
            SpiderTime = DateTime.Now;
      
        }

        /// <summary>
        /// 编号
        /// </summary>
        [XmlAttribute("ID")]
        public string ID 
        {
            get {
                return _id;
            }
            set {
                _id = value;
            }
        }
        private string _id;

        /// <summary>
        /// KeyWord
        /// </summary>
        [XmlAttribute("KeyWord")]
        public string KeyWord
        {
            get
            {
                return _keyword;
            }
            set
            {
                _keyword = value;
            }
        }
        private string _keyword;

        /// <summary>
        /// 应用程序名
        /// </summary>
        [XmlAttribute("ProgramName")]
        public string ProgramName
        {
            get
            {
                return _programname;
            }
            set
            {
                _programname = value;
            }
        }
        private string _programname;

        /// <summary>
        /// 日期
        /// </summary>
        [XmlAttribute("SpiderDate")]
        public string SpiderDate
        {
            get
            {
                return _spiderdate;
            }
            set
            {
                _spiderdate = value;
            }
        }

        public string _spiderdate;


        /// <summary>
        /// 父编号
        /// </summary>
        [XmlAttribute("PID")]
        public string PID
        {
            get
            {
                return _pid;
            }
            set
            {
                _pid = value;
            }
        }

        public string _pid;


        /// <summary>
        /// 类型
        /// </summary>
        [XmlAttribute("SType")]
        public string SType
        {
            get
            {
                return _stype;
            }
            set
            {
                _stype = value;
            }
        }

        private string _stype;


        /// <summary>
        /// 站点路径
        /// </summary>
        [XmlAttribute("SiteUrl")]
        public string SiteUrl
        {
            get
            {
                return _siteurl;
            }
            set
            {
                _siteurl = value;
            }
        }

        private string _siteurl;


        /// <summary>
        /// 父页面路径
        /// </summary>
        [XmlAttribute("SourUrl")]
        public string SourUrl
        {
            get
            {
                return _soururl;
            }
            set
            {
                _soururl = value;
            }
        }

        private string _soururl;

        /// <summary>
        /// 页面路径
        /// </summary>
        [XmlAttribute("Url")]
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        private string _url;


        /// <summary>
        /// 抓取方式(GET/POST/MGET)
        /// </summary>
        [XmlAttribute("UrlType")]
        public string UrlType
        {
            get
            {
                return _urltype;
            }
            set
            {
                _urltype = value;
            }
        }

        private string _urltype;


        /// <summary>
        /// 参数
        /// </summary>
        [XmlAttribute("UrlPara")]
        public string UrlPara
        {
            get
            {
                return _urlpara;
            }
            set
            {
                _urlpara = value;
            }
        }

        private string _urlpara;

        /// <summary>
        /// 编码方式
        /// </summary>
        [XmlAttribute("EnCode")]
        public string EnCode
        {
            get
            {
                return _encode;
            }
            set
            {
                _encode = value;
            }
        }

        private string _encode;

        /// <summary>
        /// 附加参数
        /// </summary>
        [XmlAttribute("APara")]
        public string APara
        {
            get
            {
                return _apara;
            }
            set
            {
                _apara = value;
            }
        }

        private string _apara;


        /// <summary>
        /// Cookie值
        /// </summary>
        [XmlAttribute("CookieContent")]
        public CookieContainer CookieContent
        {
            get
            {
                return _cookiecontent;
            }
            set
            {
                _cookiecontent = value;
            }
        }

        private CookieContainer _cookiecontent;


        /// <summary>
        /// 附加内容
        /// </summary>
        [XmlAttribute("AContent")]
        public string AContent
        {
            get
            {
                return _acontent;
            }
            set
            {
                _acontent = value;
            }
        }

        private string _acontent;

        /// <summary>
        ///  页面内容
        /// </summary>
        [XmlAttribute("PContent")]
        public string PContent
        {
            get
            {
                return _pcontent;
            }
            set
            {
                _pcontent = value;
            }
        }

        private string _pcontent;


        /// <summary>
        /// 抓取次数
        /// </summary>
        [XmlAttribute("TrySpiderTimes")]
        public int TrySpiderTimes
        {
            get
            {
                return _tryspidertimes;
            }
            set
            {
                _tryspidertimes = value;
            }
        }

        private int _tryspidertimes;

        /// <summary>
        /// 抓取深度
        /// </summary>
        [XmlAttribute("Depth")]
        public int Depth
        {
            get
            {
                return _depth;
            }
            set
            {
                _depth = value;
            }
        }

        private int _depth;

        /// <summary>
        /// 抓取时间
        /// </summary>
        [XmlAttribute("SpiderTime")]
        public DateTime? SpiderTime
        {
            get
            {
                return _spidertime;
            }
            set
            {
                _spidertime = value;
            }
        }

        private DateTime? _spidertime;
    }
}
