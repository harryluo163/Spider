using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using Spider.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using SpiderApp.entity;

namespace Spider.Common
{
    //此类主要控制使用网络访问数据，一般所有配置网络循环使用，如果当前网络不能使用，则将能使用的网络上移优先级
    class NetContorl
    {
        #region 通过代理IP接口访问
        public ProxyEntity GetProxyEntity_URL()
        {
            Configuration.ProxyEntity proxyDetailEntity = new Configuration.ProxyEntity();
            //GET获取代理IP
            if (Program.proxyList_URL.Count == 0) GetProxy_URL();
            if (Program.proxyList_URL.Count > 0)
            {
                string address = Program.proxyList_URL[0];
                proxyDetailEntity.IsProxy = true;
                proxyDetailEntity.proxyAddess = address;
                proxyDetailEntity.proxyUid = "";
                proxyDetailEntity.proxyPwd = "";
                proxyDetailEntity.msmqMsgPath = "";

            }
            return proxyDetailEntity;


        }

        public ProxyEntity GetProxyEntity_URL2()
        {
            Configuration.ProxyEntity proxyDetailEntity = new Configuration.ProxyEntity();
            _IP ip = getip();
            proxyDetailEntity.IsProxy = true;
            proxyDetailEntity.proxyAddess = ip.ip;
            proxyDetailEntity.proxyUid = "";
            proxyDetailEntity.proxyPwd = "";
            proxyDetailEntity.msmqMsgPath = "";
            return proxyDetailEntity;
        }
        public bool GetProxy_URL()
        {
            Thread.Sleep(1000); //接口限制，休眠1s
            WebClient client = new WebClient();
            //client.Encoding = Encoding.UTF8;
            var address = Program.sysPara.ProxyURL;
            string content = client.DownloadString(address);

            List<string> arr = new List<string>();
            Regex regex = new Regex("(?<=proxy_list\":)(.|\n)*?(?=\\})", RegexOptions.IgnoreCase);
            Match m = regex.Match(content);
            if (m.Length > 0)
            {
                regex = new Regex("(?<=\")(.|\n)*?(?=\")", RegexOptions.IgnoreCase);
                MatchCollection mc = regex.Matches(m.Value.ToString() + ",");
                foreach (Match mm in mc)
                {
                    if (mm.Value.Contains("."))
                        Program.proxyList_URL.Add("http://" + mm.Value.Trim());

                    ////测试用固定IP
                    //Program.proxyList_URL.Add("");
                }
            }
            return true;
        }


        public _IP getip()
        {
            _IP ip = new _IP();


            ip = Program.IPList.Take();
            Program.IPList.Add(ip);

            return ip;

        }
        #endregion
    }
}
