using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spider.Configuration
{
    public class ProxyEntity
    {
        public ProxyEntity() {
            IsProxy = false;
        }
        //代理地址
        public string proxyAddess {
            get {
                return _proxyAddess;
            }
            set {
                _proxyAddess = value;
            }
        }
        private string _proxyAddess;

        //用户名
        public string proxyUid
        {
            get
            {
                return _proxyUid;
            }
            set
            {
                _proxyUid = value;
            }
        }
        private string _proxyUid;
        //密码
        public string proxyPwd
        {
            get
            {
                return _proxyPwd;
            }
            set
            {
                _proxyPwd = value;
            }
        }
        private string _proxyPwd;
        //消息对列地址
        public string msmqMsgPath
        {
            get
            {
                return _msmqMsgPath;
            }
            set
            {
                _msmqMsgPath = value;
            }
        }
        private string _msmqMsgPath;

        public bool IsProxy { get; set; }
    }
}
