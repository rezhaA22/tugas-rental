using Rental.Controler;
using Rental.Modell.Entity;
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
    
    public partial class SewaForm : Form
    {
        Petugas user;
        Kendaraan kendaraan;

        ConDasbord conDasboard = new ConDasbord();

        public SewaForm(Petugas user,
        Kendaraan kendaraan)
        {
            this.user = user;
            this.kendaraan = kendaraan;
            InitializeComponent();
        }
        private void SewaForm_Load(object sender, EventArgs e)
        {
            tglsewa.MinDate = DateTime.Today;
            tglkembali.MinDate = DateTime.Today.AddDays(1);

            nmpemesan.Text = user.Nama;
            harga.Text = "Rp"+kendaraan.harga;
            merek.Text = kendaraan.merek;
            nama.Text = kendaraan.nama;
            jeniskendaraan.Text = kendaraan.jenis_kendaraan;
            platnomor.Text = kendaraan.platNomer;
            tipe.Text = kendaraan.categori;
            ImgMobil.Image = new Bitmap(Path.Combine(Application.StartupPath, "../../Assetimg/" + kendaraan.img));
        }

        private void tglsewa_ValueChanged(object sender, EventArgs e)
        {
            updetTotal();
        }
        private void tglkembali_ValueChanged(object sender, EventArgs e)
        {
            updetTotal();

        }

        private void updetTotal()
        {
            DateTime tanggalSewa = tglsewa.Value;

            // Tanggal kembali
            DateTime tanggalKembali = tglkembali.Value;
            // Hitung selisih waktu (time span)
            TimeSpan selisihWaktu = tanggalKembali - tanggalSewa;

            totalbayar.Text = ((selisihWaktu.Days+1)*Int32.Parse(kendaraan.harga)).ToString();
        }

        private void btnbayar_Click(object sender, EventArgs e)
        {
            Transaksi transaksi = new Transaksi();
            
            transaksi.id_user = user.id;
            transaksi.platNomer = kendaraan.platNomer;
            transaksi.tgl_transaksi = DateTime.Today.ToString("dd/MM/yyyy");
            transaksi.tgl_harusKembali = tglkembali.Value.ToString("dd/MM/yyyy");
            transaksi.tgl_sewa = tglsewa.Value.ToString("dd/MM/yyyy");
            transaksi.harga = kendaraan.harga;
            transaksi.total = totalbayar.Text;
            if (conDasboard.bikinTrs(transaksi) > 0)
            {
                MessageBox.Show("transaksi berbasil", "SUCCSES",
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                this.Close();
            }
            else {

                MessageBox.Show("transaksi GAGAL", "GAGAL",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }
            
        }
    }
}
