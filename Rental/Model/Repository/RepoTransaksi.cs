using System;
using System.Collections.Generic;

using System.Data.SQLite;
using Rental.Model.Entity;
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
                                                    TGL_TRANSAKSI,
                                                    TGL_SEWA,
                                                    TGL_HARUS_KEMBALI,
                                                    HARGA)
                           values (@user,@plat,@tglTS,@tglSewa,@tglHK,@harga)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@user", transaksi.id_user);
                cmd.Parameters.AddWithValue("@plat", transaksi.platNomer);
                cmd.Parameters.AddWithValue("@tglTS", transaksi.tgl_transaksi);
                cmd.Parameters.AddWithValue("@tglSewa", transaksi.tgl_sewa);
                cmd.Parameters.AddWithValue("@tglHK", transaksi.tgl_harusKembali);
                cmd.Parameters.AddWithValue("@harga", transaksi.harga);

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

        internal int selesaiTrasaksi(TrasaksiDetail detailTS)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"UPDATE TRANSAKSI SET
                                            TGL_KEMBALI = @tglKem,
                                            ID_PETUGAS=@petugas,
                                            DENDA = @denda,
                                            TOTAL = @total,
                                            STATUS = @status
                                            WHERE ID_TRANSAKSI = @id;";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@tglKem", detailTS.tgl_kembali);
                cmd.Parameters.AddWithValue("@petugas", detailTS.id_petugas);
                cmd.Parameters.AddWithValue("@denda", detailTS.denda);
                cmd.Parameters.AddWithValue("@total", detailTS.total);
                cmd.Parameters.AddWithValue("@status", detailTS.status);
                cmd.Parameters.AddWithValue("@id", detailTS.id);

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

        public int konirmasi(Petugas petugas,string idts)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"UPDATE TRANSAKSI SET
                                            ID_PETUGAS = @petugas,
                                            Konfirmasi = 'sudah'
                                            WHERE ID_TRANSAKSI = @id;";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@petugas", petugas.id);
                cmd.Parameters.AddWithValue("@id", idts);

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

        internal List<TransaksiDanKendaraan> getListTS(Petugas user)
        {
            // membuat objek collection untuk menampung objek JenisKendaraan
            List<TransaksiDanKendaraan> list = new List<TransaksiDanKendaraan>();

            try
            {
                // deklarasi perintah SQL
                string sql = $"SELECT T.Konfirmasi, K.IMG, K.MEREK, K.CATEGORY,K.NAMA, T.PLAT_NOMOR " +
                    $"FROM TRANSAKSI T JOIN KENDARAAN K ON T.PLAT_NOMOR = K.PLAT_NOMOR " +
                    $"WHERE T.ID_USER = {user.id}";

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
                            TransaksiDanKendaraan transaksi = new TransaksiDanKendaraan();
                            transaksi.status = dtr["Konfirmasi"].ToString();
                            transaksi.nama = dtr["NAMA"].ToString();
                            transaksi.merek = dtr["MEREK"].ToString();
                            transaksi.img = dtr["IMG"].ToString();
                            transaksi.platNomer= dtr["PLAT_NOMOR"].ToString();
                            transaksi.categori = dtr["CATEGORY"].ToString();

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

        internal List<TransaksiDanKendaraan> getAllListTS()
        {
            // membuat objek collection untuk menampung objek JenisKendaraan
            List<TransaksiDanKendaraan> list = new List<TransaksiDanKendaraan>();

            try
            {
                // deklarasi perintah SQL
                string sql = "SELECT T.Konfirmasi, K.IMG, K.MEREK, K.CATEGORY,K.NAMA AS kendaraan, T.PLAT_NOMOR,T.ID_TRANSAKSI,P.NAMA " +
                                "FROM TRANSAKSI T JOIN KENDARAAN K ON T.PLAT_NOMOR = K.PLAT_NOMOR JOIN" +
                                " PETUGAS P ON T.ID_USER = P.ID_PETUGAS ORDER BY T.Konfirmasi DESC";

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
                            TransaksiDanKendaraan transaksi = new TransaksiDanKendaraan();
                            transaksi.idTransaksi = dtr["ID_TRANSAKSI"].ToString();
                            transaksi.status = dtr["Konfirmasi"].ToString();
                            transaksi.nama = dtr["kendaraan"].ToString();
                            transaksi.namaUser = dtr["NAMA"].ToString();
                            transaksi.merek = dtr["MEREK"].ToString();
                            transaksi.img = dtr["IMG"].ToString();
                            transaksi.platNomer = dtr["PLAT_NOMOR"].ToString();
                            transaksi.categori = dtr["CATEGORY"].ToString();

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

        internal TrasaksiDetail GetDetailTS(string id)
        {
            // membuat objek collection untuk menampung objek JenisKendaraan
            TrasaksiDetail trasaksiDetail = new TrasaksiDetail();

            try
            {
                // deklarasi perintah SQL
                string sql = $"SELECT   T.*," +
                    $"K.MEREK, K.CATEGORY,K.NAMA AS kendaraan,K.IMG,K.JENIS_KENDARAAN," +
                    $"P.NAMA " +
                    $"FROM TRANSAKSI T JOIN KENDARAAN K ON T.PLAT_NOMOR = K.PLAT_NOMOR JOIN PETUGAS P ON T.ID_USER = P.ID_PETUGAS WHERE T.ID_TRANSAKSI = {id}";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {

                        if (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            trasaksiDetail.id = dtr["ID_TRANSAKSI"].ToString();
                            trasaksiDetail.id_user = dtr["ID_USER"].ToString();
                            trasaksiDetail.id_petugas = dtr["ID_PETUGAS"].ToString();
                            trasaksiDetail.tgl_sewa = dtr["TGL_SEWA"].ToString();
                            trasaksiDetail.tgl_kembali = dtr["TGL_KEMBALI"].ToString();
                            trasaksiDetail.tgl_harusKembali = dtr["TGL_HARUS_KEMBALI"].ToString();
                            trasaksiDetail.denda = dtr["DENDA"].ToString();
                            trasaksiDetail.harga = dtr["HARGA"].ToString();
                            trasaksiDetail.total = dtr["TOTAL"].ToString();
                            trasaksiDetail.status = dtr["Konfirmasi"].ToString();
                            trasaksiDetail.namaUser = dtr["NAMA"].ToString();
                            trasaksiDetail.merek = dtr["MEREK"].ToString();
                            trasaksiDetail.namaKendaraan = dtr["kendaraan"].ToString();
                            trasaksiDetail.categori = dtr["CATEGORY"].ToString();
                            trasaksiDetail.jenis_kendaraan = dtr["JENIS_KENDARAAN"].ToString();
                            trasaksiDetail.img = dtr["IMG"].ToString();
                            trasaksiDetail.platNomer = dtr["PLAT_NOMOR"].ToString();
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return trasaksiDetail;
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
                            transaksi.tgl_sewa = dtr["TGL_SEWA"].ToString();
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

        
    }
}
