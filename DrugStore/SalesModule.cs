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
    public partial class SalesModule : Form
    {
        bool QtyCheck = false;
        List<Drug> TotalSales;
        public SalesModule()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(DataBase.GetDrugs());
            TotalSales = new List<Drug>();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            textBox2.Text = DataBase.GetPrice(comboBox1.Text);
            textBox4.Text = Math.Round((float.Parse(textBox2.Text) * 0.18f),2).ToString();
            textBox1.Text = DataBase.GetQty(comboBox1.Text);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = Math.Round(float.Parse(textBox2.Text) * 1.18f * float.Parse(textBox3.Text), 2).ToString();
                if (int.Parse(textBox1.Text) < int.Parse(textBox3.Text))
                {
                    MessageBox.Show("No hay en inventario, seleccione una cantidad menor");
                    textBox3.Text = "0";
                    QtyCheck = false;
                }
                else if (textBox3.Text == "0")
                {
                    QtyCheck = false;
                }
                else
                {
                    QtyCheck = true;
                }
            }
            catch (Exception)
            {
            }
            
        }

        private int GetDrugQty(string text)
        {
            int temp =0;
            foreach (var item in TotalSales)
            {
                if (item.DrugName == text)
                {
                    temp += item.Qty;
                }
            }
            return temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (QtyCheck && comboBox1.Text != null && int.Parse(textBox1.Text) >= (GetDrugQty(comboBox1.Text) + int.Parse(textBox3.Text)))
            {
                TotalSales.Add(new Drug(comboBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text),
                    float.Parse(textBox4.Text), float.Parse(textBox5.Text)));
                UpdateSales();
            }
            else
            {
                MessageBox.Show("Complete todos los campos");
            }
        }

        private void UpdateSales()
        {
            float total = 0;
            float ITBIS = 0;
            textBox6.Text = "";
            foreach (var item in TotalSales)
            {
                textBox6.Text = textBox6.Text +"\n"+ $"{item.DrugName.PadRight(15, ' ')}.............RD &{item.Price}"+ "\n";
                total += item.TotalPrice;
                ITBIS += item.ITBIS;
            }
            label9.Text = total.ToString();
            label10.Text = ITBIS.ToString();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in TotalSales)
            {
                try
                {
                    DataBase.RemoveQty(item);
                    DataBase.AddSale(item, DateTime.Now, Login.User);
                    textBox6.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Oops! algo ocurrio, intentelo de nuevo");
                    TotalSales.Clear();
                    throw;
                }
            }
            TotalSales.Clear();
            MessageBox.Show("Venta exitosa!");
            textBox1.Text = DataBase.GetQty(comboBox1.Text);
        }
    }
}
