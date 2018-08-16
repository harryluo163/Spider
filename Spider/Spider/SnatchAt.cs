using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Net;
using System.IO.Compression;
using System.Threading;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Net.Cache;

namespace Spider.Spider
{
	class SnatchAt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceUrl">原网页</param>
        /// <param name="UrlStr">请求网页</param>
        /// <param name="EnCode">编码</param>
        /// <param name="CookieContainer">cookie</param>
        /// <param name="proxy">代理</param>
        /// <returns></returns>
        public string GetUrlInfByGet(string SourceUrl, string UrlStr, string EnCode, ref CookieContainer CookieContainer, Configuration.NetConfigElement proxy)
        {
            string ContextStr = "";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream s = null;
            MemoryStream ms = null;
            MemoryStream js = null;
            GZipStream g = null;
            int c = 1024 * 10;
            byte[] data = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(UrlStr);
                if (Program.CurrSpiderTimes == 1) request.Timeout = Program.sysPara.BegTimeOut;
                else request.Timeout = Program.sysPara.BegTimeOut + Common.TypeConverter.ObjectToInt((Math.Pow(2, Program.CurrSpiderTimes - 1))) * Program.sysPara.IntervalTimeOut;
                request.KeepAlive = false;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                if (Program.CurrSpiderTimes == 1) request.ReadWriteTimeout = Program.sysPara.BegRWTimeOut;
                else request.ReadWriteTimeout = Program.sysPara.BegRWTimeOut + Common.TypeConverter.ObjectToInt((Math.Pow(2, Program.CurrSpiderTimes - 1))) * Program.sysPara.IntervalRWTimeOut;
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.CookieContainer = CookieContainer;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
                request.Referer = SourceUrl;
                //request.KeepAlive = true;
                if (proxy.proxy)
                {
                    WebProxy webProxy = new WebProxy();                                      //定义一个网关对象
                    webProxy.Address = new Uri(proxy.proxyEntity.proxyAddess);              //网关服务器:端口
                    webProxy.Credentials = new NetworkCredential(proxy.proxyEntity.proxyUid, proxy.proxyEntity.proxyPwd);      //用戶名,密码
                    request.Proxy = webProxy;
                }
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException)
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                string ce = response.Headers[HttpResponseHeader.ContentEncoding];
                response.Cookies = CookieContainer.GetCookies(request.RequestUri);
                int ContentLength = (int)response.ContentLength;
                s = response.GetResponseStream();
                c = 1024 * 10;
                if (ContentLength < 0)
                {
                    data = new byte[c];
                    ms = new MemoryStream();
                    int l = s.Read(data, 0, c);
                    while (l > 0)
                    {
                        ms.Write(data, 0, l);
                        l = s.Read(data, 0, c);
                    }
                    data = ms.ToArray();
                    ms.Close();
                }
                else
                {
                    data = new byte[ContentLength];
                    int pos = 0;
                    int l;
                    while (ContentLength > 0)
                    {
                        l = s.Read(data, pos, ContentLength);
                        pos += l;
                        ContentLength -= l;
                    }
                }
                if (s != null) s.Close();
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (ce == "gzip")
                {
                    js = new MemoryStream();           // 解压后的流  
                    ms = new MemoryStream(data);       // 用于解压的流  
                    g = new GZipStream(ms, CompressionMode.Decompress);
                    byte[] buffer = new byte[c];                    // 读数据缓冲区     
                    int l = g.Read(buffer, 0, c);                   // 一次读 10K     
                    while (l > 0)
                    {
                        js.Write(buffer, 0, l);
                        l = g.Read(buffer, 0, c);
                    }
                    g.Close();
                    ms.Close();
                    data = js.ToArray();
                    js.Close();
                }
                ContextStr = System.Text.Encoding.GetEncoding(EnCode).GetString(data);
            }
            catch (Exception ex)
            {
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (s != null) s.Close();
                if (ms != null) ms.Close();
                if (js != null) js.Close();
                if (g != null) g.Close();
                throw ex;
            }
            return ContextStr;
        }

        public string GetUrlInfByGet1(string SourceUrl, string UrlStr, string EnCode, ref CookieContainer CookieContainer, Configuration.NetConfigElement proxy)
        {
            string ContextStr = "";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream s = null;
            MemoryStream ms = null;
            MemoryStream js = null;
            GZipStream g = null;
            int c = 1024 * 10;
            byte[] data = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(UrlStr);
                if (Program.CurrSpiderTimes == 1) request.Timeout = Program.sysPara.BegTimeOut;
                else request.Timeout = Program.sysPara.BegTimeOut + Common.TypeConverter.ObjectToInt((Math.Pow(2, Program.CurrSpiderTimes - 1))) * Program.sysPara.IntervalTimeOut;
                request.KeepAlive = false;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                
                if (Program.CurrSpiderTimes == 1) request.ReadWriteTimeout = Program.sysPara.BegRWTimeOut;
                else request.ReadWriteTimeout = Program.sysPara.BegRWTimeOut + Common.TypeConverter.ObjectToInt((Math.Pow(2, Program.CurrSpiderTimes - 1))) * Program.sysPara.IntervalRWTimeOut;
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.CookieContainer = CookieContainer;
                HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                request.CachePolicy = policy;
                request.CookieContainer = new CookieContainer();
                List<Cookie> clst = GetAllCookies(CookieContainer);
                foreach (Cookie cc in clst)
                {
                    if (cc.Name != "myComponents.myCKNEW")
                    {
                        //Regex regex = new Regex("(?<=DateTime=)(.|\n)*");
                        //Match m = regex.Match(cc.Value);
                        //string d = System.Web.HttpUtility.UrlEncode(DateTime.Now.AddSeconds(-1).ToString("yyyy/MM/dd HH:mm:ss"));
                        //cc.Value = cc.Value.Replace(m.Value, d);
                        request.CookieContainer.Add(cc);
                    }
                    
                }

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                request.Referer = SourceUrl;
                request.Headers.Add("Accept-Language", "zh-CN");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                SetHeaderValue(request.Headers, "Connection", "Keep-Alive");
                //request.ContentType = "application/x-www-form-urlencoded";
                //request.Headers.Add("Cache-Control", "no-cache");

                //request.Connection = "Keep-Alive";
                if (proxy.proxy)
                {
                    WebProxy webProxy = new WebProxy();                                      //定义一个网关对象
                    webProxy.Address = new Uri(proxy.proxyEntity.proxyAddess);              //网关服务器:端口
                    webProxy.Credentials = new NetworkCredential(proxy.proxyEntity.proxyUid, proxy.proxyEntity.proxyPwd);      //用戶名,密码
                    request.Proxy = webProxy;
                }
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException)
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                string ce = response.Headers[HttpResponseHeader.ContentEncoding];
                response.Cookies = CookieContainer.GetCookies(request.RequestUri);
                int ContentLength = (int)response.ContentLength;
                s = response.GetResponseStream();
                c = 1024 * 10;
                if (ContentLength < 0)
                {
                    data = new byte[c];
                    ms = new MemoryStream();
                    int l = s.Read(data, 0, c);
                    while (l > 0)
                    {
                        ms.Write(data, 0, l);
                        l = s.Read(data, 0, c);
                    }
                    data = ms.ToArray();
                    ms.Close();
                }
                else
                {
                    data = new byte[ContentLength];
                    int pos = 0;
                    int l;
                    while (ContentLength > 0)
                    {
                        l = s.Read(data, pos, ContentLength);
                        pos += l;
                        ContentLength -= l;
                    }
                }
                if (s != null) s.Close();
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (ce == "gzip")
                {
                    js = new MemoryStream();           // 解压后的流  
                    ms = new MemoryStream(data);       // 用于解压的流  
                    g = new GZipStream(ms, CompressionMode.Decompress);
                    byte[] buffer = new byte[c];                    // 读数据缓冲区     
                    int l = g.Read(buffer, 0, c);                   // 一次读 10K     
                    while (l > 0)
                    {
                        js.Write(buffer, 0, l);
                        l = g.Read(buffer, 0, c);
                    }
                    g.Close();
                    ms.Close();
                    data = js.ToArray();
                    js.Close();
                }
                ContextStr = System.Text.Encoding.GetEncoding(EnCode).GetString(data);
            }
            catch (Exception ex)
            {
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (s != null) s.Close();
                if (ms != null) ms.Close();
                if (js != null) js.Close();
                if (g != null) g.Close();
                throw ex;
            }
            return ContextStr;
        }

        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as System.Collections.Specialized.NameValueCollection;
                collection[name] = value;
            }
        }


        public string getUrlInfByPost(string SourceUrl, string UrlStr, string postDataStr, string EnCode, ref CookieContainer CookieContainer, Configuration.NetConfigElement proxy)
        {
            string ContextStr = "";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream myRequestStream = null;
            StreamWriter myStreamWriter = null;
            Stream s = null;
            MemoryStream ms = null;
            MemoryStream js = null;
            GZipStream g = null;
            int c = 1024 * 10;
            byte[] data = null;
            try
            {
                ServicePointManager.Expect100Continue = false;
                request = (HttpWebRequest)WebRequest.Create(UrlStr);
                if (Program.CurrSpiderTimes == 1) request.Timeout = Program.sysPara.BegTimeOut;
                else request.Timeout = Program.sysPara.BegTimeOut + Common.TypeConverter.ObjectToInt((Math.Pow(2, Program.CurrSpiderTimes - 1))) * Program.sysPara.IntervalTimeOut;
                request.KeepAlive = false;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                if (Program.CurrSpiderTimes == 1) request.ReadWriteTimeout = Program.sysPara.BegRWTimeOut;
                else request.ReadWriteTimeout = Program.sysPara.BegRWTimeOut + Common.TypeConverter.ObjectToInt((Math.Pow(2, Program.CurrSpiderTimes - 1))) * Program.sysPara.IntervalRWTimeOut;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.CookieContainer = CookieContainer;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.Referer = SourceUrl;
                HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                request.CachePolicy = policy;
                if (proxy.proxy)
                {
                    WebProxy webProxy = new WebProxy();                                      //定义一个网关对象
                    webProxy.Address = new Uri(proxy.proxyEntity.proxyAddess);              //网关服务器:端口
                    webProxy.Credentials = new NetworkCredential(proxy.proxyEntity.proxyUid, proxy.proxyEntity.proxyPwd);      //用戶名,密码
                    request.Proxy = webProxy;
                }
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] byte1 = encoding.GetBytes(postDataStr);
                request.ContentLength = byte1.Length;
                myRequestStream = request.GetRequestStream();
                myRequestStream.Write(byte1, 0, byte1.Length);
                myRequestStream.Close();
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException)
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                string ce = response.Headers[HttpResponseHeader.ContentEncoding];
                response.Cookies = CookieContainer.GetCookies(request.RequestUri);

                int ContentLength = (int)response.ContentLength;
                s = response.GetResponseStream();
                if (ContentLength < 0)
                {
                    data = new byte[c];
                    ms = new MemoryStream();
                    int l = s.Read(data, 0, c);
                    while (l > 0)
                    {
                        ms.Write(data, 0, l);
                        l = s.Read(data, 0, c);
                    }
                    data = ms.ToArray();
                    ms.Close();
                }
                else
                {
                    data = new byte[ContentLength];
                    int pos = 0;
                    int l;
                    while (ContentLength > 0)
                    {
                        l = s.Read(data, pos, ContentLength);
                        pos += l;
                        ContentLength -= l;
                    }
                }
                if (s != null) s.Close();
                if (request != null) request.Abort();
                string setCookieStr = response.GetResponseHeader("Set-Cookie");
                if (response != null) response.Close();
                if (ce == "gzip")
                {
                    js = new MemoryStream();           // 解压后的流  
                    ms = new MemoryStream(data);       // 用于解压的流  
                    g = new GZipStream(ms, CompressionMode.Decompress);
                    byte[] buffer = new byte[c];                    // 读数据缓冲区     
                    int l = g.Read(buffer, 0, c);                   // 一次读 10K     
                    while (l > 0)
                    {
                        js.Write(buffer, 0, l);
                        l = g.Read(buffer, 0, c);
                    }
                    g.Close();
                    ms.Close();
                    data = js.ToArray();
                    js.Close();
                }
                
                ContextStr = System.Text.Encoding.GetEncoding(EnCode).GetString(data);
            }
            catch (Exception ex)
            {
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (myRequestStream != null) myRequestStream.Close();
                if (myStreamWriter != null) myStreamWriter.Close();
                if (s != null) s.Close();
                if (ms != null) ms.Close();
                if (js != null) js.Close();
                if (g != null) g.Close();
                throw ex;
            }
            return ContextStr;
        }

        public string GetUrlInfByPostRoom(string PostUrl, string SourceUrl, string UrlStr, string postDataStr, string EnCode, ref CookieContainer CookieContainer, Configuration.NetConfigElement proxy)
        {
            string ContextStr = "";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream myRequestStream = null;
            StreamWriter myStreamWriter = null;
            Stream s = null;
            MemoryStream ms = null;
            MemoryStream js = null;
            GZipStream g = null;
            try
            {
                ServicePointManager.Expect100Continue = false;
                request = (HttpWebRequest)WebRequest.Create(UrlStr);
                if (Program.CurrSpiderTimes == 1) request.Timeout = Program.sysPara.BegTimeOut;
                else request.Timeout = Program.sysPara.BegTimeOut + Common.TypeConverter.ObjectToInt((Math.Pow(2, Program.CurrSpiderTimes - 1))) * Program.sysPara.IntervalTimeOut;
                request.KeepAlive = false;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                if (Program.CurrSpiderTimes == 1) request.ReadWriteTimeout = Program.sysPara.BegRWTimeOut;
                else request.ReadWriteTimeout = Program.sysPara.BegRWTimeOut + Common.TypeConverter.ObjectToInt((Math.Pow(2, Program.CurrSpiderTimes - 1))) * Program.sysPara.IntervalRWTimeOut;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.CookieContainer = CookieContainer;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.Referer = SourceUrl;
                if (proxy.proxy)
                {
                    WebProxy webProxy = new WebProxy();                                      //定义一个网关对象
                    webProxy.Address = new Uri(proxy.proxyEntity.proxyAddess);              //网关服务器:端口
                    webProxy.Credentials = new NetworkCredential(proxy.proxyEntity.proxyUid, proxy.proxyEntity.proxyPwd);      //用戶名,密码
                    request.Proxy = webProxy;
                }
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] byte1 = encoding.GetBytes(postDataStr);
                request.ContentLength = byte1.Length;
                myRequestStream = request.GetRequestStream();
                myRequestStream.Write(byte1, 0, byte1.Length);
                myRequestStream.Close();
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException)
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                string ce = response.Headers[HttpResponseHeader.ContentEncoding];
                response.Cookies = CookieContainer.GetCookies(request.RequestUri);
                //PostUrl = "http://www.gzwsfdc.com/touming/RoomInfo.aspx";
                ContextStr = GetUrlInfByGet(UrlStr, PostUrl, EnCode, ref CookieContainer, proxy);
            }
            catch (Exception ex)
            {
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (myRequestStream != null) myRequestStream.Close();
                if (myStreamWriter != null) myStreamWriter.Close();
                if (s != null) s.Close();
                if (ms != null) ms.Close();
                if (js != null) js.Close();
                if (g != null) g.Close();
                throw ex;
            }
            return ContextStr;
        }

        public Bitmap getUrlImg(string SourceUrl, string UrlStr, ref  CookieContainer CookieContainer, Configuration.NetConfigElement proxy)
        {
            Bitmap map_bitMap;
            HttpWebRequest request = null;
            Stream responseStream = null;
            try
            {

                request = (HttpWebRequest)WebRequest.Create(UrlStr);
                request.Timeout = 600000;
                request.ReadWriteTimeout = 600000;
                request.Referer = SourceUrl;
                request.CookieContainer = CookieContainer;
                if (proxy.proxy)
                {
                    WebProxy webProxy = new WebProxy();                                      //定义一个网关对象
                    webProxy.Address = new Uri(proxy.proxyEntity.proxyAddess);              //网关服务器:端口
                    webProxy.Credentials = new NetworkCredential(proxy.proxyEntity.proxyUid, proxy.proxyEntity.proxyPwd);      //用戶名,密码
                    request.Proxy = webProxy;
                }
                responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();
                Image original = Image.FromStream(responseStream);
                map_bitMap = new Bitmap(original);
                request.Abort();
                responseStream.Close();
            }
            catch (Exception ex)
            {
                if (request != null) request.Abort();
                if (responseStream != null) responseStream.Close();
                throw ex;
            }
            return map_bitMap;
        }

        public List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();

            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, cc, new object[] { });
            StringBuilder sb = new StringBuilder();
            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies)
                    {
                        lstCookies.Add(c);
                    }
            }
            return lstCookies;
        }
    }
}
