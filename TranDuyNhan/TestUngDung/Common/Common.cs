﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Common
{
    public class Common
    {
        public static string EncryptMD5(string sToEncrypt)
        {
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(sToEncrypt);

            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashByte = md5.ComputeHash(bytes);

            string hashString = "";
            for (int i = 0; i < hashByte.Length; i++)
            {
                hashString += Convert.ToString(hashByte[i], 16).PadLeft(2, '0');
            }
            return hashString.PadLeft(32, '0');
        }
    }
}