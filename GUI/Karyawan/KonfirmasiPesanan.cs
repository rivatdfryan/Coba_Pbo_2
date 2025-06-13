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
            dataGridViewPesanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPesanan.MultiSelect = false;
            LoadPesananSementara();
        }

        private void LoadPesananSementara()
        {
            try
            {
                string query = "SELECT ps.id_pesanan_sementara, p.nama, ps.jumlah, ps.total_harga, ps.id_user, ps.id_produk " +
                               "FROM public.pesanan_sementara ps " +
                               "JOIN public.produk p ON ps.id_produk = p.id_produk";
                var result = new DatabaseConnection().ExecuteQuery(query);
                dataGridViewPesanan.DataSource = result;
                dataGridViewPesanan.Columns["id_pesanan_sementara"].HeaderText = "ID Pesanan";
                dataGridViewPesanan.Columns["nama"].HeaderText = "Nama Produk";
                dataGridViewPesanan.Columns["jumlah"].HeaderText = "Jumlah";
                dataGridViewPesanan.Columns["total_harga"].HeaderText = "Total Harga";
                dataGridViewPesanan.Columns["id_user"].Visible = false;
                dataGridViewPesanan.Columns["id_produk"].Visible = false;
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
                // Pastikan ada baris yang dipilih
                if (dataGridViewPesanan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Silakan pilih pesanan yang ingin dikonfirmasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPesananSementara = Convert.ToInt32(dataGridViewPesanan.SelectedRows[0].Cells["id_pesanan_sementara"].Value);
                _konteksTransaksi.KonfirmasiPesanan(idPesananSementara);
                MessageBox.Show("Pesanan berhasil dikonfirmasi", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPesananSementara();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengonfirmasi pesanan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "Apakah Anda yakin untuk logout?",
            "Konfirmasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    this.Hide();
                    new Login().ShowDialog();
                    this.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
            else
            {

            }
        }

        private void btnKatalog_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new HomeDasboardkasir(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnAbsen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new Presensi(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new JagaKasir(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }
    }
}