using Kinar_Bakery.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinar_Bakery.Controller
{
    public class KonteksProduk
    {
        private readonly DatabaseConnection dbConnection = new DatabaseConnection();
        private List<Produk> daftarProduk = new List<Produk>();

        public List<Produk> AmbilSemua(string opsiUrut = null)
        {
            daftarProduk.Clear();
            string query = "SELECT p.id_produk, p.nama, p.jenis, p.stok, kp.harga " +
                           "FROM public.produk p " +
                           "JOIN public.katalog_produk kp ON p.id_produk = kp.id_produk";
            var result = dbConnection.ExecuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                daftarProduk.Add(new Produk
                {
                    Id_produk = Convert.ToInt32(row["id_produk"]),
                    Nama = row["nama"].ToString(),
                    Jenis = row["jenis"].ToString(),
                    Stok = Convert.ToInt32(row["stok"]),
                    Harga = row["harga"] != DBNull.Value ? Convert.ToDecimal(row["harga"]) : 0m
                });
            }

            if (opsiUrut == "Harga Tertinggi")
                return daftarProduk.OrderByDescending(p => p.Harga).ToList();
            else if (opsiUrut == "Harga Terendah")
                return daftarProduk.OrderBy(p => p.Harga).ToList();

            return daftarProduk;
        }

        public Produk AmbilBerdasarkanId(string id_produk)
        {
            try
            {
                if (!int.TryParse(id_produk, out int id))
                {
                    throw new Exception("ID produk tidak valid!");
                }

                string query = "SELECT p.id_produk, p.nama, p.jenis, p.stok, kp.harga " +
                               "FROM public.produk p " +
                               "JOIN public.katalog_produk kp ON p.id_produk = kp.id_produk " +
                               "WHERE p.id_produk = @id";
                var parameters = new[] { new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = id } };
                var result = dbConnection.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];
                    return new Produk
                    {
                        Id_produk = Convert.ToInt32(row["id_produk"]),
                        Nama = row["nama"].ToString(),
                        Jenis = row["jenis"].ToString(),
                        Stok = Convert.ToInt32(row["stok"]),
                        Harga = Convert.ToDecimal(row["harga"])
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal mengambil produk: {ex.Message}");
            }
        }

        public List<Produk> AmbilBestSeller()
        {
            try
            {
                string query = @"
                    SELECT p.id_produk, p.nama, p.jenis, p.stok, kp.harga, 
                           COALESCE(SUM(tp.jumlah), 0) as total_terjual
                    FROM public.produk p
                    LEFT JOIN public.transaksi_penjualan tp ON p.id_produk = tp.id_produk
                    JOIN public.katalog_produk kp ON p.id_produk = kp.id_produk
                    GROUP BY p.id_produk, p.nama, p.jenis, p.stok, kp.harga
                    ORDER BY total_terjual DESC LIMIT 5";

                var result = dbConnection.ExecuteQuery(query, new NpgsqlParameter[] { });
                var bestSellerList = new List<Produk>();

                foreach (DataRow row in result.Rows)
                {
                    bestSellerList.Add(new Produk
                    {
                        Id_produk = Convert.ToInt32(row["id_produk"]),
                        Nama = row["nama"].ToString(),
                        Jenis = row["jenis"].ToString(),
                        Stok = Convert.ToInt32(row["stok"]),
                        Harga = Convert.ToDecimal(row["harga"])
                    });
                }

                return bestSellerList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal mengambil best seller: {ex.Message}");
            }
        }

        public void Perbarui(Produk entitas)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string queryProduk = "UPDATE public.produk SET nama = @nama, jenis = @jenis, stok = @stok WHERE id_produk = @id";
                            var parametersProduk = new[]
                            {
                                new NpgsqlParameter("@nama", entitas.Nama ?? (object)DBNull.Value),
                                new NpgsqlParameter("@jenis", entitas.Jenis ?? (object)DBNull.Value),
                                new NpgsqlParameter("@stok", entitas.Stok),
                                new NpgsqlParameter("@id", entitas.Id_produk)
                            };
                            dbConnection.ExecuteNonQuery(queryProduk, parametersProduk);

                            string queryKatalog = "UPDATE public.katalog_produk SET harga = @harga WHERE id_produk = @id";
                            var parametersKatalog = new[]
                            {
                                new NpgsqlParameter("@harga", entitas.Harga),
                                new NpgsqlParameter("@id", entitas.Id_produk)
                            };
                            dbConnection.ExecuteNonQuery(queryKatalog, parametersKatalog);

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Gagal memperbarui produk: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saat memperbarui: {ex.Message}");
            }
        }

        public void Hapus(string id)
        {
            string query = "DELETE FROM public.produk WHERE id_produk = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id) };
            dbConnection.ExecuteNonQuery(query, parameters);
        }

        public List<Produk> CariProduk(string keyword)
        {
            var produkList = new List<Produk>();
            string query = @"
                SELECT p.id_produk, p.nama, p.jenis, kp.harga
                FROM public.produk p
                JOIN public.katalog_produk kp ON p.id_produk = kp.id_produk
                WHERE LOWER(p.nama) LIKE LOWER(@keyword) OR LOWER(p.jenis) LIKE LOWER(@keyword)";

            var parameters = new[]
            {
                new NpgsqlParameter("@keyword", "%" + keyword + "%")
            };

            var result = dbConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                produkList.Add(new Produk
                {
                    Id_produk = Convert.ToInt32(row["id_produk"]),
                    Nama = row["nama"].ToString(),
                    Jenis = row["jenis"].ToString(),
                    Harga = Convert.ToDecimal(row["harga"])
                });
            }

            return produkList;
        }

        public void TambahProduk(Produk entitas)
        {
            try
            {
                string query = "INSERT INTO public.produk (nama, jenis, stok) VALUES (@nama, @jenis, @stok); " +
                               "INSERT INTO public.katalog_produk (id_produk, harga) VALUES (CURRVAL('produk_id_produk_seq'), @harga)";
                var parameters = new[]
                {
                    new NpgsqlParameter("@nama", entitas.Nama ?? (object)DBNull.Value),
                    new NpgsqlParameter("@jenis", entitas.Jenis ?? (object)DBNull.Value),
                    new NpgsqlParameter("@stok", entitas.Stok),
                    new NpgsqlParameter("@harga", entitas.Harga)
                };
                int rowsAffected = dbConnection.ExecuteNonQuery(query, parameters);
                if (rowsAffected == 0)
                {
                    throw new Exception("Gagal menambahkan produk ke database.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menambahkan produk: {ex.Message}");
            }
        }


        public void TambahKeKeranjang(int id_produk, int jumlah, int id_user)
        {
            var produk = AmbilBerdasarkanId(id_produk.ToString());
            if (produk != null && produk.Stok >= jumlah)
            {
                var konteksTransaksi = new KonteksTransaksi();
                konteksTransaksi.TambahPesananSementara(id_produk, jumlah, id_user);
            }
            else
            {
                throw new Exception("Stok tidak cukup atau produk tidak ditemukan!");
            }
        }

        private decimal AmbilHargaProduk(int id_produk)
        {
            string query = "SELECT harga FROM public.katalog_produk WHERE id_produk = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id_produk) };
            var result = dbConnection.ExecuteQuery(query, parameters);
            return result.Rows.Count > 0 ? Convert.ToDecimal(result.Rows[0]["harga"]) : 0;
        }
    }
}