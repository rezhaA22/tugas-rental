using System;
using System.Collections.Generic;

using System.Data.SQLite;
using Rental.Modell.Context;
using Rental.Modell.Entity;

namespace Rental.Model.Repository
{
    public class RepoCategory

    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public RepoCategory(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }


        public List<Category> ReadAll()
        {
            // membuat objek collection untuk menampung objek Category
            List<Category> list = new List<Category>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select *
                               from CATEGORY
                               order by ID_CATEGORY";

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
                            Category user = new Category();
                            user.id = dtr["ID_CATEGORY"].ToString();
                            user.categori = dtr["CATEGORY"].ToString();
                            user.jenis_kendaraan = dtr["JENIS_KENDARAAN"].ToString();

                            // tambahkan objek Category ke dalam collection
                            list.Add(user);
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
