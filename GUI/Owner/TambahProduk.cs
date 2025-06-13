using Kinar_Bakery.GUI.Pelanggan;
using Kinar_Bakery.Model;
using System;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI.Owner
{
    public partial class TambahProduk : Form
    {
        private readonly KonteksProduk _konteksProduk;
        private int id_user;

        public TambahProduk()
        {
            InitializeComponent();
            _konteksProduk = new KonteksProduk();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var produkBaru = new Produk
                {
                    Nama = txtNama.Text,
                    Jenis = txtJenis.Text,
                    Stok = int.Parse(txtStok.Text),
                    Harga = decimal.Parse(txtHarga.Text)
                };
                try
                {
                    _konteksProduk.TambahProduk(produkBaru);
                    MessageBox.Show("Produk berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menambahkan produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtJenis.Text) ||
                !int.TryParse(txtStok.Text, out _) || !decimal.TryParse(txtHarga.Text, out _))
            {
                MessageBox.Show("Semua field harus diisi dengan benar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void txtHarga_TextChanged(object sender, EventArgs e) { }
        private void txtStok_TextChanged(object sender, EventArgs e) { }
        private void txtJenis_TextChanged(object sender, EventArgs e) { }
        private void txtNama_TextChanged(object sender, EventArgs e) { }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new KelolaProduk().ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new HomeDasboardAdmin(id_user).ShowDialog();
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