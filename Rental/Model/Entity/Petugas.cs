using Rental.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Modell.Entity
{
    public class Petugas
    {
        public string id { get; set; }
        public string Nama { get; set; }
        public string NomerTlp { get; set; }
        public string Alamat { get; set; }
        public string password { get; set; } 
        public string hakAkses { get; set; }
    }
}
