using Rental.Controler;
using Rental.Model.Entity;
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
    public partial class detailtransaksiadmin : Form
    {
        ConDasboardAdmin controler = new ConDasboardAdmin();
        TrasaksiDetail detailTS;
        Petugas adminLogin;
        string idTS;
        public detailtransaksiadmin(Petugas adminLogin,string idTS)
        {
            this.adminLogin = adminLogin;
            this.idTS = idTS;
            
            InitializeComponent();
        }

        private void detailtransaksiadmin_Load(object sender, EventArgs e)
        {

            tglkembali.MinDate = DateTime.Today.AddDays(-1);

            detailTS = controler.getDetailTS(idTS);
            detailTS.id_petugas = adminLogin.id;

            nmpemesan.Text = detailTS.namaUser;
            denda.Text = detailTS.denda;
            harga.Text = detailTS.harga;
            tglsewa.Value = DateTime.Parse(detailTS.tgl_sewa);
            tglkembali.Value = DateTime.Today;
            tglHaruskembali.Value = DateTime.Parse(detailTS.tgl_harusKembali);
            merek.Text= detailTS.merek;
            nama.Text= detailTS.namaKendaraan;
            jeniskendaraan.Text= detailTS.jenis_kendaraan;
            platnomor.Text= detailTS.platNomer;
            tipe.Text= detailTS.categori;
            totalbayar.Text = (Convert.ToInt32(detailTS.harga) + Convert.ToInt32(detailTS.denda)).ToString();
            imgMobil.Image = new Bitmap(new Bitmap(Path.Combine(Application.StartupPath, "../../Assetimg/" + detailTS.img)));

        }
        private void tglkembali_ValueChanged(object sender, EventArgs e)
        {
            DateTime tanggalHarusKembali = DateTime.Parse(detailTS.tgl_harusKembali);

            DateTime kembali = tglkembali.Value;
            if (kembali > tanggalHarusKembali)
            {
                // Kode yang akan dijalankan jika sudah lewat dari batas kembali
                Console.WriteLine("Anda telat mengembalikan!");
                DateTime harusKembali = DateTime.Parse(detailTS.tgl_harusKembali);

                // Hitung selisih waktu
                TimeSpan selisih = kembali - harusKembali;

                denda.Text = (Convert.ToInt32(selisih.Days) * 50000).ToString();
                detailTS.denda = denda.Text;
                totalbayar.Text = (Convert.ToInt32(detailTS.harga) + Convert.ToInt32(detailTS.denda)).ToString();
            }
            else
            {
                denda.Text = "0";
                detailTS.denda = "0";
                totalbayar.Text = (Convert.ToInt32(detailTS.harga) + Convert.ToInt32(detailTS.denda)).ToString();
            }

            
        }

        private void btnbayar_Click(object sender, EventArgs e)
        {
            detailTS.status = "selesai";
            if(controler.SelesaiKanTransaksi(detailTS)>0)
            {
                MessageBox.Show("TRANSAKSI SELESAI", "BERHASIL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            MessageBox.Show("TRANSAKSI GAGAL SELESAI", "GAGAL",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
