using System;
using System.Windows.Forms;
using Kinar_Bakery.Controller; // Pastikan namespace ini ada

namespace Kinar_Bakery.GUI.Owner
{
    public partial class LaporanDashboardAdmin : Form
    {
        private readonly KontrolerLaporan _kontrolerLaporan;
        private DateTime? _tanggalAwal;
        private DateTime? _tanggalAkhir;
        private int id_user;

        public LaporanDashboardAdmin()
        {
            InitializeComponent();
            _kontrolerLaporan = new KontrolerLaporan();

            DateTime defaultDate = new DateTime(2025, 5, 28);
            dateTimePickerAwal.Value = defaultDate;
            dateTimePicker1Akhir.Value = defaultDate.AddDays(7);
            _tanggalAwal = defaultDate;
            _tanggalAkhir = defaultDate.AddDays(7);

            cmbxJenisLaporan.Items.AddRange(new[] { "Pembelian", "Penjualan" });
            cmbxJenisLaporan.SelectedIndex = 0;
            dataGridViewLaporan.AutoGenerateColumns = true;
        }

        private void LaporanDashboardAdmin_Load(object sender, EventArgs e)
        {
            TampilkanLaporan();
        }

        private void dataGridViewLaporan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbxJenisLaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            TampilkanLaporan();
        }

        private void dateTimePickerAwal_ValueChanged(object sender, EventArgs e)
        {
            _tanggalAwal = dateTimePickerAwal.Value.Date;
            TampilkanLaporan();
        }

        private void dateTimePicker1Akhir_ValueChanged(object sender, EventArgs e)
        {
            _tanggalAkhir = dateTimePicker1Akhir.Value.Date;
            TampilkanLaporan();
        }

        private void TampilkanLaporan()
        {
            try
            {
                string jenisLaporan = cmbxJenisLaporan.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(jenisLaporan) || _tanggalAwal == null || _tanggalAkhir == null)
                {
                    dataGridViewLaporan.DataSource = null;
                    return;
                }

                var data = _kontrolerLaporan.AmbilLaporan(jenisLaporan, _tanggalAwal.Value, _tanggalAkhir.Value);
                if (data.Rows.Count == 0)
                {
                    dataGridViewLaporan.DataSource = null;
                }
                else
                {
                    dataGridViewLaporan.DataSource = data;

                    if (dataGridViewLaporan.Columns.Count > 0)
                    {
                        dataGridViewLaporan.Columns[0].HeaderText = jenisLaporan.Contains("Pembelian") ? "ID Pembelian" : "ID Penjualan";
                        dataGridViewLaporan.Columns[1].HeaderText = jenisLaporan.Contains("Pembelian") ? "Nama Bahan" : "Nama Produk";
                        dataGridViewLaporan.Columns[2].HeaderText = jenisLaporan.Contains("Pembelian") ? "Total Biaya" : "Total";
                        dataGridViewLaporan.Columns[3].HeaderText = jenisLaporan.Contains("Pembelian") ? "Tanggal Pembelian" : "Tanggal Penjualan";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menampilkan laporan: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

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