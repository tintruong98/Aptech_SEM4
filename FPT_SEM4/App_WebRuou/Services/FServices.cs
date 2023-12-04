using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

namespace App_WebRuou.Services
{
    public class FServices
    {
        public FServices()
        {
        }
        //-----
        public string NgayThangNam()
        {
            DateTime dt = DateTime.Now;
            int thu = ((int)dt.DayOfWeek);
            string ngay = "";
            switch (thu)
            {
                case 6:
                    ngay = "Thứ bảy";
                    break;
                case 0:
                    ngay = "Chủ nhật";
                    break;
                case 1:
                    ngay = "Thứ hai";
                    break;
                case 2:
                    ngay = "Thứ ba";
                    break;
                case 3:
                    ngay = "Thứ tư";
                    break;
                case 4:
                    ngay = "Thứ năm";
                    break;
                case 5:
                    ngay = "Thứ sáu";
                    break;
                default:
                    break;
            }
            return ngay + " " + dt.ToString("dd/MM/yyyy");
        }
        //-----
        // 24 characters
        private static string key = "b14ca5898a4e4133bbce2ea2315a2022";

        // Ma hoa
        public string EnscryptPass(string password)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(password);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }
        // Giai ma
        public string DescryptPass(string password)
        {
            byte[] iv = new byte[16];
            byte[] array = Convert.FromBase64String(password);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(array))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        //-----
        //string body = string.Format("Bạn vừa nhận được liên hê từ: <b>{0}</b><br/>Email: {1}<br/>Nội dung: </br>",
        //string ps=29HanThuyen@@
        //-----
        public async Task<bool> SendMailGoogleSmtp(string _to, string _subject,string _body)
        {
            string _from = "ngotranhunganh08@gmail.com";
            string _gmailsend = "ngotranhunganh08@gmail.com";
            MailMessage message = new MailMessage(
                from: _from,
                to: _to,
                subject: _subject,
                body: _body
            );
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            // Tạo SmtpClient kết nối đến smtp.gmail.com kjlnvwczpwnmdczt
            
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential(_gmailsend, "rskmoptqfqcacxvs");
                client.EnableSsl = true;

                try
                {
                    await client.SendMailAsync(message);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //-----
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        //-----
        public string RandomNumber(int size)
        {
            Random random = new Random();
            string ch = "";
            for (int i = 0; i < size; i++)
            {
                ch = ch + random.Next(1, 9).ToString();
            }
            return ch.Trim();
        }
        //-----
        private static string keys = "2giotoitaigoccayda";
        public string Enscrypt(string toEncrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(keys));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(keys);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        //-----
        public string Descrypt(string toDecrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(keys));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(keys);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        //-----
        public DataTable ReadExcel(string FileExcel)
        {
            //get extension
            string extension = Path.GetExtension(FileExcel);
            string conString = string.Empty;
            switch (extension)
            {
                case ".xls": //Excel 97-03.
                    //conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileExcel + ";Extended Properties='Excel 8.0;HDR=YES'";
                    conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileExcel + ";Extended Properties='Excel 8.0;HDR=YES'";
                    break;
                case ".xlsx": //Excel 07 and above.
                    conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileExcel + ";Extended Properties='Excel 8.0;HDR=YES'";
                    break;
            }
            OleDbConnection oledbConn = new OleDbConnection(conString);

            //Get the name of First Sheet.
            oledbConn.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            DataTable data = null;
            //oledbConn.Open();

            string chuoixls = "SELECT * FROM [" + sheetName + "]";
            OleDbCommand cmd = new OleDbCommand(chuoixls, oledbConn);
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            oleda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            oleda.Fill(ds);
            data = ds.Tables[0];
            oledbConn.Close();
            return data;
        }
        //-----
        public DataTable ReadExcel2(string FileExcel)
        {
            //get extension
            string extension = Path.GetExtension(FileExcel);
            string conString = string.Empty;
            switch (extension)
            {
                case ".xls": //Excel 97-03.
                    conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileExcel + ";Extended Properties='Excel 8.0;HDR=YES'";
                    break;
                case ".xlsx": //Excel 07 and above.
                    conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileExcel + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
                    break;
            }
            DataTable dt = new DataTable();
            //conString = string.Format(conString, FileExcel);

            using (OleDbConnection connExcel = new OleDbConnection(conString))
            {
                using (OleDbCommand cmdExcel = new OleDbCommand())
                {
                    using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                    {
                        cmdExcel.Connection = connExcel;

                        //Get the name of First Sheet.
                        connExcel.Open();

                        DataTable dtExcelSchema;
                        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        //connExcel.Close();

                        //Read Data from First Sheet.
                        //connExcel.Open();
                        cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                        odaExcel.SelectCommand = cmdExcel;
                        odaExcel.Fill(dt);
                        connExcel.Close();
                    }
                }
            }
            return dt;
        }
        //-----
        //public string OpenfilePath()
        //{
        //    string filePath = "";
        //    var fileDialog = new OpenFileDialog();
        //    if (fileDialog.ShowDialog() == true)
        //    {
        //        filePath = fileDialog.FileName;
        //    }


        //    filePath = filePath.Replace(@"\", @"/");
        //    return filePath;
        //}

        //-----
        public string GetfilePath(IFormFile file)
        {
            var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Import");
            string filePath = Path.Combine(MainPath, file.FileName);
            var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);
            stream.Close();
            filePath = filePath.Replace(@"\", @"/");
            return filePath;
        }

        //-----
    }
}
