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

namespace DrugStore
{
    public partial class UserWindow : Form
    {
        public UserWindow()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Employee newEmployee = new Employee(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                DataBase.AddUser(newEmployee);
                MessageBox.Show("Creacion exitosa!");
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Hubo un problema, intente de nuevo");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase.DeleteUser(textBox5.Text);
                MessageBox.Show("Borrado con exito!");
            }
            catch (Exception)
            {
                MessageBox.Show("Usuario no existe","Error");
            }
        }
    }
}
