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

namespace Rental.View
{
    public partial class GantiPassword : Form
    {
        public delegate void deleget(String pass);

        public event deleget UpdetPass;
        Petugas user;
        public GantiPassword(Petugas user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void gantiPass_Click(object sender, EventArgs e)
        {
            string pass = Hasing.Decrypt(user.password);
            if (!pass.Equals(passLama.Text))
            {
                MessageBox.Show("password lama tidak valid", "PEMBERITAHUAN",
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                return;
            }
            if (passBaru.Equals(""))
            {
                MessageBox.Show("password baru harus di isi", "PEMBERITAHUAN",
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                return;
            }
            UpdetPass(passBaru.Text);
            passBaru.Text = "";
            passLama.Text = "";

        }
    }
}
