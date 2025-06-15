using Kinar_Bakery.Controller;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI
{
    public partial class PresensiKaryawan : Form
    {
        private readonly int _id_user;
        private readonly DatabaseConnection _dbConnection;
        private readonly KonteksPengguna _kontrolerPengguna;
        public PresensiKaryawan(int id_user)
        {
            InitializeComponent();
            _id_user = id_user;
            _dbConnection = new DatabaseConnection();
            _kontrolerPengguna = new KonteksPengguna();

            LoadFormAwal();
        }

        private void LoadFormAwal()
        {
            try
            {
                var pengguna = _kontrolerPengguna.AmbilBerdasarkanId(_id_user);

                if (pengguna != null && !string.IsNullOrWhiteSpace(pengguna.Nama))
                    lblProfilNamaKaryawan.Text = pengguna.Nama;
                else
                    lblProfilNamaKaryawan.Text = "Tidak ditemukan";

                txtTanggalhariIni.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data pengguna: " + ex.Message);
            }
        }

        private void txtTanggalhariIni_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProfilNamaKaryawan_Click(object sender, EventArgs e)
        {
            try
            {
                var pengguna = _kontrolerPengguna.AmbilBerdasarkanId(_id_user);
                lblProfilNamaKaryawan.Text = pengguna?.Nama ?? "Tidak ditemukan";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat nama pengguna: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPresensi_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(txtTanggalhariIni.Text, out DateTime tanggal))
            {
                MessageBox.Show("Tanggal tidak valid.");
                return;
            }

            if (!TimeSpan.TryParse(txtJamMasuk.Text, out TimeSpan jamMasuk) ||
                !TimeSpan.TryParse(txtJamKeluar.Text, out TimeSpan jamKeluar))
            {
                MessageBox.Show("Jam masuk/keluar tidak valid. Gunakan format HH:mm:ss");
                return;
            }

            try
            {
                // Cari id_karyawan berdasarkan id_user
                string idQuery = "SELECT id_karyawan FROM public.karyawan WHERE id_user = @id_user";
                var paramId = new[] { new NpgsqlParameter("@id_user", _id_user) };
                var result = _dbConnection.ExecuteQuery(idQuery, paramId);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Data karyawan tidak ditemukan.");
                    return;
                }

                int id_karyawan = Convert.ToInt32(result.Rows[0]["id_karyawan"]);

                // Simpan data presensi
                string insertQuery = @"
                    INSERT INTO public.presensi (id_karyawan, tanggal, jam_masuk, jam_keluar, status)
                    VALUES (@id_karyawan, @tanggal, @jam_masuk, @jam_keluar, @status)";
                var parameters = new[]
                {
                    new NpgsqlParameter("@id_karyawan", id_karyawan),
                    new NpgsqlParameter("@tanggal", tanggal),
                    new NpgsqlParameter("@jam_masuk", jamMasuk),
                    new NpgsqlParameter("@jam_keluar", jamKeluar),
                    new NpgsqlParameter("@status", "Hadir")
                };

                _dbConnection.ExecuteNonQuery(insertQuery, parameters);
                MessageBox.Show("Presensi berhasil disimpan.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan presensi: " + ex.Message);
            }
        }

        private void txtJamMasuk_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJamKeluar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTanggal_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(txtTanggalhariIni.Text, out _))
            {
                MessageBox.Show("Tanggal tidak valid. Gunakan format yyyy-MM-dd.");
            }
            else
            {
                MessageBox.Show("Tanggal valid.");
            }
        }

        private void btnKatalog_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new KonfirmasiPesanan(_id_user).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
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
