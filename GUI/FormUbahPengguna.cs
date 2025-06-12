using Kinar_Bakery.Model;
using Kinar_Bakery.Controller;
using System;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI
{
    public partial class FormUbahPengguna : Form
    {
        public event EventHandler ProfileUpdated;
        private readonly int _id_user;
        private readonly KontrolerPengguna _kontrolerPengguna;

        public FormUbahPengguna(int id_user)
        {
            try
            {
                InitializeComponent();
                _id_user = id_user;
                _kontrolerPengguna = new KontrolerPengguna();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menginisialisasi form ubah pengguna: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                var pengguna = _kontrolerPengguna.AmbilPengguna(_id_user);
                if (pengguna != null)
                {
                    txtNama.Text = pengguna.Nama ?? string.Empty;
                    txtUsername.Text = pengguna.Username ?? string.Empty; // Tambahkan TextBox untuk Username
                    txtNomorTelepon.Text = pengguna.Nomor_telepon ?? string.Empty;
                    txtAlamat.Text = pengguna.Alamat ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data pengguna: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text)) // Validasi agar username tidak null
                {
                    MessageBox.Show("Username tidak boleh kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var pengguna = new Pengguna
                {
                    Id_user = _id_user,
                    Nama = txtNama.Text,
                    Username = txtUsername.Text, // Sertakan Username
                    Nomor_telepon = txtNomorTelepon.Text,
                    Alamat = txtAlamat.Text,
                    Role = "pelanggan" // Pastikan role sesuai constraint
                };

                _kontrolerPengguna.PerbaruiPengguna(pengguna);
                MessageBox.Show("Data pengguna berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProfileUpdated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}