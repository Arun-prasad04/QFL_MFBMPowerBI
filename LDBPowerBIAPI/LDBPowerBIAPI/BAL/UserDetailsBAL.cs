using LDBPowerBIAPI.DAL;
using LDBPowerBIAPI.JsonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Web;
//using static  LDBPowerBIAPI.JsonClass.TabletUserDetails;
using System.Net.Mail;
using System.Configuration;
using System.IO;

using System.Security.Cryptography;
using System.Text;
using System.Dynamic;
using System.Reflection;

namespace LDBPowerBIAPI.BAL
{
    public class UserDetailsBAL
    {

       



        public List<GetProgressMonitorNewForLDB> GetProgressMonitorNewData(string FromVIN, string ToVIN, string FromDate, string ToDate)
        {
           
            List<GetProgressMonitorNewForLDB> listofMonitorNew = new List<GetProgressMonitorNewForLDB>();



            UserDetailsDAL _ob = new UserDetailsDAL();
            DataSet ds = _ob.GetProgressMonitoNewData( FromVIN,  ToVIN,  FromDate,  ToDate);





            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    listofMonitorNew.Add(new GetProgressMonitorNewForLDB
                    {
                        VIN = Convert.ToString(ds.Tables[0].Rows[i]["VinNumber"]),
                        VehicleType = Convert.ToString(ds.Tables[0].Rows[i]["VehicleType"]),
                        Model = Convert.ToString(ds.Tables[0].Rows[i]["ModelName"]),
                        Qgate = Convert.ToString(ds.Tables[0].Rows[i]["GateName"]),
                        PartName = Convert.ToString(ds.Tables[0].Rows[i]["InspectionItem"]),
                        Defect = Convert.ToString(ds.Tables[0].Rows[i]["Defect"]),
                        完成日 = Convert.ToString(ds.Tables[0].Rows[i]["ReExaminationDate"]),
                        Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]),
                        責任部門 = Convert.ToString(ds.Tables[0].Rows[i]["責任部門"]),
                        修正部門 = Convert.ToString(ds.Tables[0].Rows[i]["修正部門"]),
                        修正予定日 = Convert.ToString(ds.Tables[0].Rows[i]["修正予定日"]),
                        完成予定日 = Convert.ToString(ds.Tables[0].Rows[i]["完成予定日"]),
                        緊急 = Convert.ToString(ds.Tables[0].Rows[i]["緊急"]),
                        備考 = Convert.ToString(ds.Tables[0].Rows[i]["備考"]),



                    });
                  
                }
            }

            return listofMonitorNew;
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

        public class MyClass
        {
            public int Id { get; set; }// Existing property
            public List<dynamic> Information { get; set; }
            // Added above property to handle new properties which will come dynamically  
        }

        //-------- While Implementing ----
       

    }

    }


