using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spider.DbHelp
{
    /// <summary>
    /// OpenFx框架内部使用的一些方法。
    /// 外部使用的Utility因为经常新增或修改，不应作为框架的一部分，
    /// 所以将原来的Utility目录中的类全部移除。
    /// liu fuhuang 2008-08-06
    /// </summary>
    internal class FxUtil
    {

        /// <summary>
        /// 移除最後字符(串)
        /// </summary>
        public static string RemoveLastString(string fullString, string endString)
        {
            if (fullString.EndsWith(endString))
            {
                return fullString.Substring(0, fullString.Length - endString.Length);
            }
            else
            {
                return fullString;
            }
        }

        /// <summary>
        /// 对字符串值加上单引号（SQL语句的语法）。
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        public static string Quote(string strValue)
        {
            string myValue = strValue.Replace("'", "''");   //字符串中原有一个单引号，则前面再加一个
            return "'" + myValue.Trim() + "'";
        }

        /// <summary>
        /// 返回DBNull.Value或者日期值，空日期值写进数据库时要用DBNull.Value
        /// </summary>
        /// <param name="dateParam"></param>
        /// <returns></returns>
        public static object GetDateOrDBNull(object dateParam)
        {
            object result = null;
            DateTime dateValue;
            if (dateParam == null)
            {
                result = DBNull.Value;
            }
            else
            {
                dateValue = Convert.ToDateTime(dateParam);
                if (dateValue == DateTime.MinValue)
                {      //not assign a value, MinValue: 0001/1/1,is a valid date in Oracle, but not valid in MS SQL.
                    result = DBNull.Value;
                }
                else
                {
                    result = dateValue;
                }
            }
            return result;
        }

    }
}
