using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WSMS.Codes
{
    public class EncryptionDecryption
    {
        private static byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static string key = "@Lander+Kwaben=1";
        public static string Encrypt(string plaintet)
        {
            byte[] Key = Encoding.UTF8.GetBytes(key);
            AesManaged aes = new AesManaged();
            aes.Key = Key;
            aes.IV = IV;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] inputbyte = Encoding.UTF8.GetBytes(plaintet);
            cryptoStream.Write(inputbyte, 0, inputbyte.Length);
            cryptoStream.FlushFinalBlock();
            byte[] Encrypted = memoryStream.ToArray();
            return Convert.ToBase64String(Encrypted);
        }

        public static string Decrypt(string plaintet)
        {
            byte[] Key = Encoding.UTF8.GetBytes(key);
            AesManaged aes = new AesManaged();
            aes.Key = Key;
            aes.IV = IV;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

            byte[] inputbyte = Convert.FromBase64String(plaintet);
            cryptoStream.Write(inputbyte, 0, inputbyte.Length);
            cryptoStream.FlushFinalBlock();
            byte[] Decrypted = memoryStream.ToArray();
            return UTF8Encoding.UTF8.GetString(Decrypted, 0, Decrypted.Length);
        }
    }
}