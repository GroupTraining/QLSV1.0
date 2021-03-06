﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QLSV.GUI
{
    public partial class Login : Form
    {
        Bus bus = new Bus();
        public Login()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (bus.check_login(txtusername.Text, txtpassword.Text) == 1)
            {
                GUI.Main main = new GUI.Main();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản nhập không đúng !");
            }
        }
    }
}
