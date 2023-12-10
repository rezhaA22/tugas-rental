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

        public int Create(Category category)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into CATEGORY (CATEGORY,JENIS_KENDARRAN)
                           values (@CAT, @JENIS)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@CAT", category.categori);
                cmd.Parameters.AddWithValue("@JENIS", category.jenis_kendaraan);

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

        public int Update(Category category)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update CATEGORY set CATEGORY = @CAT, JENIS_KENDARAAN= @JENIS
                           where ID_CATEGORY= @id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@CAT", category.categori);
                cmd.Parameters.AddWithValue("@JENIS", category.jenis_kendaraan);
                cmd.Parameters.AddWithValue("@id", category.id);

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

        public int Delete(Category category)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from CATEGORY
                           where ID_CATEGORY = @id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id", category.id);

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
