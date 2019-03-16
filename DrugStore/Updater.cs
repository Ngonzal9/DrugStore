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
    public partial class Updater : Form
    {
        public Updater(string drug,string Qty,string precio)
        {
            InitializeComponent();
            textBox1.Text = drug;
            textBox3.Text = Qty;
            textBox2.Text = precio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase.UpdateInventory(textBox3.Text,textBox2.Text,textBox1.Text);
                MessageBox.Show("Registrado con exito!");
                Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Oops, hubo un problema");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
