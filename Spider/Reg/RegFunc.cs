using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;
using System.Collections;

namespace Spider.Reg
{
    class RegFunc
    {
        public string GetBegStr(string pContent, string regBegKey)
        {
            string regstr = "";
            string regular = "(?<={0})(.|\n)*";
            regular = string.Format(regular, regBegKey);
            Regex regex = new Regex(regular, RegexOptions.IgnoreCase);
            Match m = regex.Match(pContent);
            if (m.Length > 0)
            {
                regstr = m.Value.Trim();
            }
            return regstr;
        }
        public string GetEndStr(string pContent, string regEndKey)
        {
            string regstr = "";
            string regular = "(.|\n)*?(?={0})";
            regular = string.Format(regular, regEndKey);
            Regex regex = new Regex(regular, RegexOptions.IgnoreCase);
            Match m = regex.Match(pContent);
            if (m.Length > 0)
            {
                regstr = m.Value.Trim();
            }
            return regstr;
        }
        public string GetStr(string pContent, string regBegKey, string regEndKey)
        {
            string regstr = "";
            string regular = "(?<={0})(.|\n)*?(?={1})";
            regular = string.Format(regular, regBegKey, regEndKey);
            Regex regex = new Regex(regular, RegexOptions.IgnoreCase);
            Match m = regex.Match(pContent);
            if (m.Length > 0)
            {
                regstr = m.Value.Trim();
            }
            return regstr;
        }
        public string GetNextStr(string pContent, string regBegKey,string TagName,string TagName1) 
        {
            string regstr = "";
            string regular = "{0}：[.]*[^<]*</{1}>[\\s\\S]*?<{2}[.]*[^>]*>(?<value>.*?)</{2}>";
            regular = string.Format(regular, regBegKey, TagName, TagName1);
            Regex regex = new Regex(regular, RegexOptions.IgnoreCase);
            Match m = regex.Match(pContent);
            if (m.Length > 0)
            {
                regstr = m.Groups["value"].Value;
            }
            return regstr;
        }
        public string GetQueryString(string str, string paraName)
        {
            string ProID = "";
            Reg.RegFunc regFunc = new Reg.RegFunc();
            str = str.Replace("&amp;", "&");
            Regex regex = new Regex("(?<=" + paraName + "=)(.|\n)*?(?=&)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0)
            {
                ProID = regFunc.RemoveHtml(m.Value);
            }
            else
            {
                regex = new Regex("(?<=" + paraName + "=)(.|\n)*", RegexOptions.IgnoreCase);
                m = regex.Match(str);
                if (m.Length > 0)
                {
                    ProID = regFunc.RemoveHtml(m.Value);
                }
            }
            return ProID;
        }
        #region HTML标签
        //div
        public string GetDIVStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<div[.]*[^>]*>)(.|\n)*?(?=</div>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        
        //table
        public string GetTABLEStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<table[.]*[^>]*>)(.|\n)*?(?=</table>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }

