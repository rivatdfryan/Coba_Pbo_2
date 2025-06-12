using Kinar_Bakery.Controller;
using Kinar_Bakery.Model;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI
{
    public partial class KonfirmasiPesanan : Form
    {
        private readonly KonteksTransaksi _konteksTransaksi;
        private int _id_user;

        public KonfirmasiPesanan(int id_user)
        {
            InitializeComponent();
            _konteksTransaksi = new KonteksTransaksi();
            _id_user = id_user;
            LoadPesananSementara();
        }

        private void LoadPesananSementara()
        {
            try
            {
                string query = "SELECT ps.id_pesanan_sementara, p.nama, ps.jumlah, ps.total_harga " +
                               "FROM public.pesanan_sementara ps " +
                               "JOIN public.produk p ON ps.id_produk = p.id_produk " +
                               "WHERE ps.id_user = @id_user";
                var parameters = new[] { new NpgsqlParameter("@id_user", _id_user) };
                var result = new DatabaseConnection().ExecuteQuery(query, parameters);
                dataGridViewPesanan.DataSource = result;
                dataGridViewPesanan.Columns["id_pesanan_sementara"].HeaderText = "ID Pesanan";
                dataGridViewPesanan.Columns["nama"].HeaderText = "Nama Produk";
                dataGridViewPesanan.Columns["jumlah"].HeaderText = "Jumlah";
                dataGridViewPesanan.Columns["total_harga"].HeaderText = "Total Harga";
                dataGridViewPesanan.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat pesanan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            try
            {
                _konteksTransaksi.KonfirmasiPesanan(_id_user);
                MessageBox.Show("Pesanan berhasil dikonfirmasi dan dipindahkan ke transaksi penjualan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPesananSementara(); // Perbarui tampilan
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengonfirmasi pesanan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}