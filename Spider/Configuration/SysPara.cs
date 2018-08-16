using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spider.Configuration
{
    class SysPara
    {
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public string ProgramName
        {
            get { return this._programname; }
            set { this._programname = value; }
        }

        private string _programname;

        /// <summary>
        /// 是否清空记录标志
        /// </summary>
        public string IsClearData
        {
            get { return this._iscleardata; }
            set { this._iscleardata = value; }
        }

        private string _iscleardata;

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime
        {
            get { return this._endtime; }
            set { this._endtime = value; }
        }

        private string _endtime;

        /// <summary>
        /// 主程序休眠时间
        /// </summary>
        public int MainSleepTime
        {
            get { return this._mainsleeptime; }
            set { this._mainsleeptime = value; }
        }

        private int _mainsleeptime;

        /// <summary>
        /// 检查周期
        /// </summary>
        public int CheckTime
        {
            get { return this._checktime; }
            set { this._checktime = value; }
        }

        private int _checktime;

        /// <summary>
        /// 开始抓取连接超时时长
        /// </summary>
        public int BegTimeOut
        {
            get { return this._begtimeout; }
            set { this._begtimeout = value; }
        }

        private int _begtimeout;

        /// <summary>
        /// 抓取连接递增间隔超时时长
        /// </summary>
        public int IntervalTimeOut
        {
            get { return this._intervaltimeout; }
            set { this._intervaltimeout = value; }
        }

        private int _intervaltimeout;

        /// <summary>
        /// 开始抓取读写超时时长
        /// </summary>
        public int BegRWTimeOut
        {
            get { return this._begrwtimeout; }
            set { this._begrwtimeout = value; }
        }

        private int _begrwtimeout;

        /// <summary>
        /// 抓取读写超时递增间隔时长
        /// </summary>
        public int IntervalRWTimeOut
        {
            get { return this._intervalrwtimeout; }
            set { this._intervalrwtimeout = value; }
        }

        private int _intervalrwtimeout;

        /// <summary>
        /// 开始抓取间隔时长
        /// </summary>
        public int BegSpiderIntervalTime
        {
            get { return this._begspiderintervaltime; }
            set { this._begspiderintervaltime = value; }
        }

        private int _begspiderintervaltime;

        /// <summary>
        /// 抓取递增间隔时长
        /// </summary>
        public int IntervalSpiderIntervalTime
        {
            get { return this._intervalspiderintervaltime; }
            set { this._intervalspiderintervaltime = value; }
        }


        private int _intervalspiderintervaltime;

        /// <summary>
        /// 最大失败次数
        /// </summary>
        public int MaxTrySpidertimes
        {
            get { return this._maxtryspidertimes; }
            set { this._maxtryspidertimes = value; }
        }

        private int _maxtryspidertimes;


        /// <summary>
        /// 如果SpiderList中没值，间隔时间
        /// </summary>
        public int IntervalSpiderTime
        {
            get { return this._intervalspidertime; }
            set { this._intervalspidertime = value; }
        }

        private int _intervalspidertime;

        /// <summary>
        /// 如果AnalysisList中没值，间隔时间
        /// </summary>
        public int IntervalAnalysisTime
        {
            get { return this._intervalanalysistime; }
            set { this._intervalanalysistime = value; }
        }

        private int _intervalanalysistime;

        /// <summary>
        /// 如果DBList中没值，间隔时间
        /// </summary>
        public int IntervalDBTime
        {
            get { return this._intervaldbtime; }
            set { this._intervaldbtime = value; }
        }

        private int _intervaldbtime;

        /// <summary>
        /// 如果LogList中没值，间隔时间
        /// </summary>
        public int IntervalLogTime
        {
            get { return this._intervallogtime; }
            set { this._intervallogtime = value; }
        }

        private int _intervallogtime;

        /// <summary>
        /// AnalysisList中最大页面数
        /// </summary>
        public int MaxPage
        {
            get { return this._maxpage; }
            set { this._maxpage = value; }
        }

        private int _maxpage;

        /// <summary>
        /// AnalysisList超过最大页面数，抓取线程休眠时间
        /// </summary>
        public int SpiderSleepTime
        {
            get { return this._spidersleeptime; }
            set { this._spidersleeptime = value; }
        }

        private int _spidersleeptime;



        /// <summary>
        /// 抓取线程数量
        /// </summary>
        public int MaxSpiderDataUrl { get; set; }
        /// <summary>
        /// 抓取最大深度
        /// </summary>
        public int MaxDepth
        {
            get { return this._maxdepth; }
            set { this._maxdepth = value; }
        }

        private int _maxdepth;

        /// <summary>
        /// 网络不通，抓取线程休眠时间
        /// </summary>
        public int NetSleepTime
        {
            get { return this._netsleeptime; }
            set { this._netsleeptime = value; }
        }

        private int _netsleeptime;

        /// <summary>
        /// 是否抓取房源
        /// </summary>
        public string IsSpiderHouse
        {
            get { return this._isspiderhouse; }
            set { this._isspiderhouse = value; }
        }

        private string _isspiderhouse;

        /// <summary>
        /// 是否抓取楼盘
        /// </summary>
        public string IsSpiderBatch
        {
            get { return this._isspiderbatch; }
            set { this._isspiderbatch = value; }
        }

        private string _isspiderbatch;

        /// <summary>
        /// 是否抓取楼栋翻页
        /// </summary>
        public string IsSpiderBuildNext
        {
            get { return this._isspiderbuildnext; }
            set { this._isspiderbuildnext = value; }
        }

        private string _isspiderbuildnext;

        /// <summary>
        /// 是否抓取房间
        /// </summary>
        public string IsSpiderRoom
        {
            get { return this._isspiderroom; }
            set { this._isspiderroom = value; }
        }

        private string _isspiderroom;

        /// <summary>
        /// 是否抓取房间状态
        /// </summary>
        public string IsSpiderRoomState
        {
            get { return this._isspiderroomstate; }
            set { this._isspiderroomstate = value; }
        }

        private string _isspiderroomstate;

        /// <summary>
        /// 是否抓取房源图片
        /// </summary>
        public string IsFlateImg
        {
            get { return this._isflateimg; }
            set { this._isflateimg = value; }
        }

        private string _isflateimg;

        /// <summary>
        /// 程序索引号
        /// </summary>
        public int PIndex
        {
            get { return this._pindex; }
            set { this._pindex = value; }
        }

        private int _pindex;

        /// <summary>
        /// 程序总数量
        /// </summary>
        public int PCount
        {
            get { return this._pcount; }
            set { this._pcount = value; }
        }

        private int _pcount;
        /// <summary>
        /// 代理url
        /// </summary>
        public string ProxyURL { get; set; }

        public string IsProxy { get; set; }
    }
}
