namespace Kinar_Bakery.GUI
{
    partial class KonfirmasiPesanan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonfirmasiPesanan));
            panel2 = new Panel();
            panel8 = new Panel();
            label1 = new Label();
            dataGridViewPesanan = new DataGridView();
            btnKonfirmasi = new Button();
            lblJudul = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            btnKatalog = new Button();
            btnLogOut = new Button();
            panel5 = new Panel();
            button4 = new Button();
            panel15 = new Panel();
            panel6 = new Panel();
            btnAbsen = new Button();
            btnHome = new Button();
            panel4 = new Panel();
            panel1 = new Panel();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPesanan).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(251, 238, 215);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(lblJudul);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            panel2.Font = new Font("Microsoft Sans Serif", 8.25F);
            panel2.Location = new Point(1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1263, 683);
            panel2.TabIndex = 8;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(183, 150, 107);
            panel8.Controls.Add(label1);
            panel8.Controls.Add(dataGridViewPesanan);
            panel8.Controls.Add(btnKonfirmasi);
            panel8.Location = new Point(278, 110);
            panel8.Name = "panel8";
            panel8.Size = new Size(953, 534);
            panel8.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(689, 482);
            label1.Name = "label1";
            label1.Size = new Size(10, 13);
            label1.TabIndex = 2;
            label1.Text = " ";
            // 
            // dataGridViewPesanan
            // 
            dataGridViewPesanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPesanan.Location = new Point(268, 57);
            dataGridViewPesanan.Name = "dataGridViewPesanan";
            dataGridViewPesanan.Size = new Size(445, 361);
            dataGridViewPesanan.TabIndex = 1;
            // 
            // btnKonfirmasi
            // 
            btnKonfirmasi.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKonfirmasi.ForeColor = Color.FromArgb(128, 64, 0);
            btnKonfirmasi.Location = new Point(813, 471);
            btnKonfirmasi.Name = "btnKonfirmasi";
            btnKonfirmasi.Size = new Size(121, 45);
            btnKonfirmasi.TabIndex = 0;
            btnKonfirmasi.Text = "Konfirmasi";
            btnKonfirmasi.UseVisualStyleBackColor = true;
            btnKonfirmasi.Click += btnKonfirmasi_Click;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 45.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.ForeColor = Color.FromArgb(80, 43, 15);
            lblJudul.Location = new Point(470, 10);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(597, 82);
            lblJudul.TabIndex = 3;
            lblJudul.Text = "Konfirmasi Pesanan";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(183, 150, 107);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(btnKatalog);
            panel3.Controls.Add(btnLogOut);
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
            panel7.Location = new Point(40, 490);
            panel7.Name = "panel7";
            panel7.Size = new Size(25, 38);
            panel7.TabIndex = 12;
            // 
            // btnKatalog
            // 
            btnKatalog.BackColor = Color.FromArgb(251, 238, 215);
            btnKatalog.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKatalog.Location = new Point(35, 487);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Size = new Size(152, 43);
            btnKatalog.TabIndex = 13;
            btnKatalog.Text = "Konfirmasi Pesanan\r\n";
            btnKatalog.TextAlign = ContentAlignment.MiddleRight;
            btnKatalog.UseVisualStyleBackColor = false;
            btnKatalog.Click += btnKatalog_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(251, 238, 215);
            btnLogOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.Location = new Point(63, 623);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(94, 47);
            btnLogOut.TabIndex = 11;
            btnLogOut.Text = "LOGOUT";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(251, 238, 215);
            panel5.BackgroundImage = (Image)resources.GetObject("panel5.BackgroundImage");
            panel5.BackgroundImageLayout = ImageLayout.Center;
            panel5.Location = new Point(44, 404);
            panel5.Name = "panel5";
            panel5.Size = new Size(42, 37);
            panel5.TabIndex = 3;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(251, 238, 215);
            button4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(38, 398);
            button4.Name = "button4";
            button4.Size = new Size(149, 48);
            button4.TabIndex = 5;
            button4.Text = "Kasir    ";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
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
            btnAbsen.Click += btnAbsen_Click;
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
            btnHome.Click += btnHome_Click;
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
            // KonfirmasiPesanan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel2);
            Name = "KonfirmasiPesanan";
            Text = "Form1";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPesanan).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private TextBox textBox1;
        private Panel panel8;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Button btnKonfirmasi;
        private Label label3;
        private Panel panel9;
        private Button button1;
        private Label lblJudul;
        private Panel panel3;
        private Panel panel5;
        private Button button4;
        private Panel panel15;
        private Panel panel6;
        private Button btnAbsen;
        private Button btnHome;
        private Panel panel4;
        private Panel panel1;
        private Label label1;
        private DataGridView dataGridViewPesanan;
        private Button btnLogOut;
        private Panel panel7;
        private Button btnKatalog;
    }
}