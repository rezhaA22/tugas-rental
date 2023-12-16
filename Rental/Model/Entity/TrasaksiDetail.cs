using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Model.Entity
{
    class TrasaksiDetail
    {
        //daftar ts
        public string id { get; set; }
        public string id_user { get; set; }
        public string id_petugas { get; set; }
        public string platNomer { get; set; }
        public string tgl_sewa { get; set; }
        public string tgl_kembali { get; set; }
        public string tgl_harusKembali { get; set; }
        public string denda { get; set; }
        public string harga { get; set; }
        public string total { get; set; }
        public string status { get; set; }
        //user
        public string namaUser { get; set; }

        //kendaraan
        public string categori { get; set; }
        public string merek { get; set; }
        public string namaKendaraan { get; set; }
        public string jenis_kendaraan { get; set; }
        public string img { get; set; }
    }
}
