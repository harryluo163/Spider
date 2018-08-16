using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataSpider.Page;

namespace Spider.DbHelp
{
    public class DBEntity
    {
        /// <summary>
        /// 内容实例
        /// </summary>
        public PageContentEntity pageContentEntity 
        {
            get { return _pagecontentEntity; }
            set { _pagecontentEntity = value; }
        }

        private PageContentEntity _pagecontentEntity;

        /// <summary>
        /// SqlCommand
        /// </summary>
        public SqlCommand myCom 
        {
            get { return _mycom; }
            set { _mycom = value; }
        }

        private SqlCommand _mycom;
    }
}
