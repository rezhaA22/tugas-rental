using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Modell.Entity
{
   public class Transaksi
    {
        public string id { get; set; }
        public string id_user { get; set; }
        public string id_petugas { get; set; }
        public string platNomer { get; set; }
        public string tgl_transaksi { get; set; }
        public string tgl_sewa{ get; set; }
        public string tgl_kembali{ get; set; }
        public string tgl_harusKembali{ get; set; }
        public string denda{ get; set; }
        public string harga{ get; set; }
        public string total{ get; set; }
        public string status{ get; set; }

    }
}