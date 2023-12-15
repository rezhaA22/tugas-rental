using Rental.Controler;
using Rental.Model.Entity;
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
    public partial class daftarriwayatadmin : Form
    {

        ConDasboardAdmin controler = new ConDasboardAdmin();
        public daftarriwayatadmin()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        private void daftarriwayatadmin_Load(object sender, EventArgs e)
        {
            addListTS();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void InisialisasiListView()
        {
            listview.View = System.Windows.Forms.View.Details;
            listview.FullRowSelect = true;
            listview.GridLines = true;
            listview.Columns.Add("No.", 35, HorizontalAlignment.Center);
            listview.Columns.Add("Nama", 91, HorizontalAlignment.Center);
            listview.Columns.Add("Plat Nomor", 200, HorizontalAlignment.Left);
            listview.Columns.Add("Nama Kendaraan", 200, HorizontalAlignment.Center);
            listview.Columns.Add("konfirmasi", 100, HorizontalAlignment.Center);
        }

        public void addListTS()
        {
            List<TransaksiDanKendaraan> listTS = controler.getAllTrasaksi();
            for(int i =0; i < listTS.Count; i++)
            {
                TransaksiDanKendaraan transaksi = listTS[i];
                ListViewItem item = new ListViewItem((i+1).ToString());
                item.SubItems.Add(transaksi.namaUser);
                item.SubItems.Add(transaksi.platNomer);
                item.SubItems.Add(transaksi.nama);
                item.SubItems.Add(transaksi.status);

                listview.Items.Add(item);
            }

        }



        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
