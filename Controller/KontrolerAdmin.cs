
using Kinar_Bakery.Model;
using Npgsql;
using System;
using System.Data;

namespace Kinar_Bakery.Controller
{
    public class KontrolerAdmin
    {
        private readonly DatabaseConnection _dbConnection = new DatabaseConnection();

        public long AmbilTotalJenisProduk() 
        {
            try
            {
                string query = "SELECT COUNT(nama) FROM public.produk";
                var result = _dbConnection.ExecuteQuery(query, new NpgsqlParameter[] { });
                return result.Rows[0].Field<long>(0); 
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal mengambil total jenis produk: {ex.Message}");
            }
        }

        public decimal AmbilTotalSaldo()
        {
            try
            {
                string query = @"
                    SELECT 
                        COALESCE((SELECT SUM(total) FROM public.transaksi_penjualan), 0) - 
                        COALESCE((SELECT SUM(total_biaya) FROM public.transaksi_pembelian), 0) + 
                        COALESCE((SELECT SUM(pendapatan) FROM public.outlets), 0) - 
                        COALESCE((SELECT SUM(pengeluaran) FROM public.outlets), 0)";
                var result = _dbConnection.ExecuteQuery(query, new NpgsqlParameter[] { });
                return result.Rows[0].Field<decimal>(0);
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal mengambil total saldo: {ex.Message}");
            }
        }

        public long AmbilTotalKaryawan() 
        {
            try
            {
                string query = "SELECT COUNT(*) FROM public.users WHERE role = 'karyawan'";
                var result = _dbConnection.ExecuteQuery(query, new NpgsqlParameter[] { });
                return result.Rows[0].Field<long>(0); 
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal mengambil total karyawan: {ex.Message}");
            }
        }
    }
}