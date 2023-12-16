using Rental.Controler;
using Rental.Model.Entity;
using Rental.Modell.Entity;
using Rental.View.list_item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental.View
{
    public partial class formkeranjang : Form
    {
        Petugas user;
        ConDasbord conDasbord = new ConDasbord();
        public formkeranjang(Petugas user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void formkeranjang_Load(object sender, EventArgs e)
        {
            List<TransaksiDanKendaraan> listTS = new List<TransaksiDanKendaraan>();
            listTS = conDasbord.getTransaksi(user);
            if (listTS.Count <= 0)
            {
                MessageBox.Show("transaksi koson", "PEMBERITAHUAN",
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                return;
            }

            foreach(TransaksiDanKendaraan transaksi in listTS)
            {
                listKeranjang listKeranjang = new listKeranjang();
                listKeranjang.Nama = transaksi.nama;
                listKeranjang.Merk = transaksi.merek;
                listKeranjang.Plat = transaksi.platNomer;
                listKeranjang.Tipe = transaksi.categori;
                listKeranjang.Status = (transaksi.konfirmasi.Equals("sudah")) ? "terkonfirmasi" : "belum terkonfirmasi";
                listKeranjang.Foto = Path.Combine(Application.StartupPath, "../../Assetimg/" + transaksi.img);

                flowLayoutPanel1.Controls.Add(listKeranjang);

            }
        }
    }
}
