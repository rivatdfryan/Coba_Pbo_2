using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kinar_Bakery.GUI;
using Kinar_Bakery.Controller;
using Kinar_Bakery.Model;

namespace Kinar_Bakery.GUI
{
    public partial class JagaKasir : Form
    {
        private readonly int _id_user;
        private readonly KontrolerProduk _kontrolerProduk;
        private readonly KontrolerTransaksi _kontrolerTransaksi;
        private readonly DatabaseConnection _dbConnection;

        private Produk _produkDipilih;
        private List<ItemKeranjang> _keranjang;
        public JagaKasir(int id_user)
        {
            InitializeComponent();
            _id_user = id_user;

            _kontrolerProduk = new KontrolerProduk();
            _kontrolerTransaksi = new KontrolerTransaksi();
            _dbConnection = new DatabaseConnection();

            _keranjang = new List<ItemKeranjang>();

            // Hubungkan event CellClick
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void txtCariProduk_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCariProduk.Text.Trim();
            var hasil = _kontrolerProduk.CariProduk(keyword);
            dataGridView1.DataSource = hasil;

            // Optional: Auto resize columns
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                try
                {
                    _produkDipilih = new Produk
                    {
                        Id_produk = Convert.ToInt32(row.Cells["id_produk"].Value),
                        Nama = row.Cells["nama"].Value.ToString(),
                        Jenis = row.Cells["jenis"].Value.ToString(),
                        Harga = Convert.ToDecimal(row.Cells["harga"].Value)
                    };

                    MessageBox.Show($"Produk dipilih: {_produkDipilih.Nama}, Harga: {_produkDipilih.Harga}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal membaca produk: {ex.Message}");
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (_produkDipilih == null)
            {
                MessageBox.Show("Silakan pilih produk terlebih dahulu.");
                return;
            }

            int jumlah = 1;
            decimal total = _produkDipilih.Harga * jumlah;

            var item = new ItemKeranjang
            {
                Id_produk = _produkDipilih.Id_produk,
                Nama_produk = _produkDipilih.Nama,
                Jumlah = jumlah,
                Total_harga = total
            };

            _keranjang.Add(item);

            lblNama.Text = item.Nama_produk;
            lblHarga.Text = $"Rp {item.Total_harga:N0}";
            lblTotal.Text = $"Rp {_keranjang.Sum(i => i.Total_harga):N0}";
        }

        private void lblNama_Click(object sender, EventArgs e)
        {

        }

        private void lblJumlah_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pesanan dikonfirmasi.");
        }

        private void lblHarga_Click(object sender, EventArgs e)
        {

        }
    }
}
