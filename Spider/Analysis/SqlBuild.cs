using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spider.Analysis
{
    class SqlBuild
    {
      

        #region 系统配置，不需要修改
        #region Url记录表
        public string GetHalfBakeInsSql()
        {
            return "insert into DatUrl(ID,KeyWord,ProgramName,SpiderDate,PID,SType,SiteUrl,SourUrl,Url,UrlType,UrlPara,EnCode,Apara," +
                "CookieContent,AContent,PConent,TrySpiderTimes,Depth,SpiderTime,ErrorMsg) values (@ID,@KeyWord,@ProgramName,@SpiderDate," +
                "@PID,@SType,@SiteUrl,@SourUrl,@Url,@UrlType,@UrlPara,@EnCode,@Apara,@CookieContent,@AContent,@PConent," +
                "@TrySpiderTimes,@Depth,@SpiderTime,@ErrorMsg)";
        }
        #endregion
        #endregion
    }
}
