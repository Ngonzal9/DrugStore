using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Client;

namespace DrugStore
{
    public partial class Menu : Form
    {

        public Menu()
        {
            InitializeComponent();
            label2.Text = Login.User;
            try
            {
                DataBase.GetPath(File.ReadAllText(@"C:\Users\Public\Documents\serverpath.txt"));
            }
            catch (Exception)
            {
                MessageBox.Show("No esta conectado a la base de datos, ingrese el nombre delservidor");
            }
            if (DataBase.VerifyConnection())
            {
                label9.Text = "Connected";
                label9.ForeColor = System.Drawing.Color.Chartreuse;
            }
            else 
            {
                label9.Text = "Disconnected";
                label9.ForeColor = System.Drawing.Color.Red;
                
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Button_Click(object sender, EventArgs e)
        {
            if (Login.User == "admin")
            {
                UserWindow userWindow = new UserWindow();
                userWindow.Show();
            }
            else
            {
                MessageBox.Show("Usted no tiene acceso");
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (DataBase.VerifyConnection())
            {
                label9.Text = "Connected";
                label9.ForeColor = System.Drawing.Color.Chartreuse;
            }
            else
            {
                label9.Text = "Disconnected";
                label9.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PathGetter pathGetter = new PathGetter();
            pathGetter.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login Change = new Login();
            Change.Show();
            Close();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void User_Creation_Click(object sender, EventArgs e)
        {
            DrugInventory inventory = new DrugInventory();
            inventory.Show();
        }

        private void Drugs_Inventory_Click(object sender, EventArgs e)
        {
            SalesModule newSales = new SalesModule();
            newSales.Show();
        }
    }
}
