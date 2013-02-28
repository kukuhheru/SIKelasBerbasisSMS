namespace AdminSMS
{
    partial class frmJadwal
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtKeteranganRuang = new System.Windows.Forms.TextBox();
            this.txtKodeRuang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstRuang = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader(0);
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtKeteranganKelas = new System.Windows.Forms.TextBox();
            this.txtKodeKelas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstKelas = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader(0);
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtWaktuMulai = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstJadwal = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader(0);
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editJadwalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hapusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMataKuliah = new System.Windows.Forms.Button();
            this.btnLihatDosen = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cmbRuang = new System.Windows.Forms.ComboBox();
            this.cmbKelas = new System.Windows.Forms.ComboBox();
            this.cmbMataKuliah = new System.Windows.Forms.ComboBox();
            this.cmbDosen = new System.Windows.Forms.ComboBox();
            this.cmbHari = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.txtWaktuAkhir = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtKeteranganRuang);
            this.groupBox1.Controls.Add(this.txtKodeRuang);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstRuang);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ruang";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(55, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 21);
            this.button2.TabIndex = 15;
            this.button2.Text = "Hapus";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(128, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 21);
            this.button1.TabIndex = 14;
            this.button1.Text = "Tambah";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtKeteranganRuang
            // 
            this.txtKeteranganRuang.Location = new System.Drawing.Point(83, 47);
            this.txtKeteranganRuang.Name = "txtKeteranganRuang";
            this.txtKeteranganRuang.Size = new System.Drawing.Size(113, 20);
            this.txtKeteranganRuang.TabIndex = 13;
            this.txtKeteranganRuang.TextChanged += new System.EventHandler(this.txtKodeRuang_TextChanged);
            // 
            // txtKodeRuang
            // 
            this.txtKodeRuang.Location = new System.Drawing.Point(83, 22);
            this.txtKodeRuang.Name = "txtKodeRuang";
            this.txtKodeRuang.Size = new System.Drawing.Size(113, 20);
            this.txtKodeRuang.TabIndex = 12;
            this.txtKodeRuang.TextChanged += new System.EventHandler(this.txtKodeRuang_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Keterangan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kode Ruang";
            // 
            // lstRuang
            // 
            this.lstRuang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstRuang.FullRowSelect = true;
            this.lstRuang.Location = new System.Drawing.Point(6, 102);
            this.lstRuang.MultiSelect = false;
            this.lstRuang.Name = "lstRuang";
            this.lstRuang.Size = new System.Drawing.Size(190, 149);
            this.lstRuang.TabIndex = 9;
            this.lstRuang.UseCompatibleStateImageBehavior = false;
            this.lstRuang.View = System.Windows.Forms.View.Details;
            this.lstRuang.Click += new System.EventHandler(this.lstRuang_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 51;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Keterangan";
            this.columnHeader2.Width = 110;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.txtKeteranganKelas);
            this.groupBox2.Controls.Add(this.txtKodeKelas);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lstKelas);
            this.groupBox2.Location = new System.Drawing.Point(9, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 259);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kelas";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(55, 75);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 21);
            this.button3.TabIndex = 15;
            this.button3.Text = "Hapus";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(128, 75);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 21);
            this.button4.TabIndex = 14;
            this.button4.Text = "Tambah";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtKeteranganKelas
            // 
            this.txtKeteranganKelas.Location = new System.Drawing.Point(83, 47);
            this.txtKeteranganKelas.Name = "txtKeteranganKelas";
            this.txtKeteranganKelas.Size = new System.Drawing.Size(113, 20);
            this.txtKeteranganKelas.TabIndex = 13;
            this.txtKeteranganKelas.TextChanged += new System.EventHandler(this.txtKodeKelas_TextChanged);
            // 
            // txtKodeKelas
            // 
            this.txtKodeKelas.Location = new System.Drawing.Point(83, 22);
            this.txtKodeKelas.Name = "txtKodeKelas";
            this.txtKodeKelas.Size = new System.Drawing.Size(113, 20);
            this.txtKodeKelas.TabIndex = 12;
            this.txtKodeKelas.TextChanged += new System.EventHandler(this.txtKodeKelas_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Keterangan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kode Kelas";
            // 
            // lstKelas
            // 
            this.lstKelas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lstKelas.FullRowSelect = true;
            this.lstKelas.Location = new System.Drawing.Point(6, 102);
            this.lstKelas.MultiSelect = false;
            this.lstKelas.Name = "lstKelas";
            this.lstKelas.Size = new System.Drawing.Size(190, 149);
            this.lstKelas.TabIndex = 9;
            this.lstKelas.UseCompatibleStateImageBehavior = false;
            this.lstKelas.View = System.Windows.Forms.View.Details;
            this.lstKelas.Click += new System.EventHandler(this.lstKelas_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 51;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Keterangan";
            this.columnHeader4.Width = 107;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtWaktuAkhir);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.lblId);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtWaktuMulai);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lstJadwal);
            this.groupBox3.Controls.Add(this.btnMataKuliah);
            this.groupBox3.Controls.Add(this.btnLihatDosen);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.cmbRuang);
            this.groupBox3.Controls.Add(this.cmbKelas);
            this.groupBox3.Controls.Add(this.cmbMataKuliah);
            this.groupBox3.Controls.Add(this.cmbDosen);
            this.groupBox3.Controls.Add(this.cmbHari);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(217, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 525);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Jadwal";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(417, 43);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(89, 22);
            this.button7.TabIndex = 18;
            this.button7.Text = "Batal";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblId.Location = new System.Drawing.Point(473, 176);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(2, 15);
            this.lblId.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(449, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "ID";
            // 
            // txtWaktuMulai
            // 
            this.txtWaktuMulai.Location = new System.Drawing.Point(109, 159);
            this.txtWaktuMulai.Mask = "00:00:00";
            this.txtWaktuMulai.Name = "txtWaktuMulai";
            this.txtWaktuMulai.Size = new System.Drawing.Size(59, 20);
            this.txtWaktuMulai.TabIndex = 15;
            this.txtWaktuMulai.ValidatingType = typeof(System.DateTime);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Waktu Mulai";
            // 
            // lstJadwal
            // 
            this.lstJadwal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader11,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader12});
            this.lstJadwal.ContextMenuStrip = this.contextMenuStrip1;
            this.lstJadwal.FullRowSelect = true;
            this.lstJadwal.Location = new System.Drawing.Point(19, 194);
            this.lstJadwal.MultiSelect = false;
            this.lstJadwal.Name = "lstJadwal";
            this.lstJadwal.Size = new System.Drawing.Size(487, 322);
            this.lstJadwal.TabIndex = 13;
            this.lstJadwal.UseCompatibleStateImageBehavior = false;
            this.lstJadwal.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 33;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Hari";
            this.columnHeader6.Width = 66;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Waktu Mulai";
            this.columnHeader11.Width = 87;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Ruang";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Waktu Akhir";
            this.columnHeader7.Width = 91;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Mata Kuliah";
            this.columnHeader8.Width = 93;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Dosen";
            this.columnHeader9.Width = 54;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Kelas";
            this.columnHeader10.Width = 47;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editJadwalToolStripMenuItem,
            this.hapusToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 48);
            // 
            // editJadwalToolStripMenuItem
            // 
            this.editJadwalToolStripMenuItem.Name = "editJadwalToolStripMenuItem";
            this.editJadwalToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.editJadwalToolStripMenuItem.Text = "Edit ";
            this.editJadwalToolStripMenuItem.Click += new System.EventHandler(this.editJadwalToolStripMenuItem_Click);
            // 
            // hapusToolStripMenuItem
            // 
            this.hapusToolStripMenuItem.Image = global::AdminSMS.Properties.Resources.delete;
            this.hapusToolStripMenuItem.Name = "hapusToolStripMenuItem";
            this.hapusToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.hapusToolStripMenuItem.Text = "Hapus";
            this.hapusToolStripMenuItem.Click += new System.EventHandler(this.hapusToolStripMenuItem_Click);
            // 
            // btnMataKuliah
            // 
            this.btnMataKuliah.Location = new System.Drawing.Point(318, 70);
            this.btnMataKuliah.Name = "btnMataKuliah";
            this.btnMataKuliah.Size = new System.Drawing.Size(26, 21);
            this.btnMataKuliah.TabIndex = 12;
            this.btnMataKuliah.Text = "...";
            this.btnMataKuliah.UseVisualStyleBackColor = true;
            // 
            // btnLihatDosen
            // 
            this.btnLihatDosen.Location = new System.Drawing.Point(318, 44);
            this.btnLihatDosen.Name = "btnLihatDosen";
            this.btnLihatDosen.Size = new System.Drawing.Size(26, 21);
            this.btnLihatDosen.TabIndex = 11;
            this.btnLihatDosen.Text = "...";
            this.btnLihatDosen.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(417, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 22);
            this.button5.TabIndex = 10;
            this.button5.Text = "Tambah";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cmbRuang
            // 
            this.cmbRuang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRuang.FormattingEnabled = true;
            this.cmbRuang.Location = new System.Drawing.Point(107, 126);
            this.cmbRuang.Name = "cmbRuang";
            this.cmbRuang.Size = new System.Drawing.Size(205, 21);
            this.cmbRuang.TabIndex = 9;
            // 
            // cmbKelas
            // 
            this.cmbKelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKelas.FormattingEnabled = true;
            this.cmbKelas.Location = new System.Drawing.Point(107, 99);
            this.cmbKelas.Name = "cmbKelas";
            this.cmbKelas.Size = new System.Drawing.Size(205, 21);
            this.cmbKelas.TabIndex = 8;
            // 
            // cmbMataKuliah
            // 
            this.cmbMataKuliah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMataKuliah.FormattingEnabled = true;
            this.cmbMataKuliah.Location = new System.Drawing.Point(107, 72);
            this.cmbMataKuliah.Name = "cmbMataKuliah";
            this.cmbMataKuliah.Size = new System.Drawing.Size(205, 21);
            this.cmbMataKuliah.TabIndex = 7;
            // 
            // cmbDosen
            // 
            this.cmbDosen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDosen.FormattingEnabled = true;
            this.cmbDosen.Location = new System.Drawing.Point(107, 45);
            this.cmbDosen.Name = "cmbDosen";
            this.cmbDosen.Size = new System.Drawing.Size(205, 21);
            this.cmbDosen.TabIndex = 6;
            // 
            // cmbHari
            // 
            this.cmbHari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHari.FormattingEnabled = true;
            this.cmbHari.Items.AddRange(new object[] {
            "Senin",
            "Selasa",
            "Rabu",
            "Kamis",
            "Jumat",
            "Sabtu"});
            this.cmbHari.Location = new System.Drawing.Point(107, 18);
            this.cmbHari.Name = "cmbHari";
            this.cmbHari.Size = new System.Drawing.Size(205, 21);
            this.cmbHari.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ruang";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Kelas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Mata Kuliah";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Dosen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hari";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(641, 538);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 32);
            this.button6.TabIndex = 3;
            this.button6.Text = "OK";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtWaktuAkhir
            // 
            this.txtWaktuAkhir.Location = new System.Drawing.Point(246, 161);
            this.txtWaktuAkhir.Mask = "00:00:00";
            this.txtWaktuAkhir.Name = "txtWaktuAkhir";
            this.txtWaktuAkhir.Size = new System.Drawing.Size(66, 20);
            this.txtWaktuAkhir.TabIndex = 20;
            this.txtWaktuAkhir.ValidatingType = typeof(System.DateTime);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(174, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Waktu Akhir";
            // 
            // frmJadwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 575);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmJadwal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jadwal Kuliah";
            this.Load += new System.EventHandler(this.frmJadwal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstRuang;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtKeteranganRuang;
        private System.Windows.Forms.TextBox txtKodeRuang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtKeteranganKelas;
        private System.Windows.Forms.TextBox txtKodeKelas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstKelas;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbRuang;
        private System.Windows.Forms.ComboBox cmbKelas;
        private System.Windows.Forms.ComboBox cmbMataKuliah;
        private System.Windows.Forms.ComboBox cmbDosen;
        private System.Windows.Forms.ComboBox cmbHari;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnMataKuliah;
        private System.Windows.Forms.Button btnLihatDosen;
        private System.Windows.Forms.ListView lstJadwal;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.MaskedTextBox txtWaktuMulai;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editJadwalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hapusToolStripMenuItem;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.MaskedTextBox txtWaktuAkhir;
        private System.Windows.Forms.Label label12;
    }
}