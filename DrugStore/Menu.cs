using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugStore
{
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
            label2.Text = Login.User;
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

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (DataBase.VerifyConnection())
            {
                label3.Text = "Connected";
            }
            else
            {
                label3.Text = "Disconnected";
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
    }
}
