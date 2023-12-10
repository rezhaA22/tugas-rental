using System;
using System.Collections.Generic;

using System.Data.SQLite;
using Rental.Controler;
using Rental.Modell.Context;
using Rental.Modell.Entity;

namespace Rental.Model.Repository
{
    public class RepoPetugas

    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public RepoPetugas(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(Petugas petugas)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into PETUGAS (NAMA,ALAMAT,NOMOR_TELEPONE,PASSWORD)
                           values (@nama, @alamat,@no,@pas)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nama", petugas.Nama);
                cmd.Parameters.AddWithValue("@alamat", petugas.Alamat);
                cmd.Parameters.AddWithValue("@no", petugas.NomerTlp);
                cmd.Parameters.AddWithValue("@pas", petugas.password);

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

        public int Update(Petugas petugas)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update PETUGAS set NAMA = @nama, ALAMAT = @alamat, NOMOR_TELEPHONE = @no
                           where ID_PETUGAS = @id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nama", petugas.Nama);
                cmd.Parameters.AddWithValue("@alamat", petugas.Alamat);
                cmd.Parameters.AddWithValue("@NO", petugas.NomerTlp);
                cmd.Parameters.AddWithValue("@id", petugas.id);

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

        public int Delete(Petugas petugas)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from PETUGAS
                           where ID_PETUGAS = @id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id", petugas.id);

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

        public List<Petugas> ReadAll()
        {
            // membuat objek collection untuk menampung objek PETUGAS
            List<Petugas> list = new List<Petugas>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select *
                               from PETUGAS
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
                            Petugas petugas = new Petugas();
                            petugas.id = dtr["ID_PETUGAS"].ToString();
                            petugas.Nama = dtr["NAMA"].ToString();
                            petugas.Alamat = dtr["ALAMAT"].ToString();
                            petugas.NomerTlp = dtr["NOMOR_TELEPHONE"].ToString();
                            petugas.password = dtr["PASSWORD"].ToString();

                            // tambahkan objek PETUGAS ke dalam collection
                            list.Add(petugas);
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

        public Petugas ReadLogin(string id, string pass)
        {
            Petugas user = null;
            List<Petugas> list = ReadAll();
            foreach(Petugas petugas in list)
            {
                string password = Hasing.Decrypt(petugas.password);
                if (petugas.id.Equals(id)&&pass.Equals(password))
                {
                    user = petugas;
                    break;
                }
            }
            

            return user;
        }

    }
}
