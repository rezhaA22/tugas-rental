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
    public partial class tambahuser : Form
    {
        ConDasboardAdmin controler = new ConDasboardAdmin();
        public tambahuser()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Petugas User = new Petugas();
            User.Nama = bunifuTextBox1.Text;
            User.Alamat = bunifuTextBox2.Text;
            User.NomerTlp = bunifuTextBox4.Text;
            User.password = bunifuTextBox5.Text;
            string result = controler.addUser(User);
            int id;
            if (int.TryParse(result, out id))
            {
                MessageBox.Show($"ADD USER BERHASIL\n ID: {id}", "SUCCSES",
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                 bunifuTextBox1.Text="";
                 bunifuTextBox2.Text="";
                 bunifuTextBox4.Text="";
                 bunifuTextBox5.Text="";
            }
            else
            {
                MessageBox.Show(result, "GAGAL",
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
            }
        }
    }
}
