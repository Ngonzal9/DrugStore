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
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! algo ocurrio, intentelo de nuevo");
                dataGridView1.DataSource = DataBase.FillDataInventory();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                string drug = dataGridView1.Rows[e.RowIndex].Cells["Medicamento"].FormattedValue.ToString();
                string Qty = dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].FormattedValue.ToString();
                string precio = dataGridView1.Rows[e.RowIndex].Cells["Precio"].FormattedValue.ToString();
                Updater update = new Updater(drug,Qty,precio);
                update.Show();

            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DrugInventory_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataBase.FillDataInventory();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataBase.FillDataInventory();
        }

    }
}
