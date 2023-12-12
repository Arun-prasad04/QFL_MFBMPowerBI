using LDBPowerBIAPI.JsonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;
using LDBPowerBIAPI.DAL;

//using  MFBMQFLAPI.JsonClass.TabletUserDetails;

namespace LDBPowerBIAPI.DAL
{
    public class UserDetailsDAL: DataComponent
    {
      


        public DataSet GetProgressMonitoNewData(string FromVIN, string ToVIN, string FromDate, string ToDate)
        {
            SqlCommand cmd = new SqlCommand("MSP_GetLDB_API", con);
            //SqlCommand cmd = new SqlCommand("MSP_GetProgressMonitorNew", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PlantId", 3);

            if (!string.IsNullOrEmpty(FromVIN))
            {
                cmd.Parameters.AddWithValue("@VINFrom", FromVIN);
                cmd.Parameters.AddWithValue("@VINTo", ToVIN);
            }

            if (!string.IsNullOrEmpty(FromDate))
            {
                cmd.Parameters.AddWithValue("@FromDate",FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
            }
            
            return SelectCmd(cmd, sql_cs);
        }




        public class DEncrypt
        {
            public string Encrypt(string toEncrypt, string username)
            {

                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(username.ToLower()));
                hashmd5.Clear();
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            public string Decrypt(string cipherString, string username)
            {
                byte[] keyArray;
                byte[] toDecryptArray = Convert.FromBase64String(cipherString);
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(username.ToLower()));
                hashmd5.Clear();
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }


        }


    }
}