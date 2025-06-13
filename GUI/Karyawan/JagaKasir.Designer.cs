namespace Kinar_Bakery.GUI
{
    partial class JagaKasir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JagaKasir));
            panel2 = new Panel();
            txtCariProduk = new TextBox();
            panel8 = new Panel();
            lblTotal = new Label();
            lblHarga = new Label();
            label7 = new Label();
            lblJumlah = new Label();
            label5 = new Label();
            label4 = new Label();
            lblNama = new Label();
            label1 = new Label();
            btnKonfirmasi = new Button();
            label3 = new Label();
            panel9 = new Panel();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            btnTambah = new Button();
            lblJudul = new Label();
            panel3 = new Panel();
            btnLogOut = new Button();
            panel7 = new Panel();
            btnKonfir = new Button();
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
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(251, 238, 215);
            panel2.Controls.Add(txtCariProduk);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(lblJudul);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            panel2.Font = new Font("Microsoft Sans Serif", 8.25F);
            panel2.Location = new Point(1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1263, 683);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // txtCariProduk
            // 
            txtCariProduk.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCariProduk.Location = new Point(1079, 117);
            txtCariProduk.Name = "txtCariProduk";
            txtCariProduk.Size = new Size(152, 26);
            txtCariProduk.TabIndex = 8;
            txtCariProduk.TextChanged += txtCariProduk_TextChanged;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(183, 150, 107);
            panel8.Controls.Add(lblTotal);
            panel8.Controls.Add(lblHarga);
            panel8.Controls.Add(label7);
            panel8.Controls.Add(lblJumlah);
            panel8.Controls.Add(label5);
            panel8.Controls.Add(label4);
            panel8.Controls.Add(lblNama);
            panel8.Controls.Add(label1);
            panel8.Controls.Add(btnKonfirmasi);
            panel8.Location = new Point(278, 399);
            panel8.Name = "panel8";
            panel8.Size = new Size(953, 245);
            panel8.TabIndex = 6;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(840, 158);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(57, 20);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "label9";
            lblTotal.Click += lblTotal_Click;
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHarga.Location = new Point(840, 52);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(57, 20);
            lblHarga.TabIndex = 7;
            lblHarga.Text = "label8";
            lblHarga.Click += lblHarga_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(839, 11);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 6;
            label7.Text = "Harga";
            // 
            // lblJumlah
            // 
            lblJumlah.AutoSize = true;
            lblJumlah.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJumlah.Location = new Point(471, 52);
            lblJumlah.Name = "lblJumlah";
            lblJumlah.Size = new Size(57, 20);
            lblJumlah.TabIndex = 5;
            lblJumlah.Text = "label6";
            lblJumlah.Click += lblJumlah_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(471, 16);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 4;
            label5.Text = "Jumlah";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(27, 158);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "Total";
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNama.Location = new Point(27, 52);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(89, 20);
            lblNama.TabIndex = 2;
            lblNama.Text = "nama roti ";
            lblNama.Click += lblNama_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 16);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 1;
            label1.Text = "Nama";
            // 
            // btnKonfirmasi
            // 
            btnKonfirmasi.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKonfirmasi.ForeColor = Color.FromArgb(128, 64, 0);
            btnKonfirmasi.Location = new Point(818, 186);
            btnKonfirmasi.Name = "btnKonfirmasi";
            btnKonfirmasi.Size = new Size(121, 45);
            btnKonfirmasi.TabIndex = 0;
            btnKonfirmasi.Text = "Konfirmasi";
            btnKonfirmasi.UseVisualStyleBackColor = true;
            btnKonfirmasi.Click += btnKonfirmasi_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(971, 120);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 7;
            label3.Text = "Cari Produk";
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(183, 150, 107);
            panel9.Controls.Add(textBox1);
            panel9.Controls.Add(dataGridView1);
            panel9.Controls.Add(btnTambah);
            panel9.Location = new Point(278, 149);
            panel9.Name = "panel9";
            panel9.Size = new Size(953, 232);
            panel9.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(669, 203);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 20);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(953, 185);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnTambah
            // 
            btnTambah.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambah.ForeColor = Color.FromArgb(128, 64, 0);
            btnTambah.Location = new Point(840, 191);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(99, 38);
            btnTambah.TabIndex = 0;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 45.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.ForeColor = Color.FromArgb(80, 43, 15);
            lblJudul.Location = new Point(602, 10);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(323, 82);
            lblJudul.TabIndex = 3;
            lblJudul.Text = "Jaga Kasir";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(183, 150, 107);
            panel3.Controls.Add(btnLogOut);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(btnKonfir);
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
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(251, 238, 215);
            btnLogOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.Location = new Point(67, 627);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(94, 43);
            btnLogOut.TabIndex = 11;
            btnLogOut.Text = "LOGOUT";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(251, 238, 215);
            panel7.BackgroundImage = (Image)resources.GetObject("panel7.BackgroundImage");
            panel7.BackgroundImageLayout = ImageLayout.Center;
            panel7.Location = new Point(43, 482);
            panel7.Name = "panel7";
            panel7.Size = new Size(25, 38);
            panel7.TabIndex = 7;
            panel7.Paint += panel7_Paint;
            // 
            // btnKonfir
            // 
            btnKonfir.BackColor = Color.FromArgb(251, 238, 215);
            btnKonfir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKonfir.Location = new Point(38, 479);
            btnKonfir.Name = "btnKonfir";
            btnKonfir.Size = new Size(152, 43);
            btnKonfir.TabIndex = 7;
            btnKonfir.Text = "Konfirmasi Pesanan\r\n";
            btnKonfir.TextAlign = ContentAlignment.MiddleRight;
            btnKonfir.UseVisualStyleBackColor = false;
            btnKonfir.Click += btnKonfir_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(251, 238, 215);
            panel5.BackgroundImage = (Image)resources.GetObject("panel5.BackgroundImage");
            panel5.BackgroundImageLayout = ImageLayout.Center;
            panel5.Location = new Point(44, 405);
            panel5.Name = "panel5";
            panel5.Size = new Size(42, 37);
            panel5.TabIndex = 3;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(251, 238, 215);
            button4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(38, 399);
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
            panel6.Paint += panel6_Paint;
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
            // JagaKasir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel2);
            Name = "JagaKasir";
            Text = "JagaKasir";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label lblJudul;
        private Panel panel3;
        private Panel panel7;
        private Button btnKonfir;
        private Panel panel5;
        private Button button4;
        private Panel panel15;
        private Panel panel6;
        private Button btnAbsen;
        private Button btnHome;
        private Panel panel4;
        private Panel panel1;
        private Panel panel8;
        private Button btnKonfirmasi;
        private Label label3;
        private Panel panel9;
        private Button btnTambah;
        private Label lblTotal;
        private Label lblHarga;
        private Label label7;
        private Label lblJumlah;
        private Label label5;
        private Label label4;
        private Label lblNama;
        private Label label1;
        private TextBox txtCariProduk;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button btnLogOut;
    }
}