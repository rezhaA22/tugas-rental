using Rental.Controler;
using Rental.Modell.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental
{
    public partial class Form1 : Form
    {
        public delegate void LoginEvent(Petugas petugas);

        // deklarasi event ketika terjadi proses input data baru
        public event LoginEvent Login;

        ConLogin controler = new ConLogin();

        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string id = textId.Text;
            string pass = textPass.Text;
            Petugas user = controler.login(id, pass);

            if (user!=null){
                this.Close();
                Login(user);
            }
            else
            {
                MessageBox.Show("login gagal", "Peringatan",
                MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);
            }


        }
    }
}
