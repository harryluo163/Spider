using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Concurrent;
using DataSpider.Page;

namespace Spider.Common
{
    class CommonFunc
    {
        public bool InitialFunc()
        {
            bool flag = true;
            #region 取配置参数
            Program.sysPara.ProgramName = ConfigurationManager.AppSettings["ProgramName"].ToString();
            Program.sysPara.IsClearData = ConfigurationManager.AppSettings["IsClearData"].ToString();
            Program.sysPara.EndTime = ConfigurationManager.AppSettings["EndTime"].ToString();
            Program.sysPara.MainSleepTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["MainSleepTime"].ToString());
            Program.sysPara.CheckTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["CheckTime"].ToString());
            Program.sysPara.BegTimeOut = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["BegTimeOut"].ToString());
            Program.sysPara.IntervalTimeOut = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["IntervalTimeOut"].ToString());
            Program.sysPara.BegRWTimeOut = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["BegRWTimeOut"].ToString());
            Program.sysPara.IntervalRWTimeOut = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["IntervalRWTimeOut"].ToString());
            Program.sysPara.BegSpiderIntervalTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["BegSpiderIntervalTime"].ToString());
            Program.sysPara.IntervalSpiderIntervalTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["IntervalSpiderIntervalTime"].ToString());
            Program.sysPara.MaxTrySpidertimes = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["MaxTrySpidertimes"].ToString());
            Program.sysPara.IntervalSpiderTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["IntervalSpiderTime"].ToString());
            Program.sysPara.IntervalAnalysisTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["IntervalAnalysisTime"].ToString());
            Program.sysPara.IntervalDBTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["IntervalDBTime"].ToString());
            Program.sysPara.IntervalLogTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["IntervalLogTime"].ToString());
            Program.sysPara.MaxSpiderDataUrl = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["MaxSpiderDataUrl"].ToString());
            Program.sysPara.MaxPage = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["MaxPage"].ToString());
            Program.sysPara.SpiderSleepTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["SpiderSleepTime"].ToString());
            Program.sysPara.MaxDepth = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["MaxDepth"].ToString());
            Program.sysPara.NetSleepTime = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["NetSleepTime"].ToString());
            Program.sysPara.IsSpiderBatch = ConfigurationManager.AppSettings["IsSpiderBatch"].ToString();
            Program.sysPara.IsSpiderBuildNext = ConfigurationManager.AppSettings["IsSpiderBuildNext"].ToString();
            Program.sysPara.IsSpiderRoom = ConfigurationManager.AppSettings["IsSpiderRoom"].ToString();
            Program.sysPara.IsSpiderRoomState = ConfigurationManager.AppSettings["IsSpiderRoomState"].ToString();
            Program.sysPara.IsFlateImg = ConfigurationManager.AppSettings["IsFlateImg"].ToString();
            Program.sysPara.IsSpiderHouse = ConfigurationManager.AppSettings["IsSpiderHouse"].ToString();
            Program.sysPara.PIndex = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["PIndex"].ToString());
            Program.sysPara.PCount = Common.TypeConverter.StrToInt(ConfigurationManager.AppSettings["PCount"].ToString());
            Program.sysPara.IsProxy = ConfigurationManager.AppSettings["IsProxy"].ToString();
            Program.sysPara.ProxyURL = ConfigurationManager.AppSettings["ProxyURL"].ToString();

            Program.pageContentList = new BlockingCollection<PageContentEntity>(Program.sysPara.MaxPage); //设置最大集合量，超过休眠阻塞


            #endregion

            #region 取当前日期
            DateTime now = DateTime.Now;
            DateTime EndDate = Convert.ToDateTime(now.ToString("yyyy-MM-dd") + " " + Program.sysPara.EndTime);
            //取时间
            int hh = now.Hour;
            if (now <= EndDate)
            {
                Program.SpiderDate = now.AddDays(-1).ToString("yyyy-MM-dd");
            }
            else
            {
                Program.SpiderDate = now.ToString("yyyy-MM-dd");
            }
            #endregion


            return flag;
        }

        #region 取附加参数
        public Hashtable GetAPara(string str)
        {
            Hashtable ht = new Hashtable();
            string[] AParaArgs = str.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string regular = "(?<key>.*[^:]?):(?<value>.*)";
            Regex regex = new Regex(regular, RegexOptions.IgnoreCase);
            Match m;

            if (AParaArgs.Length > 0)
            {
                for (int i = 0; i < AParaArgs.Length; i++)
                {
                    m = regex.Match(AParaArgs[i]);
                    if (m.Length > 0)
                    {
                        ht.Add(m.Groups["key"].Value, m.Groups["value"].Value);
                    }
                }
            }
            return ht;
        }
        #endregion

        #region 解析代理信息
        public Configuration.ProxyEntity GetProxyEntity(string encryptedString)
        {
            Configuration.ProxyEntity proxyEntity = new Configuration.ProxyEntity();
            string proxyStr = Common.EncUtil.DesDecrypt(encryptedString);
            //分割数据
            string[] proxyInfoArr = proxyStr.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] cc;
            foreach (string c in proxyInfoArr)
            {
                cc = c.Split("=".ToCharArray());
                if (cc.Length > 1)
                {
                    switch (cc[0])
                    {
                        case "proxyAddress": proxyEntity.proxyAddess = cc[1]; break;
                        case "proxyUid": proxyEntity.proxyUid = cc[1]; break;
                        case "proxyPwd": proxyEntity.proxyPwd = cc[1]; break;
                        case "msmqMsgPath": proxyEntity.msmqMsgPath = cc[1]; break;
                        default: break;
                    }
                }
            }
            return proxyEntity;
        }
        #endregion
    }

    public class Mysort : IComparer<Configuration.NetConfigElement>
    {
        public int Compare(Configuration.NetConfigElement x, Configuration.NetConfigElement y)
        {
            if (x != null && y != null)
            {
                return x.seqNo > y.seqNo ? 1 : -1;

            }
            return 0;
        }

    }
}
