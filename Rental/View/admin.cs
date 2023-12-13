﻿using Rental.Modell.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental.View
{
    public partial class admin : Form
    {
        public delegate void deleget();

        public event deleget Close;

        public Petugas AdminLogin;
        public admin(Petugas login)
        {
            this.AdminLogin = login;
            InitializeComponent();
        }

        public void login(Petugas petugas)
        {
            this.AdminLogin = petugas;
        }

        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
