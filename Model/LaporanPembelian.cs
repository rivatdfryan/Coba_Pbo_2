using Kinar_Bakery.Controller;
using Npgsql;
using System;
using System.Data;

namespace Kinar_Bakery.Model
{
    public class LaporanPembelian : ILaporan
    {
        private readonly DatabaseConnection _dbConnection;

        public LaporanPembelian()
        {
            _dbConnection = new DatabaseConnection();
        }

        public DataTable AmbilData(DateTime tanggalAwal, DateTime tanggalAkhir)
        {
            string query = "SELECT id_pembelian, id_bahan AS nama_bahan, total_biaya, tanggal_pembelian " +
                           "FROM public.transaksi_pembelian WHERE tanggal_pembelian BETWEEN @awal AND @akhir";
            var parameters = new[]
            {
                new NpgsqlParameter("@awal", tanggalAwal),
                new NpgsqlParameter("@akhir", tanggalAkhir)
            };
            return _dbConnection.ExecuteQuery(query, parameters);
        }
    }
}