﻿namespace Kinar_Bakery.GUI.Owner
{
    partial class KelolaProduk
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
            panel2 = new Panel();
            btnTambah = new Button();
            dataGridView1 = new DataGridView();
            btnEdit = new Button();
            txtCari = new TextBox();
            label5 = new Label();
            panel12 = new Panel();
            label3 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            btnLogOut = new Button();
            panel7 = new Panel();
            button4 = new Button();
            panel5 = new Panel();
            button3 = new Button();
            panel15 = new Panel();
            panel6 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel4 = new Panel();
            panel1 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel12.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(251, 238, 215);
            panel2.Controls.Add(btnTambah);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(txtCari);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(panel12);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            panel2.Font = new Font("Microsoft Sans Serif", 8.25F);
            panel2.Location = new Point(1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1263, 683);
            panel2.TabIndex = 4;
            // 
            // btnTambah
            // 
            btnTambah.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambah.ForeColor = Color.FromArgb(128, 64, 0);
            btnTambah.Location = new Point(829, 617);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(193, 34);
            btnTambah.TabIndex = 25;
            btnTambah.Text = "Tambah Produk Baru";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(486, 236);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(553, 366);
            dataGridView1.TabIndex = 16;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.FromArgb(128, 64, 0);
            btnEdit.Location = new Point(1066, 615);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(141, 34);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Edit Produk";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtCari
            // 
            txtCari.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCari.Location = new Point(1066, 115);
            txtCari.Name = "txtCari";
            txtCari.Size = new Size(176, 26);
            txtCari.TabIndex = 12;
            txtCari.TextChanged += txtCari_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(937, 118);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 11;
            label5.Text = "Cari Produk";
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(80, 43, 15);
            panel12.Controls.Add(label3);
            panel12.Location = new Point(267, 159);
            panel12.Name = "panel12";
            panel12.Size = new Size(975, 59);
            panel12.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(251, 238, 215);
            label3.Location = new Point(400, 15);
            label3.Name = "label3";
            label3.Size = new Size(174, 25);
            label3.TabIndex = 8;
            label3.Text = "Kelola Produk";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 45.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(80, 43, 15);
            label1.Location = new Point(537, 0);
            label1.Name = "label1";
            label1.Size = new Size(435, 82);
            label1.TabIndex = 3;
            label1.Text = "Kelola Produk";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(183, 150, 107);
            panel3.Controls.Add(btnLogOut);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(panel15);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(245, 683);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(251, 238, 215);
            btnLogOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.Location = new Point(64, 627);
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
            panel7.BackgroundImage = Properties.Resources.Tablet;
            panel7.BackgroundImageLayout = ImageLayout.Center;
            panel7.Location = new Point(46, 503);
            panel7.Name = "panel7";
            panel7.Size = new Size(42, 42);
            panel7.TabIndex = 9;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(251, 238, 215);
            button4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(41, 500);
            button4.Name = "button4";
            button4.Size = new Size(149, 48);
            button4.TabIndex = 5;
            button4.Text = "Monitoring  \r\nKaryawan    ";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(251, 238, 215);
            panel5.BackgroundImage = Properties.Resources.add_circle;
            panel5.BackgroundImageLayout = ImageLayout.Center;
            panel5.Location = new Point(49, 404);
            panel5.Name = "panel5";
            panel5.Size = new Size(42, 37);
            panel5.TabIndex = 8;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(251, 238, 215);
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(41, 398);
            button3.Name = "button3";
            button3.Size = new Size(149, 48);
            button3.TabIndex = 4;
            button3.Text = "Kelola Produk";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(251, 238, 215);
            panel15.BackgroundImage = Properties.Resources.Frame;
            panel15.BackgroundImageLayout = ImageLayout.Center;
            panel15.Location = new Point(47, 199);
            panel15.Name = "panel15";
            panel15.Size = new Size(42, 37);
            panel15.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(251, 238, 215);
            panel6.BackgroundImage = Properties.Resources.Paperclip;
            panel6.BackgroundImageLayout = ImageLayout.Center;
            panel6.Location = new Point(49, 306);
            panel6.Name = "panel6";
            panel6.Size = new Size(42, 38);
            panel6.TabIndex = 6;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(251, 238, 215);
            button2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(38, 300);
            button2.Name = "button2";
            button2.Size = new Size(152, 48);
            button2.TabIndex = 3;
            button2.Text = "Laporan Penjualan";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(251, 238, 215);
            button1.Font = new Font("Verdana", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(38, 194);
            button1.Name = "button1";
            button1.Size = new Size(152, 48);
            button1.TabIndex = 2;
            button1.Text = "Home  ";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            // KelolaProduk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel2);
            Name = "KelolaProduk";
            Text = "KelolaProduk";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dataGridView1;
        private Button btnEdit;
        private TextBox txtCari;
        private Label label5;
        private Panel panel12;
        private Label label3;
        private Label label1;
        private Panel panel3;
        private Button btnLogOut;
        private Panel panel7;
        private Button button4;
        private Panel panel5;
        private Button button3;
        private Panel panel15;
        private Panel panel6;
        private Button button2;
        private Button button1;
        private Panel panel4;
        private Panel panel1;
        private Button btnTambah;
    }
}