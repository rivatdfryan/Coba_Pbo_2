// KontrolerLaporan.cs (di folder Controller)
using Kinar_Bakery.Model;
using Npgsql;
using System;
using System.Data;

namespace Kinar_Bakery.Controller
{
    public class KontrolerLaporan
    {
        private readonly DatabaseConnection _dbConnection = new DatabaseConnection();

        public DataTable AmbilLaporan(string jenisLaporan, DateTime tanggalAwal, DateTime tanggalAkhir)
        {
            ILaporan laporan = null;
            switch (jenisLaporan.ToLower())
            {
                case "pembelian":
                    laporan = new LaporanPembelian();
                    break;
                case "penjualan":
                    laporan = new LaporanPenjualan();
                    break;
                default:
                    throw new ArgumentException("Jenis laporan tidak valid.");
            }
            return laporan.AmbilData(tanggalAwal, tanggalAkhir);
        }
    }

    // Implementasi konkret untuk Laporan Pembelian
    internal class LaporanPembelian : ILaporan
    {
        public DataTable AmbilData(DateTime tanggalAwal, DateTime tanggalAkhir)
        {
            string query = @"
                SELECT 
                    tp.id_pembelian,
                    b.nama,
                    tp.total_biaya,
                    tp.tanggal_pembelian
                FROM public.transaksi_pembelian tp
                JOIN public.bahan_baku b ON tp.id_bahan = b.id_bahan
                WHERE tp.tanggal_pembelian BETWEEN @tanggalAwal AND @tanggalAkhir";
            var parameters = new[]
            {
                new NpgsqlParameter("@tanggalAwal", tanggalAwal),
                new NpgsqlParameter("@tanggalAkhir", tanggalAkhir)
            };
            return new DatabaseConnection().ExecuteQuery(query, parameters);
        }
    }

    // Implementasi konkret untuk Laporan Penjualan
    internal class LaporanPenjualan : ILaporan
    {
        public DataTable AmbilData(DateTime tanggalAwal, DateTime tanggalAkhir)
        {
            string query = @"
                SELECT 
                    tp.id_transaksi AS id_penjualan,
                    p.nama AS nama_produk,
                    tp.total,
                    tp.tanggal_transaksi AS tanggal_penjualan
                FROM public.transaksi_penjualan tp
                JOIN public.produk p ON tp.id_produk = p.id_produk
                WHERE tp.tanggal_transaksi BETWEEN @tanggalAwal AND @tanggalAkhir";
            var parameters = new[]
            {
                new NpgsqlParameter("@tanggalAwal", tanggalAwal),
                new NpgsqlParameter("@tanggalAkhir", tanggalAkhir)
            };
            return new DatabaseConnection().ExecuteQuery(query, parameters);
        }
    }
}