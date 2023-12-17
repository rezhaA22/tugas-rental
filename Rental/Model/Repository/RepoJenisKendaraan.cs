using System;
using System.Collections.Generic;

using System.Data.SQLite;
using Rental.Modell.Context;
using Rental.Modell.Entity;

namespace Rental.Model.Repository
{
    public class RepoJenisKendaraan

    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public RepoJenisKendaraan(DbContext context)
        {

            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(JenisKendaraan jenisKendaraan)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into JENIS_KENDARAAN (JENIS)
                           values (@jeniskendaraan)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@jeniskendaraan", jenisKendaraan.jenis_kendaraan);

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


        public List<JenisKendaraan> ReadAll()
        {
            // membuat objek collection untuk menampung objek User
            List<JenisKendaraan> list = new List<JenisKendaraan>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select *
                               from JENIS_KENDARAAN
                               order by JENIS";

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
                            JenisKendaraan jenis = new JenisKendaraan();
                            jenis.id = dtr["ID_JENIS"].ToString();
                            jenis.jenis_kendaraan = dtr["JENIS"].ToString();

                            // tambahkan objek User ke dalam collection
                            list.Add(jenis);
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
