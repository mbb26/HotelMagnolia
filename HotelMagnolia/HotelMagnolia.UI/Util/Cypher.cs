using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.IO;
using System.Reflection;

namespace HotelMagnolia.UI.Util
{
    public static class Cypher
    {

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        //private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        //public static string Crypt(this string text)
        //{
        //    SymmetricAlgorithm algorithm = DES.Create();
        //    ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
        //    byte[] inputbuffer = System.Text.Encoding.Unicode.GetBytes(text);
        //    byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
        //    return Convert.ToBase64String(outputBuffer);
        //}

        //public static string Decrypt(this string text)
        //{
        //    SymmetricAlgorithm algorithm = DES.Create();
        //    ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
        //    byte[] inputbuffer = Convert.FromBase64String(text);
        //    byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
        //    return Encoding.Unicode.GetString(outputBuffer);
        //}
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private static byte[] salt = Encoding.ASCII.GetBytes("somerandomstuff");

        public static string Encrypt(string plainText)
        {
            string keyString = "password";
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(keyString, salt);

            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(new CryptoStream(ms, new RijndaelManaged().CreateEncryptor(key.GetBytes(32), key.GetBytes(16)), CryptoStreamMode.Write));
            sw.Write(plainText);
            sw.Close();
            ms.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string base64Text)
        {
            string keyString = "password";
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(keyString, salt);
            string value = "Error al desencriptar el dato";

            try
            {
                ICryptoTransform d = new RijndaelManaged().CreateDecryptor(key.GetBytes(32), key.GetBytes(16));
                byte[] bytes = Convert.FromBase64String(base64Text);
                value = new StreamReader(new CryptoStream(new MemoryStream(bytes), d, CryptoStreamMode.Read)).ReadToEnd();
            }
            catch (Exception e) { } //ignore
            return value;
        }

        private static bool needsEncoding(string name)
        {
            string[] excludedNames = {"ID_"};
            bool needs = true;
            foreach (string excluded in excludedNames)
            {
                needs = needs && !name.Contains(excluded);
            }
            return needs;
        }

        public static Object EncryptObject(Object myObject)
        {
            foreach (PropertyInfo propertyInfo in myObject.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(myObject) is string && needsEncoding(propertyInfo.Name))
                {
                    System.Diagnostics.Debug.WriteLine("Encoding: " + propertyInfo.Name);
                    propertyInfo.SetValue(myObject, Encrypt(propertyInfo.GetValue(myObject).ToString()));
                }
            }
            return myObject;
        }

        public static Object DecryptObject(Object myObject)
        {
            foreach (PropertyInfo propertyInfo in myObject.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(myObject) is string && needsEncoding(propertyInfo.Name))
                {
                    System.Diagnostics.Debug.WriteLine("Decoding: " + propertyInfo.Name);
                    propertyInfo.SetValue(myObject, Decrypt(propertyInfo.GetValue(myObject).ToString()));
                }
            }
            return myObject;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //// This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        //// 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        //private const string initVector = "pemgail9uzpgzl88";
        //// This constant is used to determine the keysize of the encryption algorithm
        //private const int keysize = 256;
        ////Encrypt
        //public static string Crypt(string plainText)
        //{
        //    byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
        //    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        //    PasswordDeriveBytes password = new PasswordDeriveBytes("password", null);
        //    byte[] keyBytes = password.GetBytes(keysize / 8);
        //    RijndaelManaged symmetricKey = new RijndaelManaged();
        //    symmetricKey.Mode = CipherMode.CBC;
        //    ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
        //    MemoryStream memoryStream = new MemoryStream();
        //    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        //    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
        //    cryptoStream.FlushFinalBlock();
        //    byte[] cipherTextBytes = memoryStream.ToArray();
        //    memoryStream.Close();
        //    cryptoStream.Close();
        //    return Convert.ToBase64String(cipherTextBytes);
        //}
        ////Decrypt
        //public static string Decrypt(string cipherText)
        //{
        //    string passPhrase = "password";
        //    byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
        //    byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
        //    PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
        //    byte[] keyBytes = password.GetBytes(keysize / 8);
        //    RijndaelManaged symmetricKey = new RijndaelManaged();
        //    symmetricKey.Mode = CipherMode.CBC;
        //    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        //    MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
        //    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        //    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
        //    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        //    memoryStream.Close();
        //    cryptoStream.Close();
        //    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        //}
    }
    }
