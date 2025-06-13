using Kinar_Bakery.Controller;
using Kinar_Bakery.GUI;
using Kinar_Bakery.GUI.Owner;
using System;
using System.Windows.Forms;

namespace Kinar_Bakery
{
    public partial class HomeDasboardAdmin : Form
    {
        private readonly int _id_user;
        private readonly KontrolerAdmin _kontrolerAdmin;

        public HomeDasboardAdmin(int id_user)
        {
            InitializeComponent();
            _id_user = id_user;
            _kontrolerAdmin = new KontrolerAdmin();
        }

        private void HomeDasboardAdmin_Load_1(object sender, EventArgs e)
        {
            try
            {
                LoadDashboardData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                long totalJenis = _kontrolerAdmin.AmbilTotalJenisProduk();
                decimal totalSaldo = _kontrolerAdmin.AmbilTotalSaldo();
                long totalKaryawan = _kontrolerAdmin.AmbilTotalKaryawan();
                lblTotalJenisProduk.Text = totalJenis.ToString();
                lblTotalSaldo.Text = totalSaldo.ToString("N2");
                lblTotalKaryawan.Text = totalKaryawan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new MonitoringKaryawan(_id_user).ShowDialog();
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