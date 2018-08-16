using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using  System.Collections;
using System.IO;
namespace Spider.Common
{
    class CookieFunc
    {
        
        public List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }
            return lstCookies;
        }
        public string GetCookiesStr(CookieContainer cookieContainer)
        {
            //然后我们再保存到文件：
            StringBuilder sbc = new StringBuilder();
            List<Cookie> cooklist = GetAllCookies(cookieContainer);
            foreach (Cookie cookie in cooklist)
            {
                sbc.AppendFormat("{0};{1};{2};{3};{4};{5}\r\n",
                    cookie.Domain, cookie.Name, cookie.Path, cookie.Port,
                    cookie.Secure.ToString(), cookie.Value);
            }
            return sbc.ToString();
            //FileStream fs = File.Create("d:\\chinarencookies.txt");
            //fs.Close();
            //File.WriteAllText("d:\\chinarencookies.txt", sbc.ToString(), System.Text.Encoding.Default);  
        }
        public CookieContainer StrToCookieContainer(string Str)
        {
            CookieContainer cookieContainer = new CookieContainer();
            //读出所有Cookie
            //string[] cookies = File.ReadAllText("d:\\chinarencookies.txt", System.Text.Encoding.Default).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] cookies = Str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            
            string[] cc;
            foreach (string c in cookies)
            {
                cc = c.Split(";".ToCharArray());
                Cookie ck = new Cookie(); ;
                ck.Discard = false;
                ck.Domain = cc[0];
                ck.Expired = true;
                ck.HttpOnly = true;
                ck.Name = cc[1];
                ck.Path = cc[2];
                ck.Port = cc[3];
                ck.Secure = bool.Parse(cc[4]);
                ck.Value = cc[5];
                cookieContainer.Add(ck);
            }
            return cookieContainer;
        }
    }
}
