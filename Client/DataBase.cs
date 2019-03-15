using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Client
{
    public static class DataBase
    {
        public static SqlConnection SQLcom;
        public static SqlCommand Cmd;
        public static SqlDataReader Reader;
        public static string Path;

        public static void GetPath(string path)
        {
            SQLcom = new SqlConnection(string.Format(@"{0}",path));
            Path = path;
            File.WriteAllText(@"C:\Users\Public\Documents\serverpath.txt", Path);
        }
        public static bool VerifyConnection()
        {
            try
            {
                SQLcom.Open();
                SQLcom.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ValidateLogin(Employee myEmployee)
        {
            Cmd = new SqlCommand("Select Password form Users where @User=User");
            Cmd.Parameters.AddWithValue("@User", myEmployee.User);
            SQLcom.Open();
            Reader = Cmd.ExecuteReader();
            if (Reader.Read())
            {
                if (Reader.GetString(0) == myEmployee.Password)
                {
                    SQLcom.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                SQLcom.Close();
                return false;
            }
        }
    }
}
