using Kinar_Bakery.Controller;
using Kinar_Bakery.Model;
using System;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI.Owner
{
    public partial class EditProduk : Form
    {
        private readonly Produk _produk;
        private readonly KonteksProduk _konteksProduk;

        public EditProduk(Produk produk)
        {
            InitializeComponent();
            _produk = produk ?? new Produk();
            _konteksProduk = new KonteksProduk();
            LoadData();
        }

        private void LoadData()
        {
            txtNama.Text = _produk.Nama;
            txtJenis.Text = _produk.Jenis;
            txtStok.Text = _produk.Stok.ToString();
            txtHarga.Text = _produk.Harga.ToString("F2");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                _produk.Nama = txtNama.Text;
                _produk.Jenis = txtJenis.Text;
                _produk.Stok = int.Parse(txtStok.Text);
                _produk.Harga = decimal.Parse(txtHarga.Text);
                try
                {
                    _konteksProduk.Perbarui(_produk);
                    MessageBox.Show("Produk berhasil diperbarui", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal memperbarui produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new KelolaProduk().ShowDialog();
            this.Show();
        }
    }
}