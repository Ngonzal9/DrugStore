﻿using System;
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
    public partial class Login : Form
    {
        public static string User;

        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User = user.Text;
            string Password = password.Text;
            if (DataBase.ValidateLogin(User,Password))
            {
                Hide();
                Form menu = new Menu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Login no valido");
            }
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
