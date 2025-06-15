using Kinar_Bakery.Model;
using Npgsql;
using System;
using System.Data;

namespace Kinar_Bakery.Controller
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
                string query = "SELECT p.id_presensi, p.id_karyawan, u.nama, p.tanggal, p.jam_masuk, p.jam_keluar, p.status " +
                               "FROM public.presensi p " +
                               "JOIN public.users u ON p.id_karyawan = u.id_user " +
                               "WHERE p.tanggal BETWEEN @awal AND @akhir";
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
                    TimeSpan? masuk = row["jam_masuk"] != DBNull.Value ? (TimeSpan?)row["jam_masuk"] : null;
                    TimeSpan? keluar = row["jam_keluar"] != DBNull.Value ? (TimeSpan?)row["jam_keluar"] : null;

                    if (masuk.HasValue && keluar.HasValue && keluar.Value > masuk.Value)
                    {
                        totalDurasi += (keluar.Value - masuk.Value).TotalHours;
                    }
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