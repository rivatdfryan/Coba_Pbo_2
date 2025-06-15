using Kinar_Bakery.Controller;
using Kinar_Bakery.GUI.Owner;
using Kinar_Bakery.Model;
using System;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI.Owner
{
    public partial class KelolaProduk : Form
    {
        private readonly KonteksProduk _konteksProduk;
        private Produk _selectedProduk;
        private int id_user;
        public KelolaProduk()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            _konteksProduk = new KonteksProduk();
            LoadDataGrid();
        }

        private void KelolaProduk_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid(string sortOption = null)
        {
            string keyword = txtCari.Text.Trim();
            var produkList = string.IsNullOrEmpty(keyword)
                ? _konteksProduk.AmbilSemua(sortOption)
                : _konteksProduk.CariProduk(keyword);
            dataGridView1.DataSource = null; // Hapus data lama
            dataGridView1.DataSource = produkList; // Set data baru
            dataGridView1.Columns["Id_produk"].Visible = false;
            dataGridView1.Columns["Nama"].HeaderText = "Nama Produk";
            dataGridView1.Columns["Jenis"].HeaderText = "Jenis";
            dataGridView1.Columns["Stok"].HeaderText = "Stok";
            dataGridView1.Columns["Harga"].HeaderText = "Harga";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                _selectedProduk = selectedRow.DataBoundItem as Produk;
                // Debugging (opsional)
                // MessageBox.Show($"Produk dipilih: {_selectedProduk?.Nama ?? "Tidak ada"}");
            }
            else
            {
                _selectedProduk = null;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            var tambahForm = new TambahProduk();
            if (tambahForm.ShowDialog() == DialogResult.OK)
            {
                LoadDataGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedProduk != null)
            {
                var editForm = new EditProduk(_selectedProduk);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Pilih produk terlebih dahulu dari daftar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new KonfirmasiPesanan(id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new KonfirmasiPesanan(id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new KelolaProduk().ShowDialog();
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
                new MonitoringKaryawan(id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Gagal membuka login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
        }
    }
}