using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DrugStore
{
    public static class DataBase
    {
        public static SqlConnection SQLcom;
        public static SqlCommand Cmd;
        public static SqlDataReader Reader;

        public static void GetPath(string path)
        {
            SQLcom = new SqlConnection(string.Format(@path));
        }
        public static bool VerifyConnection()
        {
            try
            {
                SQLcom.Open();
                SQLcom.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
        public static bool ValidateLogin(string user, string pass)
        {
            return true;
        }
    }
}
