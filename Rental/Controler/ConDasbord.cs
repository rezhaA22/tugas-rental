using Rental.Model.Entity;
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
  
    class ConDasbord
    {
        DbContext context = new DbContext();
        RepoKendaraan repoKendaraan;
        RepoJenisKendaraan repojenis;
        RepoCategory repoCategory;
        RepoTransaksi repoTrasaksi;
        public ConDasbord()
        {
            repoKendaraan = new RepoKendaraan(context);
            repojenis = new RepoJenisKendaraan(context);
            repoCategory = new RepoCategory(context);
            repoTrasaksi = new RepoTransaksi(context);
        }

        public List<Kendaraan> ReadKendaraan()
        {
            List<Kendaraan> list = new List<Kendaraan>();

            list = repoKendaraan.ReadAll();

            return list;
        }

        public List<Kendaraan> filterKendaraan(string jenis,string cat,string harga)
        {
            List<Kendaraan> list = new List<Kendaraan>();

            list = repoKendaraan.filter(jenis,cat,harga);

            return list;
        }

        public List<Kendaraan> catriKendaraan(string key)
        {
            List<Kendaraan> list = new List<Kendaraan>();

            list = repoKendaraan.cari(key);

            return list;
        }

        public List<JenisKendaraan> ReadJenis()
        {
            List<JenisKendaraan> list = new List<JenisKendaraan>();

            list = repojenis.ReadAll();

            return list;
        }

        public List<Category> ReadCategory()
        {
            List<Category> list = new List<Category>();

            list = repoCategory.ReadAll();

            return list;
        }
        public int bikinTrs(Transaksi transaksi)
        {
            int result=0;

            result = repoTrasaksi.Create(transaksi);

            return result;
        }

        public List<TransaksiDanKendaraan> getTransaksi(Petugas user)
        {
            List<TransaksiDanKendaraan> listTS = new List<TransaksiDanKendaraan>();

            listTS = repoTrasaksi.getListTS(user);

            return listTS;
        }



    }

}
