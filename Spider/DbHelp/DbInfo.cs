using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Spider.DbHelp
{
    class DbInfo
    {
        /// <summary>
        /// 配置节的名字,表明连接到哪一个数据库
        /// </summary>
        public string DbConfigName
        {
            get { return _dbConfigName; }
        }
        private string _dbConfigName;

        /// <summary>
        /// 解密后的连接串
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
        }
        private string _connectionString;

        /// <summary>
        /// 默认的数据库配置元素名
        /// </summary>
        public static string DefaultDbConfigName
        {
            get { return _defaultDbConfigName; }
        }
        private static string _defaultDbConfigName;


        /// <summary>
        /// 缓存应用程序用到的所有数据库连接信息
        /// </summary>
        public static Dictionary<string, DbInfo> DbInfoDictionary
        {
            get { return _dbInfoDictionary; }
        }
        private static Dictionary<string, DbInfo> _dbInfoDictionary = new Dictionary<string, DbInfo>();

        static DbInfo()
        {
            //一开始就将整个配置信息读取出来, 并将连接信息存到DbInfoCollection集合中。
            Configuration.DbConfigSection _dbConfigSection = (Configuration.DbConfigSection)ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).Sections["dbConfigSection"];
            if (_dbConfigSection == null)
            {       //没有这个自定义配置段
                _defaultDbConfigName = "";
                return;
            }
            else
            {                                //有自定义配置段
                _defaultDbConfigName = _dbConfigSection.DefaultDb.Value;
                foreach (Configuration.DbConfigElement dbElement in _dbConfigSection.DbCollection)
                {
                    AddDbInfo(dbElement.Name, dbElement);
                }
            }
        }

        public static DbInfo GetDbInfo(string dbConfigName)
        {
            return _dbInfoDictionary[dbConfigName];
        }

        /// <summary>
        /// 如果配置段的连接信息还没有加入到_dbInfoDictionary中，则调用此方法加入之。
        /// </summary>
        /// <param name="dbConfigName"></param>
        /// <returns></returns>
        private static DbInfo AddDbInfo(string dbConfigName, Configuration.DbConfigElement dbElement)
        {
            string _encryptedString = Common.EncUtil.DesDecrypt(dbElement.EncryptedString.Trim());
            string _plainString = dbElement.PlainString.Trim();

            if (_encryptedString.EndsWith(";"))
            {
                _encryptedString = FxUtil.RemoveLastString(_encryptedString, ";");
            }
            if (_plainString.StartsWith(";"))
            {
                _plainString = _plainString.Substring(1);
            }

            //连接字符串由 加密部分和不加密部分组成
            string _connectionString = _encryptedString + ";" + _plainString;

            DbInfo dbi = new DbInfo();
            dbi._dbConfigName = dbConfigName.Trim();
            dbi._connectionString = _connectionString;

            _dbInfoDictionary.Add(dbi.DbConfigName, dbi);
            return dbi;
        }


        /// <summary>
        /// 有3种配置连接字符串的方式：
        /// 1.在web.config/app.config中配置。
        /// 2.别的位置保存连接字符串，再通过这个方法AddDbInfo加入到DbInfoDictionary中去,这种方式不允许设置DefaultDbConfigName.
        ///   因为可能别的位置也设置了DefaultDbConfigName，相冲突
        ///   在使用这种方式时要先调用DbInfo.AddDbInfo()加入连接信息，再调用DbFactory.CreateDb(dbConfigName).
        /// 3.混合1,2两种方式。注意DbConfigName不能重复。
        /// 
        /// 4. For use in some DLL,which has no app.config/web.config file.
        /// 4. 在部分DLL中使用，这些DLL连接到特定的资料库，并且没有自己的app.config/web.config文件。
        /// 
        /// 5. For Access, which must specify absolute path in connection string, eg:Server.MapPath(".") + "\imageDB.mdb"
        /// so,it's not suitable to save database configuration info in web.config/app.config file.
        /// 5. 用于Access资料库
        /// </summary>
        /// <param name="dbConfigName"></param>
        /// <param name="dbType"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbInfo AddDbInfo(string dbConfigName, string connectionString)
        {
            if (string.IsNullOrEmpty(dbConfigName.Trim()))
            {
                throw new Exception("DbInfo.AddDbInfo:dbConfigName must has a value.");
            }
            DbInfo dbi = new DbInfo();
            dbi._dbConfigName = dbConfigName.Trim();
            dbi._connectionString = connectionString;

            _dbInfoDictionary.Add(dbConfigName, dbi);
            return dbi;
        }
    }
}

