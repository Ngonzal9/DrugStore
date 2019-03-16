using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace Client
{
    public static class DataBase
    {
        public static SqlConnection SQLcom;
        public static SqlCommand Cmd;
        public static SqlDataReader Reader;
        public static SqlDataAdapter TableAdapter;
        public static string Path;

        public static void GetPath(string path)
        {
            SQLcom = new SqlConnection(string.Format(@"{0}",path));
            Path = path;
            File.WriteAllText(@"C:\Users\Public\Documents\serverpath.txt", Path);
        }

        public static void CreateDrug(Drug newDrug)
        {
            Cmd = new SqlCommand("insert into Inventario(Medicamento,Precio,Cantidad) values(@Medicamento,@Precio,@Cantidad)", SQLcom);
            Cmd.Parameters.AddWithValue("@Medicamento", newDrug.DrugName);
            Cmd.Parameters.AddWithValue("@Precio", newDrug.Price);
            Cmd.Parameters.AddWithValue("@Cantidad", newDrug.Qty);
            SQLcom.Open();
            Cmd.ExecuteNonQuery();
            SQLcom.Close();
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

        public static void AddUser(Employee newEmployee)
        {
            Cmd = new SqlCommand("insert into Users(Usuario,Password,Name,LastName) values(@Usuario,@Password,@Name,@LastName)", SQLcom);
            Cmd.Parameters.AddWithValue("@Usuario",newEmployee.User);
            Cmd.Parameters.AddWithValue("@Password", newEmployee.Password);
            Cmd.Parameters.AddWithValue("@Name", newEmployee.Name);
            Cmd.Parameters.AddWithValue("@LastName", newEmployee.LastName);
            SQLcom.Open();
            Cmd.ExecuteNonQuery();
            SQLcom.Close();
        }

        public static void DeleteUser(string text)
        {
            Cmd = new SqlCommand("Select Usuario from Users where @Usuario=Usuario",SQLcom);
            Cmd.Parameters.AddWithValue("@Usuario",text);
            SQLcom.Open();
            Reader = Cmd.ExecuteReader();
            if (!Reader.Read())
            {
                SQLcom.Close();
                throw new Exception();
            }
            SQLcom.Close();
            Cmd = new SqlCommand("delete from Users where Usuario=@Usuario", SQLcom);
            Cmd.Parameters.AddWithValue("@Usuario", text);
            SQLcom.Open();
            Cmd.ExecuteNonQuery();
            SQLcom.Close();
        }
        public static void DeleteDrug(string text)
        {
            Cmd = new SqlCommand("Select Medicamento from Inventario where @Medicamento=Medicamento", SQLcom);
            Cmd.Parameters.AddWithValue("@Medicamento", text);
            SQLcom.Open();
            Reader = Cmd.ExecuteReader();
            if (!Reader.Read())
            {
                SQLcom.Close();
                throw new Exception();
            }
            SQLcom.Close();
            Cmd = new SqlCommand("delete from Inventario where Medicamento=@Medicamento", SQLcom);
            Cmd.Parameters.AddWithValue("@Medicamento", text);
            SQLcom.Open();
            Cmd.ExecuteNonQuery();
            SQLcom.Close();
        }

        public static bool ValidateLogin(Employee myEmployee)
        {
            Cmd = new SqlCommand("Select Password form Users where @Usuario=Usuario");
            Cmd.Parameters.AddWithValue("@Usuario", myEmployee.User);
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

        public static DataTable FillDataTable()
        {
            SQLcom.Open();
            TableAdapter = new SqlDataAdapter("select * from Users", SQLcom);
            DataTable Dt = new DataTable();
            TableAdapter.Fill(Dt);
            SQLcom.Close();
            return Dt;
        }
        public static DataTable FillDataInventory()
        {
            SQLcom.Open();
            TableAdapter = new SqlDataAdapter("select * from Inventario", SQLcom);
            DataTable Dt = new DataTable();
            TableAdapter.Fill(Dt);
            SQLcom.Close();
            return Dt;
        }
    }
}
