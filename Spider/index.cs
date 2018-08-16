using Spider.Log;
using Spider.Page;
using Spider.Spider;
using SpiderApp.entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Spider.EventController;

namespace Spider
{
    public partial class index : Form
    {
 
        string cookie = "";
        private int spiderNum = 0;
        private int spidercyNum = 0;
        private int spiderhyNum = 0;
        int xmlnamenum = 0;
        public index()
        {
            InitializeComponent();
            Common.CommonFunc cf = new Common.CommonFunc();
            cf.InitialFunc();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Program.userList.Count <= 0)
            {
                MessageBox.Show("请导入用户账号");
                return;
            }

            btnStart.Enabled = false;

            int spiderNum = 0;
            int xmlnamenum = 0;

   

            if (useproxy.Checked)
            {
                if (Program.IPList.Count < 0)
                {
                    MessageBox.Show("ip列表为空，请到ip.xml编辑");
                    return;
                }
               
            }
          


            btnStart.Enabled = false;
            #region 日志文件记录
            ClsLog clsLog = new ClsLog();
            Thread LogThread = new Thread(new ThreadStart(clsLog.WriteLog));
            LogThread.Start();
            #endregion

            #region 抓取线程
            clsLog.AddLog(DateTime.Now.ToString(), "抓取开始");
            ClsPageUrl clsPageUrl = new ClsPageUrl();
            Thread SpiderThread = new Thread(new ThreadStart(clsPageUrl.SpiderData));
            SpiderThread.Start();
            #endregion

            #region 分析线程
            ClsPageContent clsPageContent = new ClsPageContent();
            Thread AnalyseThread = new Thread(new ThreadStart(clsPageContent.AnalyseData));
            AnalyseThread.Start();
            #endregion

            #region 数据库插入操作线程
            //ClsDB clsDB = new ClsDB();
            //Thread dbThread = new Thread(new ThreadStart(clsDB.ExecPageDBData));
            //dbThread.Start();
            #endregion

            #region 事件注册

            /// 所有需要分析的，都完成事件
            Program.helper.OnAllItemAnalyzeCompleted += (senders, es) =>
            {
                if (Program.clsUrlSignal == 0 && Program.clsContentSignal == 0 && Program.clsDBSignal == 0)
                {
                    SpiderThread.Abort();
                    AnalyseThread.Abort();
                    //dbThread.Abort();
                    Thread.Sleep(20000);
                    LogThread.Abort();
                    clsLog.AddLog(DateTime.Now.ToString(), "抓取结束");
                    txtview.AppendText("抓取船源结束" + Environment.NewLine);
                }
                Application.DoEvents();
            };


            Program.helper.OntxtviewCompleted += (senders, es) =>
            {
                if (Program.clsUrlSignal == 0 && Program.clsContentSignal == 0 && Program.clsDBSignal == 0)
                {
                    EventControllerArgs _tem = es as EventControllerArgs;
                    txtview.AppendText(_tem.Msg + Environment.NewLine);
                }
                Application.DoEvents();
            };

            #endregion

            //入口方法
            spiderMain();




        }

        public void spiderMain()
        {
            ClsLog clsLog = new ClsLog();
            clsLog.AddLog(DateTime.Now.ToString(), "入口抓取开始");
            bool flag = false;
            int CurrSpiderTimes = 1;
            ClsPageUrl clsPageUrl = new ClsPageUrl();

            Control.CheckForIllegalCrossThreadCalls = false;

            //船源
            clsPageUrl.AddPageUrl("ProgramName", "", "", "cyPortal", "", "", "http://cht.cjsyw.com:8080/ShipSource/listSS.aspx?pageno=1",
            "GET", "", "utf-8","", null, "", 1, 1);
            //货源
            clsPageUrl.AddPageUrl("ProgramName", "", "", "hyPortal", "", "", "http://cht.cjsyw.com:8080/Goods/listGoods.aspx?pageno=1",
 "GET", "", "utf-8", "", null, "", 1, 1);
            //船舶档案
            clsPageUrl.AddPageUrl("ProgramName", "", "", "cydaPortal", "", "", "http://cht.cjsyw.com:8080/Boat/BoatList.aspx?pageno=1",
 "GET", "", "utf-8", "", null, "", 1, 1);


        }

        private void index_Load(object sender, EventArgs e)
        {
            using (FileStream fs = File.Open("entity\\user.xml", FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                string text = sr.ReadToEnd();
                var list = XmlSerializeHelper.DeSerialize<userList>(text);
                list.DataSource.ForEach((user) =>
                {
                    Program.userList.Add(user);
                });
                comboBox1.DataSource = list.DataSource;
                comboBox1.ValueMember = "token";
                comboBox1.DisplayMember = "token";


            }

            using (FileStream fs = File.Open("entity\\ip.xml", FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                string text = sr.ReadToEnd();
                var list = XmlSerializeHelper.DeSerialize<IPList>(text);
                list.DataSource.ForEach((user) =>
                {
                    Program.IPList.Add(user);
                });
                cbiplist.DataSource = list.DataSource;
                cbiplist.ValueMember = "ip";
                cbiplist.DisplayMember = "ip";


            }
        }
    }
}
