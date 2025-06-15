using Kinar_Bakery.Model;
using System;
using System.Reflection.Emit;
using Kinar_Bakery.Controller;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI.Owner
{
    public partial class Gaji : Form
    {
        private int idKaryawan;
        private int id_user;
        private string namaKaryawan;
        private DateTime tanggalAwal;
        private DateTime tanggalAkhir;
        private KontrolerPresensi kontrolerPresensi;


        public Gaji(int idKaryawan, string namaKaryawan, DateTime tanggalAwal, DateTime tanggalAkhir)
        {
            InitializeComponent();
            this.idKaryawan = idKaryawan;
            this.namaKaryawan = namaKaryawan;
            this.tanggalAwal = tanggalAwal;
            this.tanggalAkhir = tanggalAkhir;
            kontrolerPresensi = new KontrolerPresensi();
            LoadGajiData();
        }

        private void LoadGajiData()
        {
            label4.Text = namaKaryawan; // Nama karyawan
            lblRentangTanggal.Text = $"Rekap Gaji dari tanggal {tanggalAwal:dd MMMM yyyy} sampai tanggal {tanggalAkhir:dd MMMM yyyy}";

            // Hitung durasi kerja
            double totalDurasiJam = kontrolerPresensi.CalculateTotalDuration(idKaryawan, tanggalAwal, tanggalAkhir);
            lblDurasi.Text = totalDurasiJam.ToString("F2") + " Jam";

            // Asumsi gaji per jam (bisa diambil dari database atau konstanta)
            decimal gajiPerJam = 50000m; // Ganti dengan nilai dari database jika ada
            lblGajiPerjam.Text = "Rp. " + gajiPerJam.ToString("N0");

            // Hitung total gaji
            decimal totalGaji = (decimal)totalDurasiJam * gajiPerJam;
            lblTotalGaji.Text = $"Rp. {totalGaji.ToString("N0")}";
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lblDurasi_Click(object sender, EventArgs e) { }
        private void lblGajiPerjam_Click(object sender, EventArgs e) { }
        private void lblTotalGaji_Click(object sender, EventArgs e) { }

        private void button7_Click(object sender, EventArgs e)
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