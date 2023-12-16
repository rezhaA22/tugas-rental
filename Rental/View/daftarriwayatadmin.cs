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
        
        Petugas adminLogin;

        ConDasboardAdmin controler = new ConDasboardAdmin();
        public daftarriwayatadmin(Petugas admin)
        {
            this.adminLogin = admin;
            InitializeComponent();
        }

        private void daftarriwayatadmin_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void LoadList()
        {
            listview.Clear();

            listview.View = System.Windows.Forms.View.Details;
            listview.FullRowSelect = true;
            listview.GridLines = true;
            listview.Columns.Add("id.").Width = 0;
            listview.Columns.Add("No.", 35, HorizontalAlignment.Center);
            listview.Columns.Add("Nama", 91, HorizontalAlignment.Center);
            listview.Columns.Add("Plat Nomor", 200, HorizontalAlignment.Left);
            listview.Columns.Add("Nama Kendaraan", 200, HorizontalAlignment.Center);
            listview.Columns.Add("konfirmasi", 100, HorizontalAlignment.Center);
            listview.Columns.Add("Status", 100, HorizontalAlignment.Center);
            listview.MouseDoubleClick += ListViewItem_DoubleClick;

            List<TransaksiDanKendaraan> listTS = controler.getAllTrasaksi();
            for(int i =0; i < listTS.Count; i++)
            {
                TransaksiDanKendaraan transaksi = listTS[i];
                ListViewItem item = new ListViewItem(transaksi.idTransaksi);
                item.SubItems.Add((i+1).ToString());
                item.SubItems.Add(transaksi.namaUser);
                item.SubItems.Add(transaksi.platNomer);
                item.SubItems.Add(transaksi.nama);
                item.SubItems.Add(transaksi.konfirmasi);
                item.SubItems.Add(transaksi.status);
                listview.Items.Add(item);
            }

        }
        private void ListViewItem_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListView listView = (ListView)sender;

                if (listView.SelectedItems.Count > 0)
                {
                    // Mendapatkan item yang di-klik
                    ListViewItem doubleClickedItem = listView.SelectedItems[0];

                    string id = doubleClickedItem.SubItems[0].Text; 
                    new detailtransaksiadmin(adminLogin, id).ShowDialog();
                    LoadList();
                }
            }
        }




        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (listview.SelectedItems.Count <= 0)
            {
                MessageBox.Show("pilih minimal 1 item", "GAGAL",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int pesan = 0;
            foreach(ListViewItem item in listview.SelectedItems)
            {
                string id = item.SubItems[0].Text;
                pesan += controler.konfirmasi(adminLogin, id);
            }
            LoadList();
            MessageBox.Show($"{pesan} terasaksi berhasil di konfirmasi", "berhasil",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

       
    }
}
