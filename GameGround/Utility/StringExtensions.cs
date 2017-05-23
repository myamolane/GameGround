using System;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public static class StringExtensions
    {
        private static readonly MD5CryptoServiceProvider cryptoProvider = new MD5CryptoServiceProvider();
        public static string Md5Encrypt(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            byte[] bytes = Encoding.UTF7.GetBytes(input);
            bytes = cryptoProvider.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte num in bytes)
            {
                sb.AppendFormat("{0:x2}", num);
            }
            return sb.ToString();
        }
    }
}
