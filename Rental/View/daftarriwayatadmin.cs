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
        public daftarriwayatadmin()
        {
            InitializeComponent();
            InisialisasiListView();
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
        }

    }
}
