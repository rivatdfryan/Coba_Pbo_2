using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinar_Bakery
{
    public partial class LaporanPenjualan : Form
    {
        public LaporanPenjualan()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // TES
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
