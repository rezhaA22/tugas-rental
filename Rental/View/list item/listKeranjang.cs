using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental.View.list_item
{
    public partial class listKeranjang : UserControl
    {
        public listKeranjang()
        {
            InitializeComponent();
        }
        #region Properties
        private string _merk;
        private string _tipe;
        private string _plat;
        private string _nama;
        private string _status;
        private string _foto;

        

        [Category("Custom Props")]
        public string Merk
        {
            get { return _merk; }
            set { _merk = value; merek.Text = value; }

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
            set { _plat = value; plat.Text = value; }

        }

        [Category("Custom Props")]
        public string Nama
        {
            get { return _nama; }
            set { _nama = value; nama.Text = value; }

        }
        [Category("Custom Props")]
        public string Status
        {
            get { return _status; }
            set { _status = value; status.Text = value; }

        }


        [Category("Custom Props")]
        public string Foto

        {
            get { return _foto; }
            set { _foto = value; foto.Image = new Bitmap(value); }
        }

        #endregion

    }
}
