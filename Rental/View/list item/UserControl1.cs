using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rental.View;
using Rental.Modell.Entity;

namespace Rental
{
    public partial class UserControl1 : UserControl
    {
        Petugas user;
        Kendaraan Kendaraan;
        public UserControl1(Petugas user,Kendaraan kendaraan)
        {
            this.user = user;
            this.Kendaraan = kendaraan;
            InitializeComponent();
        }

        #region Properties
        private string _title;
        private string _merk;
        private string _tipe;
        private string _plat;
        private string _harga;
        private string _foto;

        [Category("Custom Props")]
        public string Title

        {

            get { return _title; }
            set
            { _title = value; nama_kendaraan.Text = value; }

        }

        [Category("Custom Props")]
        public string Merk
        {
            get { return _merk; }
            set { _merk = value; merk.Text = value; }

        }

        [Category("Custom Props")]
        public string Tipe
        {
            get { return _tipe; }
            set { _tipe = value; tipe.Text = value; }

        }

        [Category("Custom Props")]
        public string Plat
        {
            get { return _plat; }
            set { _plat = value; plat_nomor.Text = value; }

        }

        [Category("Custom Props")]
        public string Harga
        {
            get { return _harga; }
            set { _harga = value; harga.Text = value; }

        }

        [Category("Custom Props")]
        public string Foto

        {
            get { return _foto; }
            set { _foto = value; foto.Image = new Bitmap(value); }
        }

        #endregion

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            SewaForm sewaForm=new SewaForm(user,Kendaraan);
            sewaForm.ShowDialog();
        }
    }
}