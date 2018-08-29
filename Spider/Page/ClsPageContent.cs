using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;
using Spider.Analysis;
using DataSpider.Page;
using static Spider.EventController;

namespace Spider.Page
{
    class ClsPageContent
    {
        public void AddPageContent(Spider.PageUrlEntity pageUrlEntity, string PContent)
        {
            //分析数据 
            PageContentEntity pageContentEntity = new PageContentEntity();
            pageContentEntity.ID = pageUrlEntity.ID;
            pageContentEntity.KeyWord = pageUrlEntity.KeyWord;
            pageContentEntity.ProgramName = pageUrlEntity.ProgramName;
            pageContentEntity.SpiderDate = pageUrlEntity.SpiderDate;
            pageContentEntity.PID = pageUrlEntity.PID;
            pageContentEntity.SType = pageUrlEntity.SType;
            pageContentEntity.SiteUrl = pageUrlEntity.SiteUrl;
            pageContentEntity.SourUrl = pageUrlEntity.SourUrl;
            pageContentEntity.Url = pageUrlEntity.Url;
            pageContentEntity.UrlType = pageUrlEntity.UrlType;
            pageContentEntity.UrlPara = pageUrlEntity.UrlPara;
            pageContentEntity.EnCode = pageUrlEntity.EnCode;
            pageContentEntity.APara = pageUrlEntity.APara;
            pageContentEntity.CookieContent = pageUrlEntity.CookieContent;
            pageContentEntity.AContent = pageUrlEntity.AContent;
            pageContentEntity.PContent = PContent;
            pageContentEntity.TrySpiderTimes = pageUrlEntity.TrySpiderTimes;
            pageContentEntity.Depth = pageUrlEntity.Depth;
            pageContentEntity.SpiderTime = DateTime.Now;

            Interlocked.Increment(ref Program.clsContentSignal);
            Program.pageContentList.Add(pageContentEntity);

        }

        public void AddPageContent(Spider.PageUrlEntity pageUrlEntity, Bitmap MContent)
        {
            //分析数据 
            PageContentEntity pageContentEntity = new PageContentEntity();
            pageContentEntity.ID = pageUrlEntity.ID;
            pageContentEntity.KeyWord = pageUrlEntity.KeyWord;
            pageContentEntity.ProgramName = pageUrlEntity.ProgramName;
            pageContentEntity.SpiderDate = pageUrlEntity.SpiderDate;
            pageContentEntity.PID = pageUrlEntity.PID;
            pageContentEntity.SType = pageUrlEntity.SType;
            pageContentEntity.SiteUrl = pageUrlEntity.SiteUrl;
            pageContentEntity.SourUrl = pageUrlEntity.SourUrl;
            pageContentEntity.Url = pageUrlEntity.Url;
            pageContentEntity.UrlType = pageUrlEntity.UrlType;
            pageContentEntity.UrlPara = pageUrlEntity.UrlPara;
            pageContentEntity.EnCode = pageUrlEntity.EnCode;
            pageContentEntity.APara = pageUrlEntity.APara;
            pageContentEntity.CookieContent = pageUrlEntity.CookieContent;
            pageContentEntity.AContent = pageUrlEntity.AContent;
            pageContentEntity.PContent = "";
            pageContentEntity.MContent = MContent;
            pageContentEntity.TrySpiderTimes = pageUrlEntity.TrySpiderTimes;
            pageContentEntity.Depth = pageUrlEntity.Depth;
            pageContentEntity.SpiderTime = DateTime.Now;
            Interlocked.Increment(ref Program.clsContentSignal);
            Program.pageContentList.Add(pageContentEntity);

        }

        public void AnalyseData()
        {
            string SDate = Program.SpiderDate;
            Log.ClsLog clsLog = new Log.ClsLog();
            Common.UrlContorl urlContorl = new Common.UrlContorl();

          MainContorl mainContorl = new MainContorl();



            Spider.ClsPageUrl clsPageUrl = new Spider.ClsPageUrl();
            //new ParallelOptions() { MaxDegreeOfParallelism = 5 } 设置最大并行数量
            //Parallel.ForEach<PageContentEntity>(Program.pageContentList.GetConsumingEnumerable(), pageContentEntity =>
            //找出要抓取的Url
            foreach (PageContentEntity pageContentEntity in Program.pageContentList.GetConsumingEnumerable())
            {
                //开始抓取数据
                try
                {
                    #region 分析数据
                    if (pageContentEntity.PContent.Trim() != "" || pageContentEntity.MContent != null)
                    {
                        //分析数据
                        switch (pageContentEntity.SType)
                        {
                            case "cyPortal":
                                mainContorl.cyPortalAnalysis(pageContentEntity);
                                break;
                            case "hyPortal":
                                mainContorl.hyPortalAnalysis(pageContentEntity);
                                break;
                            case "cydaPortal":
                                mainContorl.cydaPortalAnalysis(pageContentEntity);
                                break;
                            case "cyDetail":
                                mainContorl.cyDetailAnalysis(pageContentEntity);
                                break;
                            case "hyDetail":
                                mainContorl.hyDetailAnalysis(pageContentEntity);
                                break;
                            case "cydaDetail":
                                mainContorl.cydaDetailAnalysis(pageContentEntity);
                                break;

                            default: break;
                        }
                    }
                    else
                    {
                        //保存抓取失败数据
                        //urlContorl.SaveUrl(pageContentEntity, "页面数据为空");
                        clsLog.AddLog(DateTime.Now.ToString(), "抓取数据失败");
                        clsLog.AddLog(DateTime.Now.ToString(), pageContentEntity.SType + ";" + pageContentEntity.Url);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    clsLog.AddLog(DateTime.Now.ToString(), "分析数据失败" + ex.ToString());
                    clsLog.AddLog(DateTime.Now.ToString(), pageContentEntity.SType + ";" + pageContentEntity.PID + ";" + pageContentEntity.Url);
                    //urlContorl.SaveUrl(pageContentEntity, ex.ToString());
                }

                Interlocked.Decrement(ref Program.clsContentSignal);
                Program.helper.OnAllItemAnalyzeCompleted(this, new EventControllerArgs() { IsSuccess = true });
            }
        
            
        }
    }
}
