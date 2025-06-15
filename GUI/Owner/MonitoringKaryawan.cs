using Kinar_Bakery.Controller;
using Kinar_Bakery.GUI.Owner;
using Kinar_Bakery.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI
{
    public partial class MonitoringKaryawan : Form
    {
        private int id_user;
        private DataTable presensiData;
        private KontrolerPresensi kontrolerpresensi;
        private KonteksPengguna konteksPengguna;

        public MonitoringKaryawan(int userId)
        {
            InitializeComponent();
            id_user = userId;
            kontrolerpresensi = new KontrolerPresensi();
            konteksPengguna = new KonteksPengguna();
            dateTimePickerAwal.Value = new DateTime(2025, 6, 14, 0, 33, 0);
            dateTimePickerAkhir.Value = new DateTime(2025, 6, 14, 0, 33, 0);
            LoadPresensiData();
        }

        private void LoadPresensiData()
        {
            try
            {
                DateTime tanggalAwal = dateTimePickerAwal.Value.Date;
                DateTime tanggalAkhir = dateTimePickerAkhir.Value.Date;
                presensiData = kontrolerpresensi.GetPresensiData(tanggalAwal, tanggalAkhir);
                dataGridViewKaryawan.DataSource = presensiData;
                if (dataGridViewKaryawan.Columns["id_karyawan"] != null)
                    dataGridViewKaryawan.Columns["id_karyawan"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data presensi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePickerAwal_ValueChanged(object sender, EventArgs e)
        {
            LoadPresensiData();
        }

        private void dateTimePickerAkhir_ValueChanged(object sender, EventArgs e)
        {
            LoadPresensiData();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            if (presensiData != null)
            {
                string filter = txtCari.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(filter))
                {
                    dataGridViewKaryawan.DataSource = presensiData;
                }
                else
                {
                    var filteredData = presensiData.AsEnumerable()
                        .Where(row => row.Field<string>("status").ToLower().Contains(filter) ||
                                      row.Field<int>("id_karyawan").ToString().Contains(filter))
                        .CopyToDataTable();
                    dataGridViewKaryawan.DataSource = filteredData;
                }
            }
        }

        private void dataGridViewKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewKaryawan.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnHitungGaji_Click(object sender, EventArgs e)
        {
            if (dataGridViewKaryawan.SelectedRows.Count > 0)
            {
                int idKaryawan = Convert.ToInt32(dataGridViewKaryawan.SelectedRows[0].Cells["id_karyawan"].Value);
                Pengguna pengguna = konteksPengguna.AmbilBerdasarkanId(idKaryawan);
                string namaKaryawan = pengguna?.Nama ?? "Nama Tidak Ditemukan";
                DateTime tanggalAwal = dateTimePickerAwal.Value.Date;
                DateTime tanggalAkhir = dateTimePickerAkhir.Value.Date;

                this.Hide();
                var gajiForm = new Gaji(idKaryawan, namaKaryawan, tanggalAwal, tanggalAkhir);
                gajiForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Pilih karyawan terlebih dahulu dari daftar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new LaporanDashboardAdmin().ShowDialog();
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
    }
}