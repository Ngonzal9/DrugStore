using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;
using System.IO;

namespace DrugStore
{
    public partial class Login : Form
    {
        public static string User;

        public Login()
        {
            InitializeComponent();
            try
            {
                DataBase.GetPath(File.ReadAllText(@"C:\Users\Public\Documents\serverpath.txt"));
            }
            catch (Exception)
            {
                MessageBox.Show("No esta conectado a la base de datos, ingrese el nombre del servidor\n" +
                    "Path:" + @"C: \Users\Public\Documents\serverpath.txt");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee EmployeeLog = new Employee();
            EmployeeLog.User = user.Text;
            User = EmployeeLog.User;
            EmployeeLog.Password = password.Text;
            if (DataBase.ValidateLogin(EmployeeLog))
            {
                Hide();
                Form menu = new Menu();
                menu.Show();
            }
            else
            {
                user.Text = "";
                password.Text = "";
                MessageBox.Show("Login no valido");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PathGetter pathGetter = new PathGetter();
            pathGetter.Show();
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
