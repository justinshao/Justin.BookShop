using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Justin.BookShop.Controllers.Comman
{
    public static class Util
    {
        public static byte[] GetValCodeImage(out string codeStr)
        {
            ValidateCode code = new ValidateCode();
            codeStr = code.CreateValidateCode(4);
            return code.CreateValidateGraphic(codeStr, null);
        }

        /// <summary>
        /// 计算字符串MD5值
        /// </summary>
        /// <param name="sDataIn">文件路径</param>
        /// <returns>MD5值</returns>
        public static string GetMD5(string sDataIn)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;//定义字节类型数组变量，分别存储asci码数组和散列值数组

            //获得字符串的asci码数组
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            //计算asci码数组的散列值
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();

            //将散列值转换成以16进制（2位）表示的字符串,得到MD5值
            string strMD5 = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                //以16进制（2位）表示
                strMD5 += bytHash[i].ToString("X").PadLeft(2, '0');
            }

            return strMD5.ToLower();
        }

        public static String SerializeToJson(object obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(obj);
        }

        public static TResult Deserialize<TResult>(string json)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Deserialize<TResult>(json);
        }
    }
}
