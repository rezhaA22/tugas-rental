using Rental.Model.Repository;
using Rental.Modell.Context;
using Rental.Modell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Controler
{   


    public class ConTrasaksi
    {

        
        DbContext context = new DbContext();
        RepoTransaksi repo;
        public ConTrasaksi()
        {
           repo = new RepoTransaksi(context);

        }

        public int Updet(Transaksi ts)
        {
            int result = 0;
            DateTime tanggalSaatIni = DateTime.Now;

            DateTime tglHarusKembali = DateTime.Parse(ts.tgl_harusKembali);
            if (tanggalSaatIni > tglHarusKembali)
            {
                TimeSpan selisihHari = tanggalSaatIni - tglHarusKembali;
                int jarakHari = Math.Abs(selisihHari.Days);
                ts.denda =(jarakHari * 50000).ToString();
            }
            ts.total = (Int32.Parse(ts.denda) + Int32.Parse(ts.harga)).ToString();

            result=repo.Updet(ts);
            return result;
        }

        public List<Transaksi> ReadAll()
        {
            List<Transaksi> list = new List<Transaksi>();

            list = repo.ReadAll();

            return list ;
        }
    }
}
