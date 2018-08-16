using DataSpider.Page;
using Spider.Common;
using Spider.DbHelp;
using Spider.Log;
using Spider.Page;
using Spider.Reg;
using Spider.Spider;
using SpiderApp.entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Spider.EventController;

namespace Spider.Analysis
{
    public class MainContorl
    {
        ClsPageUrl clsPageUrl = new ClsPageUrl();
        public void cyPortalAnalysis(PageContentEntity entity)
        {
            try
            {
                string pContent = entity.PContent;
                Utilities util = new Utilities();
                SqlBuild sqlBuild = new SqlBuild();
                SqlPara sqlPara = new SqlPara();
                ClsDB clsDB = new ClsDB();
                RegFunc rf = new RegFunc();

                ArrayList arrayList = rf.GetStrArr(pContent, "\"id\":", ",");
                for (int i = 0; i < arrayList.Count; i++)
                {
                    string nexurl = "http://cht.cjsyw.com:8080/ShipSource/getSSDetail.aspx?userid=" + getuser().token + "&kcid=" + arrayList[i].ToString() + "";
                    clsPageUrl.AddPageUrl(entity.ProgramName, entity.KeyWord, entity.PID, "cyDetail", entity.SiteUrl, entity.Url, nexurl,
                    "GET", "", entity.EnCode, arrayList[i].ToString(), entity.CookieContent, entity.AContent, entity.TrySpiderTimes, entity.Depth + 1);

                }
            }
            catch (Exception ex)
            {
                ClsLog clsLog = new ClsLog();
                clsLog.AddLog(DateTime.Now.ToString(), "分析数据失败" + ex.ToString());
                clsLog.AddLog(DateTime.Now.ToString(), entity.SType + ";" + entity.Url + ";");
            
               
            }
        }
        public void hyPortalAnalysis(PageContentEntity entity)
        {
            try
            {
                string pContent = entity.PContent;
                Utilities util = new Utilities();
                SqlBuild sqlBuild = new SqlBuild();
                SqlPara sqlPara = new SqlPara();
                ClsDB clsDB = new ClsDB();
                RegFunc rf = new RegFunc();

                ArrayList arrayList = rf.GetStrArr(pContent, "\"id\":", ",");
                for (int i = 0; i < arrayList.Count; i++)
                {

                    string nexurl = "http://cht.cjsyw.com:8080//Goods/FindGoodsDetails.aspx?userid=" + getuser().token + "&hwid=" + arrayList[i].ToString() + "";
                    clsPageUrl.AddPageUrl(entity.ProgramName, entity.KeyWord, entity.PID, "hyDetail", entity.SiteUrl, entity.Url, nexurl,
                    "GET", "", entity.EnCode, arrayList[i].ToString(), entity.CookieContent, entity.AContent, entity.TrySpiderTimes, entity.Depth + 1);

                }





            }
            catch (Exception ex)
            {
                ClsLog clsLog = new ClsLog();
                clsLog.AddLog(DateTime.Now.ToString(), "分析数据失败" + ex.ToString());
                clsLog.AddLog(DateTime.Now.ToString(), entity.SType + ";" + entity.Url + ";");
                UrlContorl urlContorl = new UrlContorl();
            }
        }
        public void cydaPortalAnalysis(PageContentEntity entity)
        {
            try
            {
                string pContent = entity.PContent;
                Utilities util = new Utilities();
                SqlBuild sqlBuild = new SqlBuild();
                SqlPara sqlPara = new SqlPara();
                ClsDB clsDB = new ClsDB();
                RegFunc rf = new RegFunc();

                ArrayList arrayList = rf.GetStrArr(pContent, "\"id\":", ",");
                for (int i = 0; i < arrayList.Count; i++)
                {
                 
                    string nexurl = "http://cht.cjsyw.com:8080/Boat/getBoatById.aspx?userid=" + getuser().token + "&id=" + arrayList[i].ToString() + "";
                    clsPageUrl.AddPageUrl(entity.ProgramName, entity.KeyWord, entity.PID, "cydaDetail", entity.SiteUrl, entity.Url, nexurl,
                    "GET", "", entity.EnCode, arrayList[i].ToString(), entity.CookieContent, entity.AContent, entity.TrySpiderTimes, entity.Depth + 1);

                }





            }
            catch (Exception ex)
            {
                ClsLog clsLog = new ClsLog();
                clsLog.AddLog(DateTime.Now.ToString(), "分析数据失败" + ex.ToString());
                clsLog.AddLog(DateTime.Now.ToString(), entity.SType + ";" + entity.Url + ";");
                UrlContorl urlContorl = new UrlContorl();
            }
        }
        public void cyDetailAnalysis(PageContentEntity entity)
        {
            try
            {
                string content2 = entity.PContent;
                Utilities util = new Utilities();
                SqlBuild sqlBuild = new SqlBuild();
                SqlPara sqlPara = new SqlPara();
                ClsDB clsDB = new ClsDB();
                RegFunc rf = new RegFunc();
                var controllerArgs = new EventControllerArgs() { IsSuccess = false };
                user user = getuser();
                if (rf.GetStr(content2, "\"mobile\":\"", "\",") == "操作频繁稍后再试！")
                {
                    controllerArgs.Msg = "操作频繁切换用户补抓" + user.token;
               
                    string nexurl = "http://cht.cjsyw.com:8080/ShipSource/getSSDetail.aspx?userid=" + user.token + "&kcid=" + entity.APara + "";
                    clsPageUrl.AddPageUrl(entity.ProgramName, entity.KeyWord, entity.PID, "cyDetail", entity.SiteUrl, entity.Url, nexurl,
                    "GET", "", entity.EnCode, entity.APara, entity.CookieContent, entity.AContent, entity.TrySpiderTimes, entity.Depth + 1);


                }
                else if (!string.IsNullOrEmpty(content2))
                {
                    string _datastr = "";
                    //创建文件夹

                    string Path = "down\\船源数据.txt";
                    if (!File.Exists(Path))
                    {
                        using (new FileStream(Path, FileMode.Create, FileAccess.Write)) { };
                    }
                    using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
                    {

                        _datastr += "<id>" + rf.GetStr(content2, "\"id\":", ",") + "</id>";
                        _datastr += "<boatid>" + rf.GetStr(content2, "\"boatid\":", ",") + "</boatid>";
                        _datastr += "<Privince>" + rf.GetStr(content2, "\"Privince\":\"", "\",") + "</Privince>";
                        _datastr += "<city>" + rf.GetStr(content2, "\"city\":\"", "\",") + "</city>";
                        _datastr += "<bz>" + rf.GetStr(content2, "\"bz\":\"", "\"") + "/bz>";

                        _datastr += "<userid>" + rf.GetStr(content2, "\"userid\":", ",") + "/userid>";
                        _datastr += "<gsmc>" + rf.GetStr(content2, "\"gsmc\":\"", "\",") + "</gsmc>";

                        _datastr += "<szg>" + rf.GetStr(content2, "\"szg\":\"", "\",") + "</szg>";
                        _datastr += "<mdg>" + rf.GetStr(content2, "\"mdg\":\"", "\",") + "</mdg>";
                        _datastr += "<cpdw>" + rf.GetStr(content2, "\"cpdw\":\"", "\",") + "</cpdw>";
                        _datastr += "<cplx>" + rf.GetStr(content2, "\"cplx\":\"", "\",") + "</cplx>";
                        _datastr += "<kclb>" + rf.GetStr(content2, "\"kclb\":\"", "\",") + "</kclb>";
                        _datastr += "<zhrq1>" + rf.GetStr(content2, "\"zhrq1\":\"", "\",") + "</zhrq1>";
                        _datastr += "<zhrq2>" + rf.GetStr(content2, "\"zhrq2\":\"", "\",") + "</zhrq2>";
                        _datastr += "<bzlb>" + rf.GetStr(content2, "\"bzlb\":\"", "\",") + "</bzlb>";
                        _datastr += "<name>" + rf.GetStr(content2, "\"name\":\"", "\"") + "</name>";
                        _datastr += "<mobile>" + rf.GetStr(content2, "\"mobile\":\"", "\",") + "</mobile>";

                        string content3 = rf.GetStr(content2, "\"czxx\":", "}]");
                        _datastr += "<czxxid>" + rf.GetStr(content3, "\"id\":", ",") + "</czxxid>";
                        _datastr += "<lx>" + rf.GetStr(content3, "\"lx\":\"", "\",") + "</lx>";
                        _datastr += "<Qymc>" + rf.GetStr(content3, "\"Qymc\":\"", "\",") + "</Qymc>";
                        _datastr += "<Uname>" + rf.GetStr(content3, "\"Uname\":\"", "\",") + "</Uname>";
                        _datastr += "<name>" + rf.GetStr(content3, "\"name\":\"", "\",") + "</name>";
                        _datastr += "<mobile>" + rf.GetStr(content3, "\"mobile\":\"", "\",") + "</mobile>";
                        _datastr += "<flag>" + rf.GetStr(content3, "\"flag\":", ",") + "</flag>";
                        _datastr += "<hppj>" + rf.GetStr(content3, "\"hppj\":", ",") + "</hppj>";
                        _datastr += "<ybpj>" + rf.GetStr(content3, "\"ybpj\":", ",") + "</ybpj>";
                        _datastr += "<cppj>" + rf.GetStr(content3, "\"cppj\":", ",") + "</cppj>";
                        _datastr += "<userimg>" + rf.GetStr(content3, "\"userimg\":\"", "\"") + "</userimg>";

                        string content4 = rf.GetStr(content2, "\"ds\":", "}");
                        if (!string.IsNullOrEmpty(rf.GetStr(content4, "\"ch\":\"", "\",")))
                        {
                            _datastr += "<ch>" + rf.GetStr(content4, "\"ch\":\"", "\",") + "</ch>";
                            _datastr += "<sf>" + rf.GetStr(content4, "\"sf\":\"", "\",") + "</sf>";
                            _datastr += "<city>" + rf.GetStr(content4, "\"city\":\"", "\",") + "</city>";
                            _datastr += "<sc>" + rf.GetStr(content4, "\"sc\":\"", "\",") + "</sc>";
                            _datastr += "<cc>" + rf.GetStr(content4, "\"cc\":\"", "\",") + "</cc>";
                            _datastr += "<ck>" + rf.GetStr(content4, "\"ck\":\"", "\",") + "</ck>";
                            _datastr += "<cs>" + rf.GetStr(content4, "\"cs\":\"", "\"") + "</cs>";
                        }
                        else
                        {


                            _datastr += "<ch></ch>";
                            _datastr += "<sf></sf>";
                            _datastr += "<city></city>";
                            _datastr += "<sc></sc>";
                            _datastr += "<cc></cc>";
                            _datastr += "<ck></ck>";
                            _datastr += "<cs></cs>";

                        }
                        //开始写入
                        sw.Write(_datastr + "\r\n");
                        controllerArgs.Msg = "已抓到吨位" + rf.GetStr(content2, "\"cpdw\":\"", "\",") + "所在地" + rf.GetStr(content2, "\"szg\":\"", "\",") + rf.GetStr(content2, "\"cplx\":\"", "\",");
                    }
                }

                Program.helper.OntxtviewCompleted(this, controllerArgs);

            }
            catch (Exception ex)
            {
                ClsLog clsLog = new ClsLog();
                clsLog.AddLog(DateTime.Now.ToString(), "分析数据失败" + ex.ToString());
                clsLog.AddLog(DateTime.Now.ToString(), entity.SType + ";" + entity.Url + ";");
                UrlContorl urlContorl = new UrlContorl();
               
            }
        }
        public void hyDetailAnalysis(PageContentEntity entity)
        {
            try
            {
                string content2 = entity.PContent;
                Utilities util = new Utilities();
                SqlBuild sqlBuild = new SqlBuild();
                SqlPara sqlPara = new SqlPara();
                ClsDB clsDB = new ClsDB();
                RegFunc rf = new RegFunc();
                var controllerArgs = new EventControllerArgs() { IsSuccess = false };
                user user = getuser();
                if (rf.GetStr(content2, "\"mobile\":\"", "\",") == "操作频繁稍后再试！")
                {
                    controllerArgs.Msg = "操作频繁切换用户补抓" + user.token;

                    string nexurl = "http://cht.cjsyw.com:8080//Goods/FindGoodsDetails.aspx?userid=" + user.token + "&hwid=" + entity.APara + "";
                    clsPageUrl.AddPageUrl(entity.ProgramName, entity.KeyWord, entity.PID, "cyDetail", entity.SiteUrl, entity.Url, nexurl,
                    "GET", "", entity.EnCode, entity.APara, entity.CookieContent, entity.AContent, entity.TrySpiderTimes, entity.Depth + 1);


                }
                else if (!string.IsNullOrEmpty(content2))
                {

                    string _datastr = "";
                    //创建文件夹
                    FileStream fs;
                    string Path = "down\\货源数据.txt";
                    if (!File.Exists(Path))
                    {
                        using (new FileStream(Path, FileMode.Create, FileAccess.Write)) { };
                    }

                    using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
                    {

                        _datastr += "<hzimg>" + rf.GetStr(content2, "\"hzimg\":\"", "\",") + "</hzimg>";
                        _datastr += "<name>" + rf.GetStr(content2, "\"name\":\"", "\",") + "</name>";
                        _datastr += "<mobile>" + rf.GetStr(content2, "\"mobile\":\"", "\",") + "</mobile>";
                        _datastr += "<title>" + rf.GetStr(content2, "\"title\":\"", "\",") + "</title>";
                        _datastr += "<hwUserid>" + rf.GetStr(content2, "\"hwUserid\":", ",") + "/hwUserid>";

                        _datastr += "<cppj>" + rf.GetStr(content2, "\"cppj\":\"", "\",") + "</cppj>";
                        _datastr += "<ybpj>" + rf.GetStr(content2, "\"ybpj\":\"", "\",") + "</ybpj>";
                        _datastr += "<cppj>" + rf.GetStr(content2, "\"cppj\":\"", "\",") + "</cppj>";
                        _datastr += "<hits>" + rf.GetStr(content2, "\"hits\":\"", "\",") + "</hits>";

                        _datastr += "<hymc>" + rf.GetStr(content2, "\"hymc\":\"", "\",") + "</hymc>";

                        _datastr += "<ckyj>" + rf.GetStr(content2, "\"ckyj\":\"", "\",") + "</ckyj>";
                        _datastr += "<hwds>" + rf.GetStr(content2, "\"hwds\":\"", "\",") + "</hwds>";
                        _datastr += "<fhg>" + rf.GetStr(content2, "\"fhg\":\"", "\",") + "</fhg>";
                        _datastr += "<ddg>" + rf.GetStr(content2, "\"ddg\":\"", "\",") + "</ddg>";
                        _datastr += "<ssss>" + rf.GetStr(content2, "\"ssss\":\"", "\"") + "</ssss>";
                        _datastr += "<CFPrivince>" + rf.GetStr(content2, "\"CFPrivince\":\"", "\",") + "</CFPrivince>";
                        _datastr += "<CFCity>" + rf.GetStr(content2, "\"CFCity\":\"", "\",") + "</CFCity>";
                        _datastr += "<bzxs>" + rf.GetStr(content2, "\"bzxs\":\"", "\",") + "</bzxs>";
                        _datastr += "<fhrq>" + rf.GetStr(content2, "\"fhrq\":\"", "\",") + "</fhrq>";
                        _datastr += "<jzrq>" + rf.GetStr(content2, "\"jzrq\":\"", "\",") + "</jzrq>";
                        _datastr += "<lb>" + rf.GetStr(content2, "\"lb\":\"", "\",") + "</lb>";
                        _datastr += "<hwid>" + rf.GetStr(content2, "\"hwid\":", ",") + "</hwid>";
                        _datastr += "<bz>" + rf.GetStr(content2, "\"bz\":\"", "\"") + "</bz>";
                        //开始写入
                        sw.Write(_datastr + "\r\n");
                        controllerArgs.Msg = "已抓到" + rf.GetStr(content2, "\"name\":\"", "\",") + "的货源" + rf.GetStr(content2, "\"title\":\"", "\",");

                    }
                    //抓起间隔

                }
                Program.helper.OntxtviewCompleted(this, controllerArgs);




            }
            catch (Exception ex)
            {
                ClsLog clsLog = new ClsLog();
                clsLog.AddLog(DateTime.Now.ToString(), "分析数据失败" + ex.ToString());
                clsLog.AddLog(DateTime.Now.ToString(), entity.SType + ";" + entity.Url + ";");
                UrlContorl urlContorl = new UrlContorl();
            }
        }
        public void cydaDetailAnalysis(PageContentEntity entity)
        {
            try
            {
                string content2 = entity.PContent;
              
                Utilities util = new Utilities();
                SqlBuild sqlBuild = new SqlBuild();
                SqlPara sqlPara = new SqlPara();
                ClsDB clsDB = new ClsDB();
                RegFunc rf = new RegFunc();
                var controllerArgs = new EventControllerArgs() { IsSuccess = false };
                user user = getuser();
                if (rf.GetStr(content2, "\"mobile\":\"", "\",") == "操作频繁稍后再试！")
                {
                    controllerArgs.Msg = "操作频繁切换用户补抓" + user.token;
                    string nexurl = "http://cht.cjsyw.com:8080/Boat/getBoatById.aspx?userid=" + user.token + "&id=" + entity.APara + "";
                    clsPageUrl.AddPageUrl(entity.ProgramName, entity.KeyWord, entity.PID, "cyDetail", entity.SiteUrl, entity.Url, nexurl,
                    "GET", "", entity.EnCode, entity.APara, entity.CookieContent, entity.AContent, entity.TrySpiderTimes, entity.Depth + 1);


                }
                else if (!string.IsNullOrEmpty(content2))
                {

                    string _datastr = "";
                    //创建文件夹
                    FileStream fs;
                    string Path = "down\\船舶档案数据.txt";
                    if (!File.Exists(Path))
                    {
                        using (new FileStream(Path, FileMode.Create, FileAccess.Write)) { };
                    }

                    using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
                    {

                        _datastr += "<id>" + rf.GetStr(content2, "\"id\":", ",") + "</id>";
                        _datastr += "<dw>" + rf.GetStr(content2, "\"hzimg\":", ",") + "</hzimg>";
                        _datastr += "<cx>" + rf.GetStr(content2, "\"cx\":\"", "\",") + "</cx>";
                        _datastr += "<sf>" + rf.GetStr(content2, "\"sf\":\"", "\",") + "</sf>";
                        _datastr += "<cx>" + rf.GetStr(content2, "\"cx\":\"", "\",") + "</cx>";
                        _datastr += "<city>" + rf.GetStr(content2, "\"city\":\"", "\",") + "</city>";
                        _datastr += "<czxm>" + rf.GetStr(content2, "\"czxm\":\"", "\",") + "</czxm>";
                        _datastr += "<sjhm>" + rf.GetStr(content2, "\"sjhm\":\"", "\",") + "</sjhm>";
                        _datastr += "<date>" + rf.GetStr(content2, "\"date\":\"", "\",") + "</date>";
                        _datastr += "<gkgs>" + rf.GetStr(content2, "\"gkgs\":\"", "\",") + "</gkgs>";
                        _datastr += "<sfzh>" + rf.GetStr(content2, "\"sfzh\":\"", "\",") + "</sfzh>";
                        _datastr += "<ch>" + rf.GetStr(content2, "\"ch\":\"", "\",") + "</ch>";
                        _datastr += "<hc>" + rf.GetStr(content2, "\"hc\":\"", "\",") + "</hc>";
                        _datastr += "<bz>" + rf.GetStr(content2, "\"bz\":\"", "\",") + "</bz>";

                        _datastr += "<cc>" + rf.GetStr(content2, "\"cc\":\"", "\",") + "</cc>";
                        _datastr += "<cg>" + rf.GetStr(content2, "\"cg\":\"", "\",") + "</cg>";
                        _datastr += "<ck>" + rf.GetStr(content2, "\"ck\":\"", "\",") + "</ck>";
                        _datastr += "<cs>" + rf.GetStr(content2, "\"cs\":\"", "\",") + "</cs>";
                        _datastr += "<sfdb>" + rf.GetStr(content2, "\"sfdb\":\"", "\",") + "</sfdb>";
                        _datastr += "<adress>" + rf.GetStr(content2, "\"adress\":\"", "\",") + "</adress>";
                        _datastr += "<lxdh>" + rf.GetStr(content2, "\"lxdh\":\"", "\",") + "</lxdh>";
                        _datastr += "<qq>" + rf.GetStr(content2, "\"qq\":\"", "\",") + "</qq>";
                        _datastr += "<gmsj>" + rf.GetStr(content2, "\"gmsj\":\"", "\",") + "</gmsj>";
                        _datastr += "<email>" + rf.GetStr(content2, "\"email\":\"", "\",") + "</email>";

                        _datastr += "<frdb>" + rf.GetStr(content2, "\"frdb\":\"", "\",") + "</frdb>";
                        _datastr += "<gsdh>" + rf.GetStr(content2, "\"gsdh\":\"", "\",") + "</gsdh>";
                        _datastr += "<gsweb>" + rf.GetStr(content2, "\"gsweb\":\"", "\",") + "</gsweb>";
                        _datastr += "<gsemail>" + rf.GetStr(content2, "\"gsemail\":\"", "\",") + "</gsemail>";
                        _datastr += "<gsfax>" + rf.GetStr(content2, "\"gsfax\":\"", "\",") + "</gsfax>";
                        _datastr += "<gsadress>" + rf.GetStr(content2, "\"gsadress\":\"", "\",") + "</gsadress>";

                        _datastr += "<flag>" + rf.GetStr(content2, "\"flag\":", ",") + "</flag>";
                        _datastr += "<userid>" + rf.GetStr(content2, "\"userid\":", ",") + "</userid>";
                        _datastr += "<lx>" + rf.GetStr(content2, "\"lx\":\"", "\",") + "</lx>";
                        _datastr += "<ip>" + rf.GetStr(content2, "\"ip\":\"", "\",") + "</ip>";
                        _datastr += "<hits>" + rf.GetStr(content2, "\"hits\":\"", "\",") + "</hits>";
                        _datastr += "<ISCheck>" + rf.GetStr(content2, "\"ISCheck\":\"", "\",") + "</ISCheck>";

                        _datastr += "<CB_Photo>" + rf.GetStr(content2, "\"CB_Photo\":\"", "\",") + "</CB_Photo>";
                        _datastr += "<CB_Class>" + rf.GetStr(content2, "\"CB_Class\":\"", "\",") + "</CB_Class>";
                        _datastr += "<ISTop>" + rf.GetStr(content2, "\"ISTop\":\"", "\",") + "</ISTop>";
                        _datastr += "<Topdate>" + rf.GetStr(content2, "\"Topdate\":\"", "\"") + "</Topdate>";


                        //开始写入
                        sw.Write(_datastr + "\r\n");
                        controllerArgs.Msg = "已抓到" + rf.GetStr(content2, "\"ch\":\"", "\",") + "的船舶档案信息" + rf.GetStr(content2, "\"title\":\"", "\",");

                    }
                    Program.helper.OntxtviewCompleted(this, controllerArgs);
                }


            }
            catch (Exception ex)
            {
                ClsLog clsLog = new ClsLog();
                clsLog.AddLog(DateTime.Now.ToString(), "分析数据失败" + ex.ToString());
                clsLog.AddLog(DateTime.Now.ToString(), entity.SType + ";" + entity.Url + ";");
                UrlContorl urlContorl = new UrlContorl();
    
            }
        }


        public user getuser()
        {
            user use = new user();

            use = Program.userList.Take();
            Program.userList.Add(use);

            return use;
        }
    }
}
