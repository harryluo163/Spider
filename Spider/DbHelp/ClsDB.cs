using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using DataSpider.Page;

namespace Spider.DbHelp
{
    class ClsDB
    {
        public void AddPageDB(PageContentEntity pageContentEntity, string SqlStr, SqlParameter[] paraArgs)
        {
            //分析数据 
            SqlCommand com = new SqlCommand(SqlStr);
            com.CommandType = CommandType.Text;
            if (paraArgs.Length > 0)
            {
                com.Parameters.AddRange(paraArgs);
            }
            DBEntity dbEntity = new DBEntity();
            dbEntity.pageContentEntity = pageContentEntity;
            dbEntity.myCom = com;


            Interlocked.Increment(ref Program.clsDBSignal);
            Program.dbList.Add(dbEntity);

        }
        public void ExecPageDBData()
        {
            DbHelp.Utilities util = new DbHelp.Utilities();

            Log.ClsLog clsLog = new Log.ClsLog();
            Common.UrlContorl urlContorl = new Common.UrlContorl();

            while (true)
            {

                Parallel.ForEach<DBEntity>(Program.dbList.GetConsumingEnumerable(), dbEntity =>
          //foreach (DBEntity dbEntity in Program.dbList.GetConsumingEnumerable())
          {
              try
              {
                  //插入SQL
                  util.ExecNonQuery(dbEntity.myCom, "");
              }
              catch (Exception ex)
              {
                  urlContorl.SaveUrl(dbEntity.pageContentEntity, ex.ToString());
                  clsLog.AddLog(DateTime.Now.ToString(), "执行数据失败" + ex.ToString());
                  clsLog.AddLog(DateTime.Now.ToString(), dbEntity.pageContentEntity.SType + ";" + dbEntity.pageContentEntity.PID + ";" + dbEntity.pageContentEntity.Url + "");
              }
              Interlocked.Decrement(ref Program.clsDBSignal);

          });



            }
        }
    }
}
