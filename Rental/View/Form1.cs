using Rental.Controler;
using Rental.Modell.Entity;
using Rental.View;
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
                if (user.hakAkses == "Admin")
                {

                    new admin(user).Show();
                }
                else if (user.hakAkses == "User")
                {
                    new Form2(user).Show();
                }
                this.Hide();
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