        //tr
        public string GetTRStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<tr[.]*[^>]*>)(.|\n)*?(?=</tr>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        //td
        public string GetTDStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<td[.]*[^>]*>)(.|\n)*?(?=</td>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        //dl
        public string GetDLStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<dl[.]*[^>]*>)(.|\n)*?(?=</dl>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        //dd
        public string GetDDStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<dd[.]*[^>]*>)(.|\n)*?(?=</dd>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        //span
        public string GetSPANStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<span[.]*[^>]*>)(.|\n)*?(?=</span>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        //font
        public string GetFontStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<font[.]*[^>]*>)(.|\n)*?(?=</font>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        //ul
        public string GetULStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<ul[.]*[^>]*>)(.|\n)*?(?=</ul>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        //li
        public string GetLIStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<li[.]*[^>]*>)(.|\n)*?(?=</li>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        //A
        public string GetAStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<a[.]*[^>]*>)(.|\n)*?(?=</a>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        //TextArea
        public string GetTextAreaStr(string str)
        {
            string regstr = "";
            Regex regex = new Regex("(?<=<textarea[.]*[^>]*>)(.|\n)*?(?=</textarea>)", RegexOptions.IgnoreCase);
            Match m = regex.Match(str);
            if (m.Length > 0) regstr = m.Value.Trim();
            return regstr;
        }
        #endregion

        #region HTML标签集合
        /// <summary>
        /// Beg——End
        /// </summary>
        /// <param name="pContent"></param>
        /// <param name="regBegKey"></param>
        /// <param name="regEndKey"></param>
        /// <returns></returns>
        public ArrayList GetStrArr(string pContent, string regBegKey, string regEndKey)
        {
            ArrayList arr = new ArrayList();
            string regular = "(?<={0})(.|\n)*?(?={1})";
            regular = string.Format(regular, regBegKey, regEndKey);
            Regex regex = new Regex(regular, RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(pContent);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //div
        public ArrayList GetDIVArr(string roomSaleStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<div[.]*[^>]*>)(.|\n)*?(?=</div>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(roomSaleStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //table
        public ArrayList GetTABLEArr(string roomSaleStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<table[.]*[^>]*>)(.|\n)*?(?=</table>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(roomSaleStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //取第一层的tr
        public ArrayList GetTrArr(string str)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("<tr[^>]*>(?:(?:\\s|\\S)*?(?=<table|</tr>)(?(<table)<table[^>]*>(?:\\s|\\S)*?(?:</table>|(?:(?:<table[^>]*>(?:\\s|\\S)*?</table>(?:\\s|\\S)*?)*?</table>))(?:\\s|\\S)*?|))*</tr>", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(str);
            foreach (Match mm in mc)
            {
                arr.Add(mm.Value);
            }
            return arr;
        }
        //tr
        public ArrayList GetTRArr(string roomSaleStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<tr[.]*[^>]*>)(.|\n)*?(?=</tr>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(roomSaleStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //td
        public ArrayList GetTDArr(string roomSaleStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<td[.]*[^>]*>)(.|\n)*?(?=</td>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(roomSaleStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //dl
        public ArrayList GetDLArr(string roomSaleStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<dl[.]*[^>]*>)(.|\n)*?(?=</dl>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(roomSaleStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //dd
        public ArrayList GetDDArr(string roomSaleStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<dd[.]*[^>]*>)(.|\n)*?(?=</dd>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(roomSaleStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //span
        public ArrayList GetSPANArr(string RoomStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<span[.]*[^>]*>)(.|\n)*?(?=</span>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(RoomStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //font
        public ArrayList GetFontArr(string RoomStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<font[.]*[^>]*>)(.|\n)*?(?=</font>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(RoomStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //ul
        public ArrayList GetULArr(string RoomStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<ul[.]*[^>]*>)(.|\n)*?(?=</ul>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(RoomStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //li
        public ArrayList GetLIArr(string RoomStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<li[.]*[^>]*>)(.|\n)*?(?=</li>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(RoomStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        //A
        public ArrayList GetAArr(string RoomStr)
        {
            ArrayList arr = new ArrayList();
            Regex regex = new Regex("(?<=<a[.]*[^>]*>)(.|\n)*?(?=</a>)", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(RoomStr);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }
        #endregion

        #region 去掉所有html标签
        //1.styleReg:清除样式.如<style>.class{}</style>.全部替换为空.
        //2.scriptReg和styleReg同样的道理.
        //3.htmlReg :清除html标签的.输入为<div>aaa</div>,结果为:aaa
        //4.htmlSpaceReg :html空格&nbsp;替换为空格
        //5.spaceReg :把一个以上的空格替换为一个空格
        public string RemoveHtml(string src)
        {
            Regex htmlReg = new Regex(@"<[^>]+>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex htmlSpaceReg = new Regex("\\&nbsp\\;", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex spaceReg = new Regex("\\s{2,}|\\ \\;", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex styleReg = new Regex(@"<style(.*?)</style>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex scriptReg = new Regex(@"<script(.*?)</script>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            src = styleReg.Replace(src, string.Empty);
            src = scriptReg.Replace(src, string.Empty);
            src = htmlReg.Replace(src, string.Empty);
            src = htmlSpaceReg.Replace(src, " ");
            src = spaceReg.Replace(src, " ");
            //return src.Replace("&nbsp;", "").Replace(" ", "").Trim();
            return src.Trim();
        }

        //想去掉除了段落标记之外的所有html标记，只要页面的文字，好比是我把代码贴到记事本里面的效果，去掉了链接等代码。可以试试。

        public string DelHTML(string Htmlstring)//将HTML去除
        {
            //删除脚本
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"-->", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<!--.*", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"<A>.*</A>","");
            //Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"<[a-zA-Z]*=\.[a-zA-Z]*\?[a-zA-Z]+=\d&\w=%[a-zA-Z]*|[A-Z0-9]","");
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(amp|#38);", "&", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(lt|#60);", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(gt|#62);", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&#(\d+);", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            //Htmlstring=HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        #endregion

        #region aspx
     
  


        #endregion
    }
}
