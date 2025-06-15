using Kinar_Bakery.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Kinar_Bakery.Controller
{
    public class KonteksTransaksi
    {
        private readonly DatabaseConnection dbConnection = new DatabaseConnection();

        public List<ItemKeranjang> AmbilKeranjang(int id_pelanggan)
        {
            var keranjang = new List<ItemKeranjang>();
            try
            {
                string query = "SELECT tp.id_produk, p.nama AS nama_produk, tp.jumlah, kp.harga * tp.jumlah AS total_harga, p.stok " +
                               "FROM public.transaksi_penjualan tp " +
                               "JOIN public.produk p ON tp.id_produk = p.id_produk " +
                               "JOIN public.katalog_produk kp ON p.id_produk = kp.id_produk " +
                               "WHERE tp.id_pelanggan = @id_user AND tp.tanggal_transaksi::date = @tanggal";
                var parameters = new[]
                {
                    new NpgsqlParameter("@id_user", id_pelanggan),
                    new NpgsqlParameter("@tanggal", DateTime.Now.Date)
                };
                var result = dbConnection.ExecuteQuery(query, parameters);

                foreach (DataRow row in result.Rows)
                {
                    keranjang.Add(new ItemKeranjang
                    {
                        Id_produk = Convert.ToInt32(row["id_produk"]),
                        Nama_produk = row["nama_produk"] != DBNull.Value ? row["nama_produk"].ToString() : null,
                        Jumlah = Convert.ToInt32(row["jumlah"]),
                        Total_harga = row["total_harga"] != DBNull.Value ? Convert.ToDecimal(row["total_harga"]) : (decimal?)null,
                        Status = Convert.ToInt32(row["stok"]) > 0 ? "Tersedia" : "Habis"
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menjalankan query: {ex.Message}");
            }
            return keranjang;
        }

        public void TambahPesananSementara(int id_produk, int jumlah, int id_user)
        {
            try
            {
                var produkController = new KonteksProduk(); 
                var produk = produkController.AmbilBerdasarkanId(id_produk.ToString());
                if (produk == null)
                {
                    throw new Exception("Produk tidak ditemukan!");
                }

                decimal total_harga = produk.Harga * jumlah;

                string query = "INSERT INTO public.pesanan_sementara (id_user, id_produk, jumlah, total_harga, tanggal_pemesanan) " +
                               "VALUES (@id_user, @id_produk, @jumlah, @total_harga, CURRENT_TIMESTAMP)";
                var parameters = new[]
                {
                    new NpgsqlParameter("@id_user", id_user),
                    new NpgsqlParameter("@id_produk", id_produk),
                    new NpgsqlParameter("@jumlah", jumlah),
                    new NpgsqlParameter("@total_harga", total_harga)
                };
                dbConnection.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menambahkan pesanan sementara: {ex.Message}");
            }
        }

        public void KonfirmasiPesanan(int idPesananSementara)
        {
            try
            {
                string selectQuery = "SELECT id_user, id_produk, jumlah, total_harga FROM public.pesanan_sementara WHERE id_pesanan_sementara = @id_pesanan_sementara";
                var selectParameters = new[] { new NpgsqlParameter("@id_pesanan_sementara", idPesananSementara) };
                var result = dbConnection.ExecuteQuery(selectQuery, selectParameters);

                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    long id_user = Convert.ToInt64(row["id_user"]);
                    long id_produk = Convert.ToInt64(row["id_produk"]);
                    long jumlah = Convert.ToInt64(row["jumlah"]);
                    decimal total_harga = row["total_harga"] != DBNull.Value ? Convert.ToDecimal(row["total_harga"]) : 0m;

                    string validateQuery = "SELECT COUNT(*) FROM public.users WHERE id_user = @id_user";
                    var validateParameters = new[] { new NpgsqlParameter("@id_user", id_user) };
                    var validateResult = dbConnection.ExecuteQuery(validateQuery, validateParameters);
                    if (validateResult.Rows[0].Field<long>(0) == 0)
                    {
                        throw new Exception($"ID Pelanggan {id_user} tidak ditemukan di tabel Pelanggan.");
                    }

                    string insertQuery = "INSERT INTO public.transaksi_penjualan (id_outlet, id_karyawan, id_produk, jumlah, total, tanggal_transaksi, id_user) " +
                                        "VALUES (1, 1, @id_produk, @jumlah, @total_harga, CURRENT_TIMESTAMP, @id_user)";
                    var insertParameters = new[]
                    {
                        new NpgsqlParameter("@id_produk", id_produk),
                        new NpgsqlParameter("@jumlah", jumlah),
                        new NpgsqlParameter("@total_harga", total_harga),
                        new NpgsqlParameter("@id_user", id_user)
                    };
                    dbConnection.ExecuteNonQuery(insertQuery, insertParameters);

                    string updateQuery = "UPDATE public.produk SET stok = stok - @jumlah WHERE id_produk = @id_produk";
                    var updateParameters = new[]
                    {
                        new NpgsqlParameter("@jumlah", jumlah),
                        new NpgsqlParameter("@id_produk", id_produk)
                    };
                    dbConnection.ExecuteNonQuery(updateQuery, updateParameters);

                    string deleteQuery = "DELETE FROM public.pesanan_sementara WHERE id_pesanan_sementara = @id_pesanan_sementara";
                    var deleteParameters = new[] { new NpgsqlParameter("@id_pesanan_sementara", idPesananSementara) };
                    dbConnection.ExecuteNonQuery(deleteQuery, deleteParameters);
                }
                else
                {
                    throw new Exception("Pesanan dengan ID tersebut tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal mengonfirmasi pesanan: {ex.Message}");
            }
        }

        public void TambahTransaksi(int id_produk, int jumlah, int id_pelanggan)
        {
            try
            {
                string query = "INSERT INTO public.transaksi_penjualan (id_produk, id_pelanggan, jumlah, tanggal_transaksi, mp) " +
                               "VALUES (@id_produk, @id_pelanggan, @jumlah, @tanggal, @mp)";
                var parameters = new[]
                {
                    new NpgsqlParameter("@id_produk", id_produk),
                    new NpgsqlParameter("@id_pelanggan", id_pelanggan),
                    new NpgsqlParameter("@jumlah", jumlah),
                    new NpgsqlParameter("@tanggal", DateTime.Now),
                    new NpgsqlParameter("@mp", "Tunai")
                };
                dbConnection.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menambahkan transaksi: {ex.Message}");
            }
        }

        public void HapusTransaksi(int id_produk)
        {
            try
            {
                string query = "DELETE FROM public.transaksi_penjualan WHERE id_produk = @id_produk AND tanggal_transaksi::date = @tanggal";
                var parameters = new[]
                {
                    new NpgsqlParameter("@id_produk", id_produk),
                    new NpgsqlParameter("@tanggal", DateTime.Now.Date)
                };
                dbConnection.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menghapus transaksi: {ex.Message}");
            }
        }

        public void HapusPesananSementara(int idPesananSementara)
        {
            try
            {
                string deleteQuery = "DELETE FROM public.pesanan_sementara WHERE id_pesanan_sementara = @id_pesanan_sementara";
                var parameters = new[] { new NpgsqlParameter("@id_pesanan_sementara", idPesananSementara) };
                dbConnection.ExecuteNonQuery(deleteQuery, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menghapus pesanan sementara: {ex.Message}");
            }
        }
    }
}