namespace Kinar_Bakery.GUI
{
    partial class FormUbahPengguna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUbahPengguna));
            panel2 = new Panel();
            panel12 = new Panel();
            lblJudul = new Label();
            panel9 = new Panel();
            txtUsername = new TextBox();
            btnSimpan = new Button();
            txtAlamat = new TextBox();
            txtNomorTelepon = new TextBox();
            txtNama = new TextBox();
            lblAlamat = new Label();
            lblNomor_telepon = new Label();
            lblUsername = new Label();
            lblNama = new Label();
            txtSelamatDatang = new Label();
            txtDashboardKasir = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            btnKatalog = new Button();
            panel5 = new Panel();
            button4 = new Button();
            panel15 = new Panel();
            panel6 = new Panel();
            btnBestSeller = new Button();
            btnHomePelanggan = new Button();
            panel4 = new Panel();
            panel1 = new Panel();
            panel2.SuspendLayout();
            panel12.SuspendLayout();
            panel9.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(251, 238, 215);
            panel2.Controls.Add(panel12);
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(txtSelamatDatang);
            panel2.Controls.Add(txtDashboardKasir);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            panel2.Font = new Font("Microsoft Sans Serif", 8.25F);
            panel2.Location = new Point(1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1263, 683);
            panel2.TabIndex = 7;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(80, 43, 15);
            panel12.Controls.Add(lblJudul);
            panel12.Location = new Point(267, 159);
            panel12.Name = "panel12";
            panel12.Size = new Size(984, 59);
            panel12.TabIndex = 6;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.ForeColor = Color.FromArgb(251, 238, 215);
            lblJudul.Location = new Point(396, 17);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(142, 25);
            lblJudul.TabIndex = 8;
            lblJudul.Text = "Ubah Profil";
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(183, 150, 107);
            panel9.Controls.Add(txtUsername);
            panel9.Controls.Add(btnSimpan);
            panel9.Controls.Add(txtAlamat);
            panel9.Controls.Add(txtNomorTelepon);
            panel9.Controls.Add(txtNama);
            panel9.Controls.Add(lblAlamat);
            panel9.Controls.Add(lblNomor_telepon);
            panel9.Controls.Add(lblUsername);
            panel9.Controls.Add(lblNama);
            panel9.Location = new Point(267, 159);
            panel9.Name = "panel9";
            panel9.Size = new Size(984, 500);
            panel9.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(442, 162);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(500, 31);
            txtUsername.TabIndex = 23;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(800, 401);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(75, 23);
            btnSimpan.TabIndex = 22;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click_1;
            // 
            // txtAlamat
            // 
            txtAlamat.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAlamat.Location = new Point(442, 313);
            txtAlamat.Name = "txtAlamat";
            txtAlamat.Size = new Size(500, 31);
            txtAlamat.TabIndex = 21;
            // 
            // txtNomorTelepon
            // 
            txtNomorTelepon.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomorTelepon.Location = new Point(442, 227);
            txtNomorTelepon.Name = "txtNomorTelepon";
            txtNomorTelepon.Size = new Size(500, 31);
            txtNomorTelepon.TabIndex = 20;
            // 
            // txtNama
            // 
            txtNama.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNama.Location = new Point(438, 98);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(500, 31);
            txtNama.TabIndex = 19;
            // 
            // lblAlamat
            // 
            lblAlamat.AutoSize = true;
            lblAlamat.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAlamat.ForeColor = Color.FromArgb(80, 43, 15);
            lblAlamat.Location = new Point(341, 315);
            lblAlamat.Name = "lblAlamat";
            lblAlamat.Size = new Size(110, 25);
            lblAlamat.TabIndex = 17;
            lblAlamat.Text = "Alamat: ";
            // 
            // lblNomor_telepon
            // 
            lblNomor_telepon.AutoSize = true;
            lblNomor_telepon.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomor_telepon.ForeColor = Color.FromArgb(80, 43, 15);
            lblNomor_telepon.Location = new Point(246, 227);
            lblNomor_telepon.Name = "lblNomor_telepon";
            lblNomor_telepon.Size = new Size(205, 25);
            lblNomor_telepon.TabIndex = 16;
            lblNomor_telepon.Text = "Nomor Telepon: ";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.FromArgb(80, 43, 15);
            lblUsername.Location = new Point(306, 157);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(145, 25);
            lblUsername.TabIndex = 15;
            lblUsername.Text = "Username: ";
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNama.ForeColor = Color.FromArgb(80, 43, 15);
            lblNama.Location = new Point(356, 93);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(95, 25);
            lblNama.TabIndex = 14;
            lblNama.Text = "Nama: ";
            // 
            // txtSelamatDatang
            // 
            txtSelamatDatang.AutoSize = true;
            txtSelamatDatang.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtSelamatDatang.Location = new Point(602, 82);
            txtSelamatDatang.Name = "txtSelamatDatang";
            txtSelamatDatang.Size = new Size(270, 29);
            txtSelamatDatang.TabIndex = 4;
            txtSelamatDatang.Text = "Selamat Datang Pelanggan\r\n";
            // 
            // txtDashboardKasir
            // 
            txtDashboardKasir.AutoSize = true;
            txtDashboardKasir.Font = new Font("Segoe UI", 45.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDashboardKasir.ForeColor = Color.FromArgb(80, 43, 15);
            txtDashboardKasir.Location = new Point(400, 0);
            txtDashboardKasir.Name = "txtDashboardKasir";
            txtDashboardKasir.Size = new Size(664, 82);
            txtDashboardKasir.TabIndex = 3;
            txtDashboardKasir.Text = "Dashboard Pelanggan";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(183, 150, 107);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(btnKatalog);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(panel15);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(btnBestSeller);
            panel3.Controls.Add(btnHomePelanggan);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(245, 683);
            panel3.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(251, 238, 215);
            panel7.BackgroundImage = (Image)resources.GetObject("panel7.BackgroundImage");
            panel7.BackgroundImageLayout = ImageLayout.Center;
            panel7.Location = new Point(48, 327);
            panel7.Name = "panel7";
            panel7.Size = new Size(42, 38);
            panel7.TabIndex = 8;
            // 
            // btnKatalog
            // 
            btnKatalog.BackColor = Color.FromArgb(251, 238, 215);
            btnKatalog.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKatalog.Location = new Point(41, 321);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Size = new Size(149, 48);
            btnKatalog.TabIndex = 7;
            btnKatalog.Text = " Katalog ";
            btnKatalog.TextAlign = ContentAlignment.MiddleRight;
            btnKatalog.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(251, 238, 215);
            panel5.BackgroundImage = (Image)resources.GetObject("panel5.BackgroundImage");
            panel5.BackgroundImageLayout = ImageLayout.Center;
            panel5.Location = new Point(47, 503);
            panel5.Name = "panel5";
            panel5.Size = new Size(42, 37);
            panel5.TabIndex = 3;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(251, 238, 215);
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(41, 500);
            button4.Name = "button4";
            button4.Size = new Size(149, 48);
            button4.TabIndex = 5;
            button4.Text = "Keranjang Belanja";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = false;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(251, 238, 215);
            panel15.BackgroundImage = Properties.Resources.Frame;
            panel15.BackgroundImageLayout = ImageLayout.Center;
            panel15.Location = new Point(47, 240);
            panel15.Name = "panel15";
            panel15.Size = new Size(42, 37);
            panel15.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(251, 238, 215);
            panel6.BackgroundImage = (Image)resources.GetObject("panel6.BackgroundImage");
            panel6.BackgroundImageLayout = ImageLayout.Stretch;
            panel6.Location = new Point(48, 420);
            panel6.Name = "panel6";
            panel6.Size = new Size(42, 38);
            panel6.TabIndex = 6;
            // 
            // btnBestSeller
            // 
            btnBestSeller.BackColor = Color.FromArgb(251, 238, 215);
            btnBestSeller.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBestSeller.Location = new Point(41, 415);
            btnBestSeller.Name = "btnBestSeller";
            btnBestSeller.Size = new Size(152, 48);
            btnBestSeller.TabIndex = 3;
            btnBestSeller.Text = "Best Seller ";
            btnBestSeller.TextAlign = ContentAlignment.MiddleRight;
            btnBestSeller.UseVisualStyleBackColor = false;
            // 
            // btnHomePelanggan
            // 
            btnHomePelanggan.BackColor = Color.FromArgb(251, 238, 215);
            btnHomePelanggan.Font = new Font("Verdana", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHomePelanggan.Location = new Point(38, 235);
            btnHomePelanggan.Name = "btnHomePelanggan";
            btnHomePelanggan.Size = new Size(152, 48);
            btnHomePelanggan.TabIndex = 2;
            btnHomePelanggan.Text = "Home  ";
            btnHomePelanggan.TextAlign = ContentAlignment.MiddleRight;
            btnHomePelanggan.UseVisualStyleBackColor = false;
            btnHomePelanggan.Click += btnHomePelanggan_Click;
            // 
            // panel4
            // 
            panel4.BackgroundImage = Properties.Resources.Group;
            panel4.BackgroundImageLayout = ImageLayout.Center;
            panel4.Location = new Point(20, 24);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 132);
            panel4.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 0;
            // 
            // FormUbahPengguna
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel2);
            Name = "FormUbahPengguna";
            Text = "FormUbahPengguna";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel12;
        private Label lblJudul;
        private Panel panel9;
        private Label txtSelamatDatang;
        private Label txtDashboardKasir;
        private Panel panel3;
        private Panel panel7;
        private Button btnKatalog;
        private Panel panel5;
        private Button button4;
        private Panel panel15;
        private Panel panel6;
        private Button btnBestSeller;
        private Button btnHomePelanggan;
        private Panel panel4;
        private Panel panel1;
        private TextBox txtAlamat;
        private TextBox txtNomorTelepon;
        private TextBox txtNama;
        private Label lblAlamat;
        private Label lblNomor_telepon;
        private Label lblUsername;
        private Label lblNama;
        private Button btnSimpan;
        private TextBox txtUsername;
    }
}