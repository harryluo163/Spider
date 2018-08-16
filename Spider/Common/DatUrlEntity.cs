/***************************************
* Author: Gong Xuanlong
* Date  : 2013-05-10
****************************************/

using System;
//using System.Runtime.Serialization;  //如果要支持WCF,請去掉註釋符號


namespace Spider.BizEntity {
    [Serializable]
    public class DatUrlEntity {

        public DatUrlEntity() {
            SetDefaultValue();
        }

        public string ID{
            get { return _id; }
            set { 
                _id = value;
            }
        }
        private string _id;

        public string KeyWord
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
            }
        }
        private string _keyword;

        public string ProgramName{
            get { return _programname; }
            set { 
                _programname = value;
            }
        }
        private string _programname;

        public string SpiderDate{
            get { return _spiderdate; }
            set { 
                _spiderdate = value;
            }
        }
        private string _spiderdate;

        public string PID{
            get { return _pid; }
            set { 
                _pid = value;
            }
        }
        private string _pid;

        public string SType{
            get { return _stype; }
            set { 
                _stype = value;
            }
        }
        private string _stype;

        public string SiteUrl
        {
            get { return _siteurl; }
            set {
                _siteurl = value;
            }
        }
        private string _siteurl;

        public string SourUrl{
            get { return _soururl; }
            set { 
                _soururl = value;
            }
        }
        private string _soururl;

        public string Url{
            get { return _url; }
            set { 
                _url = value;
            }
        }
        private string _url;

        public string UrlType{
            get { return _urltype; }
            set { 
                _urltype = value;
            }
        }
        private string _urltype;

        public string UrlPara{
            get { return _urlpara; }
            set { 
                _urlpara = value;
            }
        }
        private string _urlpara;

        public string EnCode
        {
            get { return _encode; }
            set
            {
                _encode = value;
            }
        }
        private string _encode;

        public string APara
        {
            get { return _apara; }
            set
            {
                _apara = value;
            }
        }
        private string _apara;

        public string CookieContent{
            get { return _cookiecontent; }
            set { 
                _cookiecontent = value;
            }
        }
        private string _cookiecontent;

        public string AContent{
            get { return _acontent; }
            set { 
                _acontent = value;
            }
        }
        private string _acontent;

        public string PConent{
            get { return _pconent; }
            set { 
                _pconent = value;
            }
        }
        private string _pconent;

        public int TrySpiderTimes{
            get { return _tryspidertimes; }
            set { 
                _tryspidertimes = value;
            }
        }
        private int _tryspidertimes;


        public int Depth
        {
            get { return _depth; }
            set
            {
                _depth = value;
            }
        }
        private int _depth;

        public DateTime? SpiderTime{
            get { return _spidertime; }
            set { 
                _spidertime = value;
            }
        }
        private DateTime? _spidertime;

        public string ErrorMsg{
            get { return _errormsg; }
            set { 
                _errormsg = value;
            }
        }
        private string _errormsg;


        public DatUrlEntity Clone() {
            return (DatUrlEntity)this.MemberwiseClone();
        }

        private void SetDefaultValue() {

            _id = "";
            _keyword = "";
            _programname = "";
            _spiderdate = "";
            _pid = "";
            _stype = "";
            _siteurl = "";
            _soururl = "";
            _url = "";
            _urltype = "";
            _urlpara = "";
            _encode = "GB2312";
            _apara = "";
            _cookiecontent = "";
            _acontent = "";
            _pconent = "";
            _spidertime = null;
            _errormsg = "";
        }


    }
}
