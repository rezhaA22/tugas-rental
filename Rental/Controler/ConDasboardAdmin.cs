using Rental.Model.Repository;
using Rental.Modell.Context;
using Rental.Modell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental.Controler
{
    class ConDasboardAdmin
    {
        DbContext context = new DbContext();
        RepoKendaraan repoKendaraan;
        RepoJenisKendaraan repojenis;
        RepoCategory repoCategory;
        RepoPetugas repoPetugas;
        public ConDasboardAdmin()
        {
            repoKendaraan = new RepoKendaraan(context);
            repojenis = new RepoJenisKendaraan(context);
            repoCategory = new RepoCategory(context);
            repoPetugas = new RepoPetugas(context);

        }

        public List<Kendaraan> ReadKendaraan()
        {
            List<Kendaraan> list = new List<Kendaraan>();

            list = repoKendaraan.ReadAll();

            return list;
        }

        internal string addUser(Petugas user)
        {
            String pesan = "";
            if (user.Nama.Equals(""))
            {
                pesan += "nama\n";
            }
            if (user.NomerTlp.Equals(""))
            {
                pesan += "nomer\n";
            }
            if (user.Alamat.Equals(""))
            {
                pesan += "alamat\n";
            }
            if (user.password.Equals(""))
            {
                pesan += "password\n";
            }
            if (!pesan.Equals(""))
            {
               
                return pesan+"gak boleh kosong!!!";
            }
            user.hakAkses = "User";
            user.password = Hasing.Encrypt(user.password);
            if (repoPetugas.Create(user)<=0)
            {
                return "gagal";
            }
            return "";
            
        }

        public List<Kendaraan> filterKendaraan(string jenis, string cat, string harga)
        {
            List<Kendaraan> list = new List<Kendaraan>();

            list = repoKendaraan.filter(jenis, cat, harga);

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

        internal string  addMobil(Kendaraan kendaraan)
        {
            String pesan = "";
            if (kendaraan.nama.Equals(""))
            {
                pesan += "nama\n";
            }
            if (kendaraan.platNomer.Equals(""))
            {
                pesan += "plat Nomer\n";
            }
            if (kendaraan.categori.Equals(""))
            {
                pesan += "categori\n";
            }
            if (kendaraan.harga.Equals(""))
            {
                pesan += "harga\n";
            }
            if (kendaraan.merek.Equals(""))
            {
                pesan += "merek\n";
            }
            if (kendaraan.jenis_kendaraan.Equals(""))
            {
                pesan += "jenis kendaraan\n";
            }
            if (kendaraan.img.Equals(""))
            {
                pesan += "img \n";
            }
            if (!pesan.Equals(""))
            {

                return pesan + "gak boleh kosong!!!";
            }
            if(repoKendaraan.Create(kendaraan) <= 0)
            {
                return "data gagal di tambah";
            }
            return "";
        }
    }
}
