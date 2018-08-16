using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Spider.Common
{
    class EncUtil
    {
        /// <summary>
        /// Des加密
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public static string DesEncrypt(string clearText)
        {
            byte[] byKey = System.Text.ASCIIEncoding.UTF8.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.UTF8.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            MemoryStream memStream = new MemoryStream();
            //以写模式 把数据流和要加密的数据流建立连接
            CryptoStream cryStream = new CryptoStream(memStream, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            //将要加密的数据转换为UTF8编码的数组
            byte[] clearTextArray = Encoding.UTF8.GetBytes(clearText);

            //加密 并写到 内存流memStream中
            cryStream.Write(clearTextArray, 0, clearTextArray.Length);
            //清空缓冲区
            cryStream.FlushFinalBlock();

            //将8位无符号整数数组 转换为 等效的System.String 的形式.
            return Convert.ToBase64String(memStream.ToArray());
        }

        /// <summary>
        /// Des解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DesDecrypt(string encryptedText)
        {
            byte[] byKey = System.Text.ASCIIEncoding.UTF8.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.UTF8.GetBytes(IV_64);

            //
            byte[] byteArray = Convert.FromBase64String(encryptedText);

            MemoryStream memStream = new MemoryStream();

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            CryptoStream cryStream = new CryptoStream(memStream, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Write);

            cryStream.Write(byteArray, 0, byteArray.Length);
            //清空缓冲区
            cryStream.FlushFinalBlock();

            System.Text.Encoding encoding = new System.Text.UTF8Encoding();
            //把字节数组转换为 等效的System.String 的形式.
            return encoding.GetString(memStream.ToArray());
        }

        private const string KEY_64 = "MyPubKey";  //公钥
        private const string IV_64 = "MyPriKey";   //私钥,注意了:是8个字符，64位

    }
}
