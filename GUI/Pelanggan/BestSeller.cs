
using Kinar_Bakery.Controller;
using Kinar_Bakery.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI.Pelanggan
{
    public partial class BestSeller : Form
    {
        private readonly int _id_user;
        private readonly KonteksProduk _kontroler;

        public BestSeller(int id_user)
        {
            try
            {
                InitializeComponent();
                _id_user = id_user;
                _kontroler = new KonteksProduk();
                LoadData();
                dataGridViewBestSeller.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewBestSeller.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menginisialisasi best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                var bestSellerList = _kontroler.AmbilBestSeller();
                dataGridViewBestSeller.DataSource = bestSellerList;
                dataGridViewBestSeller.Columns["Id_produk"].HeaderText = "ID Produk";
                dataGridViewBestSeller.Columns["Nama"].HeaderText = "Nama Produk";
                dataGridViewBestSeller.Columns["Jenis"].HeaderText = "Jenis Produk";
                dataGridViewBestSeller.Columns["Stok"].HeaderText = "Stok";
                dataGridViewBestSeller.Columns["Harga"].HeaderText = "Harga";
                dataGridViewBestSeller.ReadOnly = true;
                if (dataGridViewBestSeller.Columns.Count > 5)
                    dataGridViewBestSeller.Columns.RemoveAt(dataGridViewBestSeller.Columns.Count - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBestSeller.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih produk dari daftar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dataGridViewBestSeller.SelectedRows[0];
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

        private void btnHomePelanggan_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new HomeDashboardPelanggan(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnKatalog_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new Katalog(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new Keranjang (_id_user).ShowDialog();
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
