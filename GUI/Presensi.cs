using Kinar_Bakery.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinar_Bakery.GUI
{
    public partial class Presensi : Form
    {
        
        private readonly int _id_user;
        
        private readonly KontrolerProduk _kontroler;
        public Presensi(int id_user)
        {
            InitializeComponent();
            _id_user = id_user;
        }

        private void txtTanggalhariIni_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProfilNamaKaryawan_Click(object sender, EventArgs e)
        {

        }

        private void btnPresensi_Click(object sender, EventArgs e)
        {

        }

        private void txtJamMasuk_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJamKeluar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTanggal_Click(object sender, EventArgs e)
        {

        }
    }
}
