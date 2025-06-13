using Kinar_Bakery.Controller;
using Kinar_Bakery.Controller;
using Kinar_Bakery.GUI.Pelanggan;
using System;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI
{
    public partial class Katalog : Form
    {
        private readonly int _id_user;
        private readonly KontrolerProduk _kontroler;

        public Katalog(int id_user)
        {
            try
            {
                InitializeComponent();
                _id_user = id_user;
                _kontroler = new KontrolerProduk();
                LoadData();
                dataGridViewKatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewKatalog.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menginisialisasi katalog: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                var katalogList = _kontroler.AmbilSemuaProduk();
                dataGridViewKatalog.DataSource = katalogList;
                dataGridViewKatalog.Columns["Id_produk"].HeaderText = "ID Produk";
                dataGridViewKatalog.Columns["Nama"].HeaderText = "Nama Produk";
                dataGridViewKatalog.Columns["Jenis"].HeaderText = "Jenis Produk";
                dataGridViewKatalog.Columns["Stok"].HeaderText = "Stok";
                dataGridViewKatalog.Columns["Harga"].HeaderText = "Harga";
                dataGridViewKatalog.ReadOnly = true;
                if (dataGridViewKatalog.Columns.Count > 5)
                    dataGridViewKatalog.Columns.RemoveAt(dataGridViewKatalog.Columns.Count - 1);
                comboBoxUrut.Items.AddRange(new[] { "Harga Tertinggi", "Harga Terendah", "Urutkan A-Z" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data katalog: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var opsiUrut = comboBoxUrut.SelectedItem?.ToString();
                dataGridViewKatalog.DataSource = _kontroler.AmbilSemuaProduk(opsiUrut);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengurutkan data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewKatalog.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih produk dari daftar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dataGridViewKatalog.SelectedRows[0];
                var id_produk = Convert.ToInt32(row.Cells["Id_produk"].Value);

                int jumlah;
                if (string.IsNullOrEmpty(txtJumlah.Text) || !int.TryParse(txtJumlah.Text, out jumlah) || jumlah <= 0)
                {
                    MessageBox.Show("Masukkan jumlah yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var produk = _kontroler.AmbilBerdasarkanId(id_produk.ToString());
                if (produk == null)
                {
                    MessageBox.Show("Produk tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (produk.Stok < jumlah)
                {
                    MessageBox.Show($"Stok hanya tersedia {produk.Stok} unit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _kontroler.TambahKeKeranjang(id_produk, jumlah, _id_user);
                MessageBox.Show($"Produk '{produk.Nama}' ditambahkan ke keranjang! (Jumlah: {jumlah})", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJumlah.Text = "";
                LoadData();

                if (MessageBox.Show("Ingin melihat keranjang sekarang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Hide();
                    var keranjang = new Keranjang(_id_user);
                    keranjang.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menambahkan ke keranjang: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtJumlah.Text) && !int.TryParse(txtJumlah.Text, out _))
            {
                MessageBox.Show("Hanya masukkan angka untuk jumlah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJumlah.Text = "";
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

        private void btnKatalog_Click(object sender, EventArgs e)
        {

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new Keranjang(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eror Saat Membuka Menu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.Trim();
            var hasil = _kontroler.CariProduk(keyword);
            dataGridViewKatalog.DataSource = hasil;
        }
    }
}

