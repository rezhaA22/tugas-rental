using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Model.Entity
{
    class TransaksiDanKendaraan
    {
      
        public string idTransaksi { get; set; }
        public string konfirmasi { get; set; }
        public string status { get; set; }
        public string categori { get; set; }
        public string platNomer { get; set; }
        public string merek { get; set; }
        public string nama { get; set; }
        public string namaUser { get; set; }
        public string img { get; set; }
    }
}
