using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sqr.Common.Helper
{
    public sealed class EncryptionHelper
    {
        public static string ToMd5(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
