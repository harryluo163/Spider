using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Spider.BizEntity;

namespace Spider.Analysis
{
    class SqlPara
    {
   
        #region URL记录表
        public SqlParameter[] GetHalfBakeInsPara(DatUrlEntity model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,36),
                    new SqlParameter("@KeyWord", SqlDbType.VarChar,500),
					new SqlParameter("@ProgramName", SqlDbType.VarChar,100),
					new SqlParameter("@SpiderDate", SqlDbType.VarChar,10),
					new SqlParameter("@PID", SqlDbType.VarChar,36),
					new SqlParameter("@SType", SqlDbType.VarChar,50),
					new SqlParameter("@SiteUrl", SqlDbType.VarChar,2000),
					new SqlParameter("@SourUrl", SqlDbType.VarChar,2000),
					new SqlParameter("@Url", SqlDbType.VarChar,2000),
					new SqlParameter("@UrlType", SqlDbType.VarChar,50),
					new SqlParameter("@UrlPara", SqlDbType.Text),
					new SqlParameter("@EnCode", SqlDbType.VarChar,50),
                    new SqlParameter("@Apara", SqlDbType.VarChar,4000),
					new SqlParameter("@CookieContent", SqlDbType.Text),
					new SqlParameter("@AContent", SqlDbType.Text),
					new SqlParameter("@PConent", SqlDbType.Text),
					new SqlParameter("@TrySpiderTimes", SqlDbType.Int,4),
                    new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@SpiderTime", SqlDbType.DateTime),
					new SqlParameter("@ErrorMsg", SqlDbType.Text)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.KeyWord;
            parameters[2].Value = model.ProgramName;
            parameters[3].Value = model.SpiderDate;
            parameters[4].Value = model.PID;
            parameters[5].Value = model.SType;
            parameters[6].Value = model.SiteUrl;
            parameters[7].Value = model.SourUrl;
            parameters[8].Value = model.Url;
            parameters[9].Value = model.UrlType;
            parameters[10].Value = model.UrlPara;
            parameters[11].Value = model.EnCode;
            parameters[12].Value = model.APara;
            parameters[13].Value = model.CookieContent;
            parameters[14].Value = model.AContent;
            parameters[15].Value = model.PConent;
            parameters[16].Value = model.TrySpiderTimes;
            parameters[17].Value = model.Depth;
            parameters[18].Value = model.SpiderTime;
            parameters[19].Value = model.ErrorMsg;
            return parameters;
        }
        #endregion

    }
}
