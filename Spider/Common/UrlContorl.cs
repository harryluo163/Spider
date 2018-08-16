using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Spider.BizEntity;
using DataSpider.Page;

namespace Spider.Common
{
    class UrlContorl
    {
  
        //保存数据
        public void SaveUrl(PageContentEntity entity, string ErrorMsg)
        {
            CookieFunc cookieFunc = new CookieFunc();
            DatUrlEntity urlEntity = new DatUrlEntity();
            urlEntity.ID = entity.ID;
            urlEntity.KeyWord = entity.KeyWord;
            urlEntity.ProgramName = entity.ProgramName;
            urlEntity.SpiderDate = entity.SpiderDate;
            urlEntity.PID = entity.PID;
            urlEntity.SiteUrl = entity.SiteUrl;
            urlEntity.SType = entity.SType;
            urlEntity.SourUrl = entity.SourUrl;
            urlEntity.Url = entity.Url;
            urlEntity.UrlType = entity.UrlType;
            urlEntity.UrlPara = entity.UrlPara;
            urlEntity.EnCode = entity.EnCode;
            urlEntity.APara = entity.APara;
            urlEntity.CookieContent = cookieFunc.GetCookiesStr(entity.CookieContent);
            urlEntity.AContent = entity.AContent;
            urlEntity.PConent = entity.PContent;
            urlEntity.ErrorMsg = ErrorMsg;
            urlEntity.TrySpiderTimes = entity.TrySpiderTimes + 1;
            urlEntity.Depth = entity.Depth;
            urlEntity.SpiderTime = entity.SpiderTime;
            DbHelp.ClsDB clsdb = new DbHelp.ClsDB();
            Analysis.SqlBuild sqlBuild = new Analysis.SqlBuild();
            Analysis.SqlPara sqlPara = new Analysis.SqlPara();     
            clsdb.AddPageDB(entity, sqlBuild.GetHalfBakeInsSql(), sqlPara.GetHalfBakeInsPara(urlEntity));
            DbHelp.Utilities util = new DbHelp.Utilities();
        }

        public void SaveUrl(Spider.PageUrlEntity entity, string pContent, string ErrorMsg)
        {
            Common.CookieFunc cookieFunc = new Common.CookieFunc();
            DatUrlEntity urlEntity = new DatUrlEntity();
            urlEntity.ID = entity.ID;
            urlEntity.KeyWord = entity.KeyWord;
            urlEntity.ProgramName = entity.ProgramName;
            urlEntity.SpiderDate = entity.SpiderDate;
            urlEntity.PID = entity.PID;
            urlEntity.SiteUrl = entity.SiteUrl;
            urlEntity.SType = entity.SType;
            urlEntity.SourUrl = entity.SourUrl;
            urlEntity.Url = entity.Url;
            urlEntity.UrlType = entity.UrlType;
            urlEntity.UrlPara = entity.UrlPara;
            urlEntity.EnCode = entity.EnCode;
            urlEntity.APara = entity.APara;
            urlEntity.CookieContent = cookieFunc.GetCookiesStr(entity.CookieContent);
            urlEntity.AContent = entity.AContent;
            urlEntity.PConent = pContent;
            urlEntity.TrySpiderTimes = entity.TrySpiderTimes + 1;
            urlEntity.Depth = entity.Depth;
            urlEntity.SpiderTime = entity.SpiderTime;
            urlEntity.ErrorMsg = ErrorMsg;

            #region 合成页面
            PageContentEntity pageContentEntity = new PageContentEntity();
            pageContentEntity.ID = entity.ID;
            pageContentEntity.KeyWord = entity.KeyWord;
            pageContentEntity.ProgramName = entity.ProgramName;
            pageContentEntity.SpiderDate = entity.SpiderDate;
            pageContentEntity.PID = entity.PID;
            pageContentEntity.SType = entity.SType;
            pageContentEntity.SiteUrl = entity.SiteUrl;
            pageContentEntity.SourUrl = entity.SourUrl;
            pageContentEntity.Url = entity.Url;
            pageContentEntity.UrlType = entity.UrlType;
            pageContentEntity.UrlPara = entity.UrlPara;
            pageContentEntity.EnCode = entity.EnCode;
            pageContentEntity.APara = entity.APara;
            pageContentEntity.CookieContent = entity.CookieContent;
            pageContentEntity.AContent = entity.AContent;
            pageContentEntity.PContent = pContent;
            pageContentEntity.TrySpiderTimes = entity.TrySpiderTimes;
            pageContentEntity.SpiderTime = DateTime.Now;     
            #endregion

            DbHelp.ClsDB clsdb = new DbHelp.ClsDB();
            Analysis.SqlBuild sqlBuild = new Analysis.SqlBuild();
            Analysis.SqlPara sqlPara = new Analysis.SqlPara();
            clsdb.AddPageDB(pageContentEntity, sqlBuild.GetHalfBakeInsSql(), sqlPara.GetHalfBakeInsPara(urlEntity));
            DbHelp.Utilities util = new DbHelp.Utilities();
        }
    }
}
