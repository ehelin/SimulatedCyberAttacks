using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Shared
{
    public class Utilities
    {
        public static string DecodeClientBase64String(string encodedString)
        {
            string decodedString = string.Empty;

            if (!string.IsNullOrEmpty(encodedString))
            {
                byte[] data = Convert.FromBase64String(encodedString);
                decodedString = Encoding.UTF8.GetString(data);
            }

            return decodedString;
        }      
        public static string EncodeClientBase64String(string val)
        {
            string encodedString = string.Empty;
            
            if (!string.IsNullOrEmpty(val))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(val);
                encodedString = Convert.ToBase64String(data);
            }

            return encodedString;
        }
        public static string GetAppSetting(string key)
        {
            string value = string.Empty;
            string appSetting = System.Configuration.ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrEmpty(appSetting))
                value = appSetting;

            return value;
        }
        public static void ClearDb()
        {
            RunDbCommand("truncate table [Bucket].[User]");
            RunDbCommand("truncate table [Bucket].[BucketListItem]");
            RunDbCommand("truncate table [Bucket].[BucketListUser]");
        }
        private static void RunDbCommand(string sql)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            string curFile = string.Empty;

            try
            {
                conn = new SqlConnection(Utilities.GetAppSetting(Constants.DB_CONN));
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseDbObjects(conn, cmd, null);
            }
        }
        private static void CloseDbObjects(SqlConnection conn, SqlCommand cmd, SqlDataReader rdr)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }

            if (rdr != null)
            {
                rdr.Close();
                rdr.Dispose();
                rdr = null;
            }
        }     
    }
}
