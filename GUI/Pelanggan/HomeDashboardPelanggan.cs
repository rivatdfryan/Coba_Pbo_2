using Kinar_Bakery.GUI;
using System;
using System.Windows.Forms;
using Kinar_Bakery.Controller;
using Kinar_Bakery.Model;
using System.Drawing;
using Kinar_Bakery.GUI.Pelanggan;

namespace Kinar_Bakery
{
    public partial class HomeDashboardPelanggan : Form
    {
        private readonly KonteksPengguna _kontroler;
        private readonly int _id_user;

        public HomeDashboardPelanggan(int id_user)
        {
            try
            {
                InitializeComponent();
                _id_user = id_user;
                _kontroler = new KonteksPengguna();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menginisialisasi dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HomeDashboardPelanggan_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProfileData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data pengguna: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProfileData()
        {
            try
            {
                var pengguna = _kontroler.AmbilBerdasarkanId(_id_user) as Pengguna;
                if (pengguna != null)
                {
                    lblNama.Text = $"Nama: {pengguna.Nama ?? ""}";
                    lblUsername.Text = $"Username: {pengguna.Username ?? ""}";
                    lblNomor_telepon.Text = $"Nomor Telepon: {pengguna.Nomor_telepon ?? ""}";
                    lblAlamat.Text = $"Alamat: {pengguna.Alamat ?? ""}";
                    lblRoleDetails.Text = pengguna.GetRoleDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data profil: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formUbah = new FormUbahPengguna(_id_user))
                {
                    formUbah.ProfileUpdated += FormUbahPengguna_ProfileUpdated;
                    if (formUbah.ShowDialog() == DialogResult.OK)
                    {
                        LoadProfileData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka pengaturan profil: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormUbahPengguna_ProfileUpdated(object sender, EventArgs e)
        {
            LoadProfileData();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.LightGray, 1))
            {
                e.Graphics.DrawRectangle(pen, e.ClipRectangle);
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.LightGray, 1))
            {
                e.Graphics.DrawRectangle(pen, e.ClipRectangle);
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
                MessageBox.Show($"Eror Saat Membuka Menu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnBestSeller_Click_1(object sender, EventArgs e)
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

        private void btnKeranjang_Click(object sender, EventArgs e)
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

        private void btnHomePelanggan_Click(object sender, EventArgs e)
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
                    MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
            else
            {

            }
        }
    }
}