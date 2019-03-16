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
    public partial class DisplaySales : Form
    {
        public DisplaySales()
        {
            InitializeComponent();
            dataGridView1.DataSource = DataBase.GetSalesTable();
            comboBox1.Items.AddRange(DataBase.GetUsers());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataBase.GetSalesByUser(comboBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
