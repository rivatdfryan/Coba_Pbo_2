using Npgsql;
using System;
using System.Data;

namespace Kinar_Bakery.Model
{
    public class KontrolerPresensi
    {
        private readonly DatabaseConnection dbConnection;

        public KontrolerPresensi()
        {
            dbConnection = new DatabaseConnection();
        }

        public DataTable GetPresensiData(DateTime tanggalAwal, DateTime tanggalAkhir)
        {
            try
            {
                string query = "SELECT * FROM public.presensi WHERE tanggal BETWEEN @awal AND @akhir";
                var parameters = new[]
                {
                    new NpgsqlParameter("@awal", tanggalAwal),
                    new NpgsqlParameter("@akhir", tanggalAkhir)
                };
                return dbConnection.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal memuat data presensi: {ex.Message}");
            }
        }

        public double CalculateTotalDuration(int idKaryawan, DateTime tanggalAwal, DateTime tanggalAkhir)
        {
            try
            {
                string query = "SELECT jam_masuk, jam_keluar FROM public.presensi WHERE id_karyawan = @id AND tanggal BETWEEN @awal AND @akhir";
                var parameters = new[]
                {
                    new NpgsqlParameter("@id", idKaryawan),
                    new NpgsqlParameter("@awal", tanggalAwal),
                    new NpgsqlParameter("@akhir", tanggalAkhir)
                };
                var result = dbConnection.ExecuteQuery(query, parameters);
                double totalDurasi = 0;
                foreach (DataRow row in result.Rows)
                {
                    TimeSpan masuk = (TimeSpan)row["jam_masuk"];
                    TimeSpan keluar = (TimeSpan)row["jam_keluar"];
                    totalDurasi += (keluar - masuk).TotalHours;
                }
                return totalDurasi;
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menghitung durasi: {ex.Message}");
            }
        }
    }
}