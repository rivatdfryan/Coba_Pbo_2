using Kinar_Bakery.Controller;
using Npgsql;
using System;
using System.Data;

namespace Kinar_Bakery.Model
{
    public class LaporanPenjualan : ILaporan
    {
        private readonly DatabaseConnection _dbConnection;

        public LaporanPenjualan()
        {
            _dbConnection = new DatabaseConnection();
        }

        public DataTable AmbilData(DateTime tanggalAwal, DateTime tanggalAkhir)
        {
            string query = "SELECT id_penjualan, nama_produk, total, tanggal_penjualan " +
                           "FROM public.penjualan WHERE tanggal_penjualan BETWEEN @awal AND @akhir";
            var parameters = new[]
            {
                new NpgsqlParameter("@awal", tanggalAwal),
                new NpgsqlParameter("@akhir", tanggalAkhir)
            };
            return _dbConnection.ExecuteQuery(query, parameters);
        }
    }
}