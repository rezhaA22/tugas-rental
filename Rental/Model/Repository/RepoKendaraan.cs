using System;
using System.Collections.Generic;

using System.Data.SQLite;
using Rental.Modell.Context;
using Rental.Modell.Entity;

namespace Rental.Model.Repository
{
    public class RepoKendaraan

    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public RepoKendaraan(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(Kendaraan kendaraan)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into KENDARAAN (PLAT_NOMOR,CATEGORY,MEREK,NAMA,JENI_KENDARAAN,IMG,HARGA)
                           values (@PLAT, @CAT,@MEREK, @NAMA,@JENI,@img,@harga)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@PLAT", kendaraan.platNomer);
                cmd.Parameters.AddWithValue("@CAT", kendaraan.categori);
                cmd.Parameters.AddWithValue("@MEREK", kendaraan.merek);
                cmd.Parameters.AddWithValue("@NAMA", kendaraan.nama);
                cmd.Parameters.AddWithValue("@JENIS", kendaraan.jenis_kendaraan);
                cmd.Parameters.AddWithValue("@img", kendaraan.img);
                cmd.Parameters.AddWithValue("@harga", kendaraan.harga);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Update(Kendaraan kendaraan)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update KENDARAAN set CATEGORY = @CATEGORY,
                            NAMA = @NAMA,HARGA=@harga
                            where PLAT_MONOR = @plat";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@NAMA", kendaraan.nama);
                cmd.Parameters.AddWithValue("@CATEGORY", kendaraan.categori);
                cmd.Parameters.AddWithValue("@plat", kendaraan.platNomer);
                cmd.Parameters.AddWithValue("@harga", kendaraan.harga);


                try
                {
                    // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(Kendaraan kendaraan)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from KENDARAAN
                           where PLAT_NOMOR= @id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id", kendaraan.platNomer);

                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }

        public List<Kendaraan> ReadAll()
        {
            // membuat objek collection untuk menampung objek User
            List<Kendaraan> list = new List<Kendaraan>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select * from KENDARAAN ";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Kendaraan kendaraan = new Kendaraan();
                            kendaraan.platNomer = dtr["PLAT_NOMOR"].ToString();
                            kendaraan.categori = dtr["CATEGORY"].ToString();
                            kendaraan.merek = dtr["MEREK"].ToString();
                            kendaraan.nama = dtr["NAMA"].ToString();
                            kendaraan.jenis_kendaraan = dtr["JENIS_KENDARAAN"].ToString();
                            kendaraan.harga = dtr["HARGA"].ToString();
                            kendaraan.img = dtr["IMG"].ToString();

                            // tambahkan objek User ke dalam collection
                            list.Add(kendaraan);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return list;
        }

        public List<Kendaraan> filter(string argJenis, string argcategory, string harga)
        {
            // membuat objek collection untuk menampung objek User
            List<Kendaraan> list = new List<Kendaraan>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT *
                                FROM KENDARAAN
                                WHERE CATEGORY LIKE @cat
                                AND JENIS_KENDARAAN LIKE @jenis " +
                                (!string.IsNullOrEmpty(harga) ? $"ORDER BY HARGA {harga}" : "");

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {

                    cmd.Parameters.AddWithValue("@jenis",$"%{argJenis}%");
                    cmd.Parameters.AddWithValue("@cat", $"%{argcategory}%");
                    

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        Console.WriteLine(sql);
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Kendaraan kendaraan = new Kendaraan();
                            kendaraan.platNomer = dtr["PLAT_NOMOR"].ToString();
                            kendaraan.categori = dtr["CATEGORY"].ToString();
                            kendaraan.merek = dtr["MEREK"].ToString();
                            kendaraan.nama = dtr["NAMA"].ToString();
                            kendaraan.jenis_kendaraan = dtr["JENIS_KENDARAAN"].ToString();
                            kendaraan.harga = dtr["HARGA"].ToString();
                            kendaraan.img = dtr["IMG"].ToString();

                            // tambahkan objek User ke dalam collection
                            list.Add(kendaraan);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return list;
        }

        public List<Kendaraan> cari(string key)
        {
            // membuat objek collection untuk menampung objek User
            List<Kendaraan> list = new List<Kendaraan>();

            try
            {
                // deklarasi perintah SQL
                string sql = $"SELECT *FROM KENDARAAN WHERE CATEGORY LIKE '%{key}%' OR" +
                            $" PLAT_NOMOR LIKE '%{key}%' OR" +
                            $" MEREK LIKE '%{key}%' OR" +
                            $" NAMA LIKE '%{key}%'";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {


                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        Console.WriteLine(sql);
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Kendaraan kendaraan = new Kendaraan();
                            kendaraan.platNomer = dtr["PLAT_NOMOR"].ToString();
                            kendaraan.categori = dtr["CATEGORY"].ToString();
                            kendaraan.merek = dtr["MEREK"].ToString();
                            kendaraan.nama = dtr["NAMA"].ToString();
                            kendaraan.jenis_kendaraan = dtr["JENIS_KENDARAAN"].ToString();
                            kendaraan.harga = dtr["HARGA"].ToString();
                            kendaraan.img = dtr["IMG"].ToString();

                            // tambahkan objek User ke dalam collection
                            list.Add(kendaraan);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return list;
        }

        // Method untuk menampilkan data mahasiwa berdasarkan pencarian nama

    }
}
