using Kinar_Bakery.GUI;
using System;
using System.Windows.Forms;
using Kinar_Bakery.Controller;
using Kinar_Bakery.Model;
using System.Drawing;

namespace Kinar_Bakery
{
    public partial class HomeDashboardPelanggan : Form
    {
        private readonly KontrolerPengguna _kontroler;
        private readonly int _id_user;

        public HomeDashboardPelanggan(int id_user)
        {
            try
            {
                InitializeComponent();
                _id_user = id_user;
                _kontroler = new KontrolerPengguna();

                //btnKatalog.Click += btnKatalog_Click;
                //btnBestSeller.Click += btnBestSeller_Click;
                //btnKeranjang.Click += button4_Click;
                //btnUbah.Click += btnUbah_Click;
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
                var pengguna = _kontroler.AmbilPengguna(_id_user);
                if (pengguna != null)
                {
                    lblNama.Text = $"Nama: {pengguna.Nama ?? ""}";
                    lblUsername.Text = $"Username: {pengguna.Username ?? ""}";
                    lblNomor_telepon.Text = $"Nomor Telepon: {pengguna.Nomor_telepon ?? ""}";
                    lblAlamat.Text = $"Alamat: {pengguna.Alamat ?? ""}";
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
                MessageBox.Show("Membuka Pengaturan Profil...");
                using (var formUbah = new FormUbahPengguna(_id_user))
                {
                    formUbah.ProfileUpdated += FormUbahPengguna_ProfileUpdated; // Tambahkan handler sebelum ShowDialog
                    if (formUbah.ShowDialog() == DialogResult.OK)
                    {
                        LoadProfileData(); // Segarkan data jika DialogResult adalah OK
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
            LoadProfileData(); // Segarkan data saat event dipicu
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
                MessageBox.Show("Membuka Katalog...");
                new Katalog(_id_user).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka katalog: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBestSeller_Click_1(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Membuka Best Seller...");
                new BestSeller(_id_user).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka best seller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnKeranjang_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Membuka Keranjang...");
                new Keranjang(_id_user).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka keranjang: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnHomePelanggan_Click(object sender, EventArgs e)
        {
            new HomeDashboardPelanggan(_id_user).ShowDialog();

        }

    }
}