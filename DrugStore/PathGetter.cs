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
    public partial class PathGetter : Form
    {
        public PathGetter()
        {
            InitializeComponent();
            textBox1.Text = DataBase.Path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PathGetter_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.GetPath(textBox1.Text);
            Close();
        }
    }
}
