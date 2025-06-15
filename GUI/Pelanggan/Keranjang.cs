using Kinar_Bakery.Controller;
using Kinar_Bakery.GUI.Pelanggan;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI
{
    public partial class Keranjang : Form
    {
        private readonly int _id_user;
        private readonly KonteksProduk _kontroler;
        private readonly KonteksTransaksi _konteksTransaksi;

        public Keranjang(int id_user)
        {
            InitializeComponent();
            _id_user = id_user;
            _kontroler = new KonteksProduk();
            _konteksTransaksi = new KonteksTransaksi();
            LoadKeranjang();
        }

        private void LoadKeranjang()
        {
            try
            {
                string query = "SELECT ps.id_pesanan_sementara, ps.id_user, ps.id_produk, p.nama, ps.jumlah, ps.total_harga " +
                               "FROM public.pesanan_sementara ps " +
                               "JOIN public.produk p ON ps.id_produk = p.id_produk " +
                               "WHERE ps.id_user = @id_user";
                var parameters = new[] { new NpgsqlParameter("@id_user", _id_user) };
                var result = new DatabaseConnection().ExecuteQuery(query, parameters);
                dataGridViewKeranjang.DataSource = result;

                dataGridViewKeranjang.Columns["id_pesanan_sementara"].HeaderText = "ID Pesanan";
                dataGridViewKeranjang.Columns["id_user"].Visible = false;
                dataGridViewKeranjang.Columns["id_produk"].Visible = false;
                dataGridViewKeranjang.Columns["nama"].HeaderText = "Nama Produk";
                dataGridViewKeranjang.Columns["jumlah"].HeaderText = "Jumlah";
                dataGridViewKeranjang.Columns["total_harga"].HeaderText = "Total Harga";
                dataGridViewKeranjang.ReadOnly = true;

                dataGridViewKeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewKeranjang.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat keranjang: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesan_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Pesanan akan dikonfirmasi oleh kasir. Silakan hubungi kasir.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal checkout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewKeranjang.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewKeranjang.SelectedRows[0];
                    var id_pesanan_sementara = Convert.ToInt32(selectedRow.Cells["id_pesanan_sementara"].Value);
                    _konteksTransaksi.HapusPesananSementara(id_pesanan_sementara);
                    LoadKeranjang();
                }
                else
                {
                    MessageBox.Show("Pilih baris yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menghapus produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBestSeller_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new BestSeller(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eror Saat Membuka Menu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnKatalog_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new Katalog(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eror Saat Membuka Menu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnHomePelanggan_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new HomeDashboardPelanggan(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eror Saat Membuka Menu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
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
    }
}