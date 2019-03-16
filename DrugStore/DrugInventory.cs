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
    public partial class DrugInventory : Form
    {
        public DrugInventory()
        {
            InitializeComponent();
            dataGridView1.DataSource = DataBase.FillDataInventory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Drug newDrug = new Drug(textBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text));
                DataBase.CreateDrug(newDrug);
                MessageBox.Show("Creacion exitosa!");
                dataGridView1.DataSource = DataBase.FillDataInventory();
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! algo ocurrio, intentelo de nuevo");
                dataGridView1.DataSource = DataBase.FillDataInventory();
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
                DataBase.DeleteDrug(textBox5.Text);
                MessageBox.Show("Borrado con exito!");
                dataGridView1.DataSource = DataBase.FillDataInventory();
            }
            catch (Exception)
            {
                MessageBox.Show("Usuario no existe", "Error");
            }
        }
    }
}
