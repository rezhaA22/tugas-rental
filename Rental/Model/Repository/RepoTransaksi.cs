using System;
using System.Collections.Generic;

using System.Data.SQLite;
using Rental.Modell.Context;
using Rental.Modell.Entity;

namespace Rental.Model.Repository
{
    public class RepoTransaksi

    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public RepoTransaksi(DbContext context)
        {

            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(Transaksi transaksi)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into TRANSAKSI  ( ID_USER,
                                                    PLAT_NOMOR,
                                                    ID_PETUGAS,
                                                    TGL_TRANSAKSI,
                                                    TGL_HARUS_KEMBALI,
                                                    TGL_KEMBALI,
                                                    DENDA,
                                                    HARGA,
                                                    STATUS)
                           values (@user,@plat,@petugas,@tglTS,@tglHK,@tglKem,@denda,@harga,@status)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@user", transaksi.id_user);
                cmd.Parameters.AddWithValue("@plat", transaksi.platNomer);
                cmd.Parameters.AddWithValue("@petugas", transaksi.id_petugas);
                cmd.Parameters.AddWithValue("@tglTS", transaksi.tgl_transaksi);
                cmd.Parameters.AddWithValue("@tglHK", transaksi.tgl_harusKembali);
                cmd.Parameters.AddWithValue("@tglKem", transaksi.tgl_kembali);
                cmd.Parameters.AddWithValue("@denda", transaksi.denda);
                cmd.Parameters.AddWithValue("@harga", transaksi.harga);
                cmd.Parameters.AddWithValue("@status", transaksi.status);

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

        public int Updet(Transaksi transaksi)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"UPDATE TRANSAKSI SET
                                            TGL_KEMBALI = @tglKem,
                                            DENDA = @denda,
                                            HARGA = @harga,
                                            TOTAL = @total,
                                            STATUS = @status
                                            WHERE ID_TRANSAKSI = @id;";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@tglKem", transaksi.tgl_kembali);
                cmd.Parameters.AddWithValue("@denda", transaksi.denda);
                cmd.Parameters.AddWithValue("@harga", transaksi.harga);
                cmd.Parameters.AddWithValue("@total", transaksi.total);
                cmd.Parameters.AddWithValue("@status", transaksi.status);
                cmd.Parameters.AddWithValue("@id", transaksi.id);

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


        public List<Transaksi> ReadAll()
        {
            // membuat objek collection untuk menampung objek JenisKendaraan
            List<Transaksi> list = new List<Transaksi>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select *
                               from TRANSAKSI 
                               order by ID_TRANSAKSI ";

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
                            Transaksi transaksi = new Transaksi();
                            transaksi.id = dtr["ID_TRANSAKSI"].ToString();
                            transaksi.id_user = dtr["ID_USER"].ToString();
                            transaksi.id_petugas = dtr["ID_PETUGAS"].ToString();
                            transaksi.platNomer = dtr["PLAT_NOMOR"].ToString();
                            transaksi.denda = dtr["DENDA"].ToString();
                            transaksi.harga = dtr["HARGA"].ToString();
                            transaksi.tgl_transaksi = dtr["TGL_TRANSAKSI"].ToString();
                            transaksi.tgl_harusKembali = dtr["TGL_HARUS_KEMBALI"].ToString();
                            transaksi.tgl_kembali = dtr["TGL_KEMBALI"].ToString();
                            transaksi.total = dtr["TOTAL"].ToString();
                            transaksi.status = dtr["STATUS"].ToString();
                            // tambahkan objek JenisKendaraan ke dalam collection
                            list.Add(transaksi);
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
