namespace Kinar_Bakery.GUI
{
    partial class Presensi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Presensi));
            panel2 = new Panel();
            txtTanggalhariIni = new TextBox();
            panel12 = new Panel();
            lblProfilNamaKaryawan = new Label();
            panel9 = new Panel();
            btnPresensi = new Button();
            label1 = new Label();
            lblJudul = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            btnKatalog = new Button();
            panel5 = new Panel();
            button4 = new Button();
            panel15 = new Panel();
            panel6 = new Panel();
            btnAbsen = new Button();
            btnHome = new Button();
            panel4 = new Panel();
            panel1 = new Panel();
            txtJamMasuk = new TextBox();
            txtJamKeluar = new TextBox();
            btnTanggal = new Button();
            panel2.SuspendLayout();
            panel12.SuspendLayout();
            panel9.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(251, 238, 215);
            panel2.Controls.Add(btnTanggal);
            panel2.Controls.Add(txtJamKeluar);
            panel2.Controls.Add(txtJamMasuk);
            panel2.Controls.Add(txtTanggalhariIni);
            panel2.Controls.Add(panel12);
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lblJudul);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            panel2.Font = new Font("Microsoft Sans Serif", 8.25F);
            panel2.Location = new Point(1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1263, 683);
            panel2.TabIndex = 6;
            // 
            // txtTanggalhariIni
            // 
            txtTanggalhariIni.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTanggalhariIni.Location = new Point(439, 166);
            txtTanggalhariIni.Name = "txtTanggalhariIni";
            txtTanggalhariIni.Size = new Size(149, 26);
            txtTanggalhariIni.TabIndex = 7;
            txtTanggalhariIni.TextChanged += txtTanggalhariIni_TextChanged;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(80, 43, 15);
            panel12.Controls.Add(lblProfilNamaKaryawan);
            panel12.Location = new Point(439, 235);
            panel12.Name = "panel12";
            panel12.Size = new Size(655, 63);
            panel12.TabIndex = 6;
            // 
            // lblProfilNamaKaryawan
            // 
            lblProfilNamaKaryawan.AutoSize = true;
            lblProfilNamaKaryawan.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfilNamaKaryawan.ForeColor = Color.FromArgb(251, 238, 215);
            lblProfilNamaKaryawan.Location = new Point(163, 23);
            lblProfilNamaKaryawan.Name = "lblProfilNamaKaryawan";
            lblProfilNamaKaryawan.Size = new Size(361, 25);
            lblProfilNamaKaryawan.TabIndex = 8;
            lblProfilNamaKaryawan.Text = "Nama Karyawan : Nama Kasir";
            lblProfilNamaKaryawan.Click += lblProfilNamaKaryawan_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(183, 150, 107);
            panel9.Controls.Add(btnPresensi);
            panel9.Location = new Point(439, 289);
            panel9.Name = "panel9";
            panel9.Size = new Size(655, 282);
            panel9.TabIndex = 5;
            // 
            // btnPresensi
            // 
            btnPresensi.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPresensi.ForeColor = Color.FromArgb(128, 64, 0);
            btnPresensi.Location = new Point(257, 97);
            btnPresensi.Name = "btnPresensi";
            btnPresensi.Size = new Size(197, 67);
            btnPresensi.TabIndex = 0;
            btnPresensi.Text = "Presensi";
            btnPresensi.UseVisualStyleBackColor = true;
            btnPresensi.Click += btnPresensi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(289, 169);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 0;
            label1.Text = "Tanggal Hari Ini";
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 45.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.ForeColor = Color.FromArgb(80, 43, 15);
            lblJudul.Location = new Point(649, 10);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(270, 82);
            lblJudul.TabIndex = 3;
            lblJudul.Text = "Presensi";
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
            panel3.Controls.Add(btnAbsen);
            panel3.Controls.Add(btnHome);
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
            panel7.Location = new Point(43, 415);
            panel7.Name = "panel7";
            panel7.Size = new Size(42, 38);
            panel7.TabIndex = 7;
            // 
            // btnKatalog
            // 
            btnKatalog.BackColor = Color.FromArgb(251, 238, 215);
            btnKatalog.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKatalog.Location = new Point(38, 410);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Size = new Size(152, 48);
            btnKatalog.TabIndex = 7;
            btnKatalog.Text = "Katalog  ";
            btnKatalog.TextAlign = ContentAlignment.MiddleRight;
            btnKatalog.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(251, 238, 215);
            panel5.BackgroundImage = (Image)resources.GetObject("panel5.BackgroundImage");
            panel5.BackgroundImageLayout = ImageLayout.Center;
            panel5.Location = new Point(47, 506);
            panel5.Name = "panel5";
            panel5.Size = new Size(42, 37);
            panel5.TabIndex = 3;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(251, 238, 215);
            button4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(41, 500);
            button4.Name = "button4";
            button4.Size = new Size(149, 48);
            button4.TabIndex = 5;
            button4.Text = "Kasir    ";
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
            panel6.BackgroundImage = Properties.Resources.Paperclip;
            panel6.BackgroundImageLayout = ImageLayout.Center;
            panel6.Location = new Point(47, 323);
            panel6.Name = "panel6";
            panel6.Size = new Size(42, 38);
            panel6.TabIndex = 6;
            // 
            // btnAbsen
            // 
            btnAbsen.BackColor = Color.FromArgb(251, 238, 215);
            btnAbsen.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAbsen.Location = new Point(38, 317);
            btnAbsen.Name = "btnAbsen";
            btnAbsen.Size = new Size(152, 48);
            btnAbsen.TabIndex = 3;
            btnAbsen.Text = "Absensi ";
            btnAbsen.TextAlign = ContentAlignment.MiddleRight;
            btnAbsen.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(251, 238, 215);
            btnHome.Font = new Font("Verdana", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(38, 235);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(152, 48);
            btnHome.TabIndex = 2;
            btnHome.Text = "Home  ";
            btnHome.TextAlign = ContentAlignment.MiddleRight;
            btnHome.UseVisualStyleBackColor = false;
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
            // txtJamMasuk
            // 
            txtJamMasuk.Location = new Point(696, 172);
            txtJamMasuk.Name = "txtJamMasuk";
            txtJamMasuk.Size = new Size(100, 20);
            txtJamMasuk.TabIndex = 8;
            txtJamMasuk.TextChanged += txtJamMasuk_TextChanged;
            // 
            // txtJamKeluar
            // 
            txtJamKeluar.Location = new Point(920, 180);
            txtJamKeluar.Name = "txtJamKeluar";
            txtJamKeluar.Size = new Size(100, 20);
            txtJamKeluar.TabIndex = 9;
            txtJamKeluar.TextChanged += txtJamKeluar_TextChanged;
            // 
            // btnTanggal
            // 
            btnTanggal.Location = new Point(1082, 177);
            btnTanggal.Name = "btnTanggal";
            btnTanggal.Size = new Size(75, 23);
            btnTanggal.TabIndex = 10;
            btnTanggal.Text = "button1";
            btnTanggal.UseVisualStyleBackColor = true;
            btnTanggal.Click += btnTanggal_Click;
            // 
            // Presensi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel2);
            Name = "Presensi";
            Text = "Presensi";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel9.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel12;
        private Label lblProfilNamaKaryawan;
        private Panel panel9;
        private Label lblJudul;
        private Panel panel3;
        private Panel panel7;
        private Button btnKatalog;
        private Panel panel5;
        private Button button4;
        private Panel panel15;
        private Panel panel6;
        private Button btnAbsen;
        private Button btnHome;
        private Panel panel4;
        private Panel panel1;
        private Label label1;
        private Button btnPresensi;
        private TextBox txtTanggalhariIni;
        private Button btnTanggal;
        private TextBox txtJamKeluar;
        private TextBox txtJamMasuk;
    }
}