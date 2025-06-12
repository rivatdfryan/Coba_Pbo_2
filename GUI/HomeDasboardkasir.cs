using Kinar_Bakery.Controller;
using Kinar_Bakery.GUI;
using Kinar_Bakery.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using Npgsql;

namespace Kinar_Bakery
{
    public partial class HomeDasboardkasir : Form
    {
        private readonly int _id_user;
        private readonly KontrolerPengguna _kontrolerPengguna;
        private readonly KontrolerTransaksi _kontrolerTransaksi;
        private readonly DatabaseConnection _dbConnection;
        private readonly KontrolerPengguna _kontroler;


        public HomeDasboardkasir(int id_user)
        {
            InitializeComponent();
            _id_user = id_user;
            _kontrolerPengguna = new KontrolerPengguna();
            _kontrolerTransaksi = new KontrolerTransaksi();
            _dbConnection = new DatabaseConnection();

            LoadDataAwal();
        }

        private void LoadDataAwal()
        {
            try
            {
                var pengguna = _kontrolerPengguna.AmbilPengguna(_id_user);
                if (pengguna == null || pengguna.Role?.ToLower() != "karyawan")
                {
                    MessageBox.Show("Akses ditolak. Anda bukan kasir!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblSelamatDatangnamaKasir.Text = $"Selamat datang, {pengguna.Nama}!";
                textBox1.Text = DateTime.Today.ToString("yyyy-MM-dd"); // format default
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data awal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private (int totalProduk, decimal totalPendapatan) AmbilTotalPenjualanKasir(int id_user, DateTime tanggal)
        {
            string query = @"
                SELECT COALESCE(SUM(tp.jumlah), 0) AS total_produk,
                       COALESCE(SUM(tp.total), 0) AS total_pendapatan
                FROM public.transaksi_penjualan tp
                JOIN public.karyawan k ON tp.id_karyawan = k.id_karyawan
                WHERE k.id_user = @id_user AND tp.tanggal_transaksi::date = @tanggal";

            var parameters = new[]
            {
                new NpgsqlParameter("@id_user", id_user),
                new NpgsqlParameter("@tanggal", tanggal)
            };

            var result = _dbConnection.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                int totalProduk = Convert.ToInt32(result.Rows[0]["total_produk"]);
                decimal totalPendapatan = Convert.ToDecimal(result.Rows[0]["total_pendapatan"]);
                return (totalProduk, totalPendapatan);
            }

            return (0, 0);
        }


        private void btnKonfirmasiPedanan_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Konfirmasi Pesanan...");
                new KonfirmasiPesanan(_id_user).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka Konfirmasi Pesanan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLihatLaporan_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(textBox1.Text, out DateTime tanggal))
            {
                MessageBox.Show("Format tanggal tidak valid. Gunakan format yyyy-MM-dd", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var keranjang = AmbilTransaksiHariIni(_id_user, tanggal);
                int totalProduk = keranjang.Sum(x => x.Jumlah);
                decimal totalPendapatan = keranjang.Sum(x => x.Total_harga ?? 0);

                lblTotalPenjualanProduk.Text = $"{totalProduk} produk";
                lblTotalPendapatanBakery.Text = $"Rp {totalPendapatan:N0}";
                lblStatusPresensi.Text = AmbilStatusPresensi(_id_user, tanggal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengambil data laporan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ItemKeranjang> AmbilTransaksiHariIni(int id_user, DateTime tanggal)
        {
            var hasil = new List<ItemKeranjang>();

            string query = @"
                SELECT tp.id_produk, p.nama AS nama_produk, tp.jumlah, kp.harga * tp.jumlah AS total_harga, p.stok
                FROM public.transaksi_penjualan tp
                JOIN public.produk p ON tp.id_produk = p.id_produk
                JOIN public.katalog_produk kp ON p.id_produk = kp.id_produk
                WHERE tp.id_pelanggan = @id_user AND tp.tanggal_transaksi::date = @tanggal";

            var parameters = new[]
            {
                new NpgsqlParameter("@id_user", id_user),
                new NpgsqlParameter("@tanggal", tanggal)
            };

            var result = _dbConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                hasil.Add(new ItemKeranjang
                {
                    Id_produk = Convert.ToInt32(row["id_produk"]),
                    Nama_produk = row["nama_produk"].ToString(),
                    Jumlah = Convert.ToInt32(row["jumlah"]),
                    Total_harga = row["total_harga"] != DBNull.Value ? Convert.ToDecimal(row["total_harga"]) : 0,
                    Status = Convert.ToInt32(row["stok"]) > 0 ? "Tersedia" : "Habis"
                });
            }

            return hasil;
        }

        private string AmbilStatusPresensi(int id_user, DateTime tanggal)
        {
            try
            {
                string query = @"
            SELECT ps.status 
            FROM public.presensi ps
            JOIN public.karyawan k ON ps.id_karyawan = k.id_karyawan
            WHERE k.id_user = @id_user AND ps.tanggal::date = @tanggal";

                var parameters = new[]
                {
            new NpgsqlParameter("@id_user", id_user),
            new NpgsqlParameter("@tanggal", tanggal)
        };

                var result = new DatabaseConnection().ExecuteQuery(query, parameters);
                return result.Rows.Count > 0 ? result.Rows[0]["status"].ToString() : "Tidak Hadir";
            }
            catch
            {
                return "Data tidak tersedia";
            }
        }


        // Placeholder jika diperlukan untuk event lainnya
        private void lblSelamatDatangnamaKasir_Click(object sender, EventArgs e) { }
        private void lblTotalPenjualanProduk_Click(object sender, EventArgs e) { }
        private void lblTotalPendapatanBakery_Click(object sender, EventArgs e) { }
        private void lblStatusPresensi_Click(object sender, EventArgs e) { }

        private void lblTotalPenjualanProduk_Click_1(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(lblPilihTanggalHariIni.Text, out DateTime tanggal))
            {
                MessageBox.Show("Format tanggal tidak valid. Gunakan format yyyy-MM-dd", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var keranjang = AmbilTransaksiHariIni(_id_user, tanggal);
                int totalProduk = keranjang.Sum(x => x.Jumlah);
                lblTotalPenjualanProduk.Text = $"{totalProduk} produk";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengambil total produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTotalPendapatanBakery_Click_1(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(lblPilihTanggalHariIni.Text, out DateTime tanggal))
            {
                MessageBox.Show("Format tanggal tidak valid. Gunakan format yyyy-MM-dd", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var keranjang = AmbilTransaksiHariIni(_id_user, tanggal);
                decimal totalPendapatan = keranjang.Sum(x => x.Total_harga ?? 0);
                lblTotalPendapatanBakery.Text = $"Rp {totalPendapatan:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengambil pendapatan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblStatusPresensi_Click_1(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(lblPilihTanggalHariIni.Text, out DateTime tanggal))
            {
                MessageBox.Show("Format tanggal tidak valid. Gunakan format yyyy-MM-dd", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string status = AmbilStatusPresensi(_id_user, tanggal);
                lblStatusPresensi.Text = status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengambil status presensi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTanggal_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(textBox1.Text, out DateTime tanggal))
            {
                lblTotalPenjualanProduk.Text = "-";
                lblTotalPendapatanBakery.Text = "-";
                lblStatusPresensi.Text = "Format tanggal salah (gunakan yyyy-MM-dd)";
                return;
            }

            try
            {
                // Ambil data dari tabel transaksi_penjualan
                var (totalProduk, totalPendapatan) = AmbilTotalPenjualanKasir(_id_user, tanggal);
                lblTotalPenjualanProduk.Text = $"{totalProduk} produk";
                lblTotalPendapatanBakery.Text = $"Rp {totalPendapatan:N0}";

                // Ambil data presensi
                lblStatusPresensi.Text = AmbilStatusPresensi(_id_user, tanggal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat laporan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnKatalog_Click(object sender, EventArgs e)
        {

        }

        private void btnAbsen_Click(object sender, EventArgs e)
        {
            try
            {
                // Membuka form presensi dan kirim id_user
                var presensiForm = new Presensi(_id_user);
                presensiForm.ShowDialog(); // Modal dialog
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka form presensi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Membuka Keranjang...");
                new JagaKasir(_id_user).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka keranjang: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
