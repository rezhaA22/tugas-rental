using System;
using System.Collections.Generic;

using System.Data.SQLite;
using Rental.Modell.Context;
using Rental.Modell.Entity;

namespace Rental.Model.Repository
{
    public class RepoUser

    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public RepoUser(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(User user)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into USER (NAMA,ALAMAT)
                           values (@nama, @alamat)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nama", user.Nama);
                cmd.Parameters.AddWithValue("@alamat", user.Alamat);

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

        public int Update(User user)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update USER set NAMA = @nama, ALAMAT = @alamat
                           where ID_USER = @id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nama", user.Nama);
                cmd.Parameters.AddWithValue("@alamat", user.Alamat);
                cmd.Parameters.AddWithValue("@id", user.id);

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

        public int Delete(User user)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from USER
                           where ID_USER = @id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id", user.id);

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

        public List<User> ReadAll()
        {
            // membuat objek collection untuk menampung objek User
            List<User> list = new List<User>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select *
                               from USER
                               order by NAMA";

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
                            User user = new User();
                            user.id = dtr["ID_USER"].ToString();
                            user.Nama = dtr["NAMA"].ToString();
                            user.Alamat = dtr["ALAMAT"].ToString();

                            // tambahkan objek User ke dalam collection
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
