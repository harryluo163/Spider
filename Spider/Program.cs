using DataSpider.Page;
using Spider.DbHelp;
using Spider.Log;
using Spider.Page;
using Spider.Spider;
using SpiderApp.entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spider
{
    static class Program
    {
        public static BlockingCollection<PageUrlEntity> pageUrlList = new BlockingCollection<PageUrlEntity>();
        public static BlockingCollection<PageContentEntity> pageContentList = new BlockingCollection<PageContentEntity>();
        public static BlockingCollection<LogEntity> LogList = new BlockingCollection<LogEntity>();
        public static BlockingCollection<DBEntity> dbList = new BlockingCollection<DBEntity>();
        public static string SpiderDate;
        public static int MaxTrySpidertimes = 3;//最大失败次数
        public static int clsUrlSignal;
        public static int clsContentSignal;
        public static int clsDBSignal;
        public static int CurrSpiderTimes = 1;
        public static List<string> proxyList_URL = new List<string>(); //代理接口IP
        public static Configuration.SysPara sysPara = new Configuration.SysPara();



        public static BlockingCollection<user> userList = new BlockingCollection<user>();
        public static BlockingCollection<_IP> IPList = new BlockingCollection<_IP>();

        public static  EventController helper = new EventController();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
     
            Application.Run(new index());
 
        }
    }
}
