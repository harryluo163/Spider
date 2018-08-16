using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Drawing;
using GanZSpider.Spider;
using System.Threading.Tasks;
using Spider;
using Spider.Common;
using Spider.Configuration;

namespace Spider.Spider
{
    class ClsPageUrl
    {
        public void AddPageUrl(string ProgramName, string KeyWord, string PID, string SType, string SiteUrl, string SourUrl, string Url, string UrlType, string UrlPara,
            string EnCode, string APara, CookieContainer CookieContent, string AContent, int TrySpiderTimes, int Depth)
        {
            PageUrlEntity pageUrlEntity = new PageUrlEntity();
            pageUrlEntity.ID = Guid.NewGuid().ToString("D");
            pageUrlEntity.KeyWord = KeyWord;
            pageUrlEntity.ProgramName = ProgramName;
            pageUrlEntity.SpiderDate = Program.SpiderDate;
            pageUrlEntity.PID = PID;
            pageUrlEntity.SType = SType;
            pageUrlEntity.SiteUrl = SiteUrl;
            pageUrlEntity.SourUrl = SourUrl;
            pageUrlEntity.Url = Url;
            pageUrlEntity.UrlType = UrlType;
            pageUrlEntity.UrlPara = UrlPara;
            pageUrlEntity.EnCode = EnCode;
            pageUrlEntity.APara = APara;
            pageUrlEntity.CookieContent = CookieContent;
            pageUrlEntity.AContent = AContent;
            pageUrlEntity.TrySpiderTimes = TrySpiderTimes;
            pageUrlEntity.Depth = Depth;
            pageUrlEntity.SpiderTime = DateTime.Now;
            Interlocked.Increment(ref Program.clsUrlSignal);
            //Thread.Sleep(Program.sysPara.BegSpiderIntervalTime + Program.sysPara.IntervalSpiderIntervalTime * (Program.CurrSpiderTimes - 1));
            Program.pageUrlList.Add(pageUrlEntity);

        }
        public void AddPageUrl(PageUrlEntity pageUrlEntity)
        {

            Interlocked.Increment(ref Program.clsUrlSignal);
            Program.pageUrlList.Add(pageUrlEntity);

        }

        public async void SpiderData()
        {
            Log.ClsLog clsLog = new Log.ClsLog();
            Page.ClsPageContent clsPageContent = new Page.ClsPageContent();
            SnatchAt sa = new SnatchAt();
            string PContent = "";
            Bitmap MContent = null;

            UrlContorl urlContorl = new UrlContorl();
            CookieContainer cookies = new CookieContainer();
            ProxyEntity proxy = new ProxyEntity();
            Common.NetContorl netContorl = new Common.NetContorl();

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            HttpClient _client =  new HttpClient("", 0, false);
            //Links.ForEach(url =>//串行
            //Parallel.ForEach<PageUrlEntity>(Program.pageUrlList.GetConsumingEnumerable(), new ParallelOptions() { MaxDegreeOfParallelism = 5 }, pageUrlEntity =>
            //找出要抓取的Url
            foreach (PageUrlEntity pageUrlEntity in Program.pageUrlList.GetConsumingEnumerable())
            {

                //判断分析队列中的页面数是否大于最大分析队列页面数，如果大于则休眠系统设置时间
                if (Program.clsContentSignal >= Program.sysPara.MaxPage)
                {
                    Thread.Sleep(Program.sysPara.SpiderSleepTime);
                }

                if (Program.sysPara.IsProxy == "true")
                {
                    proxy = netContorl.GetProxyEntity_URL2();
                    while (proxy == null)
                    {
                        Thread.Sleep(Program.sysPara.NetSleepTime);
                        proxy = netContorl.GetProxyEntity_URL();
                    }
                    proxy.proxyAddess = proxy.proxyAddess.Replace("http://","");
                    _client = new HttpClient(proxy.proxyAddess.Split(':')[0].ToString(), Convert.ToInt32(proxy.proxyAddess.Split(':')[1].ToString()), true);
                }
             
                //开始抓取数据
                try
                {
                    //抓取数据
                    try
                    {
                        PContent = "";
                        MContent = null;

                        if (pageUrlEntity.UrlType == "MGET")
                        {
                            PContent =  _client.GetResponse(pageUrlEntity.SourUrl, pageUrlEntity.Url, pageUrlEntity.UrlType, pageUrlEntity.UrlPara, pageUrlEntity.EnCode);
                            pageUrlEntity.CookieContent = cookies;
                            pageUrlEntity.PContent = "";
                            if (MContent == null) throw new Exception("空图片");
                            clsPageContent.AddPageContent(pageUrlEntity, MContent);

                        }
                        else
                        {
                            PContent =  _client.GetResponse(pageUrlEntity.SourUrl, pageUrlEntity.Url, pageUrlEntity.UrlType, pageUrlEntity.UrlPara, pageUrlEntity.EnCode);
                            pageUrlEntity.CookieContent = cookies;
                            pageUrlEntity.PContent = PContent;
                            if (string.IsNullOrEmpty(PContent)) throw new Exception("空页面");
                            if (PContent.Contains("超时")) throw new Exception("操作超时");
                            clsPageContent.AddPageContent(pageUrlEntity, PContent);
                        }


                    }
                    catch (Exception ex)
                    {
                        clsLog.AddLog(DateTime.Now.ToString(), "抓取数据失败" + ex.ToString());
                        clsLog.AddLog(DateTime.Now.ToString(), pageUrlEntity.SType + ";" + pageUrlEntity.Url + ";");
                        urlContorl.SaveUrl(pageUrlEntity, PContent, ex.ToString());
                    }
                }
                catch (Exception ex)
                {
                    clsLog.AddLog(DateTime.Now.ToString(), "抓取失败" + ex.ToString());
                    clsLog.AddLog(DateTime.Now.ToString(), pageUrlEntity.SType + ";" + pageUrlEntity.Url + ";");
                    urlContorl.SaveUrl(pageUrlEntity, PContent, ex.ToString());
                }
                Interlocked.Decrement(ref Program.clsUrlSignal);

                Thread.Sleep(Program.sysPara.BegSpiderIntervalTime + Program.sysPara.IntervalSpiderIntervalTime * (Program.CurrSpiderTimes - 1));

            }




        }
    }
}
