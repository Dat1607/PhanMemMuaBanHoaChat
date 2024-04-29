namespace PhanMemBanHoaChat.HoaDon
{
    partial class FrmTThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTThongKe));
            this.btnChiTiet = new DevExpress.XtraEditors.SimpleButton();
            this.txbmast = new System.Windows.Forms.TextBox();
            this.txbdvb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadDT = new DevExpress.XtraEditors.SimpleButton();
            this.btnXuatHoaDon = new DevExpress.XtraEditors.SimpleButton();
            this.txbtongtt = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txbtthang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbtthue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiTiet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTiet.Appearance.Options.UseFont = true;
            this.btnChiTiet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChiTiet.ImageOptions.Image")));
            this.btnChiTiet.Location = new System.Drawing.Point(857, 493);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(144, 59);
            this.btnChiTiet.TabIndex = 116;
            this.btnChiTiet.Text = "Thống kê";
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // txbmast
            // 
            this.txbmast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbmast.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbmast.Location = new System.Drawing.Point(172, 224);
            this.txbmast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbmast.Name = "txbmast";
            this.txbmast.ReadOnly = true;
            this.txbmast.Size = new System.Drawing.Size(760, 34);
            this.txbmast.TabIndex = 114;
            // 
            // txbdvb
            // 
            this.txbdvb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbdvb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbdvb.Location = new System.Drawing.Point(172, 184);
            this.txbdvb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbdvb.Name = "txbdvb";
            this.txbdvb.ReadOnly = true;
            this.txbdvb.Size = new System.Drawing.Size(760, 34);
            this.txbdvb.TabIndex = 115;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 24);
            this.label10.TabIndex = 112;
            this.label10.Text = "Mã số thuế";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 24);
            this.label8.TabIndex = 113;
            this.label8.Text = "Đơn vị bán hàng";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 376);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(833, 319);
            this.dataGridView1.TabIndex = 107;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(399, 135);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(166, 34);
            this.dateTimePicker2.TabIndex = 105;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 135);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(173, 34);
            this.dateTimePicker1.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(396, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 24);
            this.label3.TabIndex = 109;
            this.label3.Text = "Đến";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 110;
            this.label4.Text = "Kỳ báo cáo";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 24);
            this.label2.TabIndex = 111;
            this.label2.Text = "Từ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 54);
            this.label1.TabIndex = 108;
            this.label1.Text = "BÁO CÁO DOANH THU";
            // 
            // btnLoadDT
            // 
            this.btnLoadDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDT.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDT.Appearance.Options.UseFont = true;
            this.btnLoadDT.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadDT.ImageOptions.Image")));
            this.btnLoadDT.Location = new System.Drawing.Point(857, 422);
            this.btnLoadDT.Name = "btnLoadDT";
            this.btnLoadDT.Size = new System.Drawing.Size(145, 65);
            this.btnLoadDT.TabIndex = 104;
            this.btnLoadDT.Text = "Hiển thị";
            this.btnLoadDT.Click += new System.EventHandler(this.btnLoadDT_Click);
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatHoaDon.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHoaDon.Appearance.Options.UseFont = true;
            this.btnXuatHoaDon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatHoaDon.ImageOptions.Image")));
            this.btnXuatHoaDon.Location = new System.Drawing.Point(857, 344);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(145, 65);
            this.btnXuatHoaDon.TabIndex = 103;
            this.btnXuatHoaDon.Text = "Xuất thống kê";
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // txbtongtt
            // 
            this.txbtongtt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbtongtt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtongtt.Location = new System.Drawing.Point(171, 325);
            this.txbtongtt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtongtt.Name = "txbtongtt";
            this.txbtongtt.ReadOnly = true;
            this.txbtongtt.Size = new System.Drawing.Size(232, 34);
            this.txbtongtt.TabIndex = 118;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(13, 333);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(142, 24);
            this.label18.TabIndex = 117;
            this.label18.Text = "Tổng thành tiền";
            // 
            // txbtthang
            // 
            this.txbtthang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbtthang.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtthang.Location = new System.Drawing.Point(170, 278);
            this.txbtthang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtthang.Name = "txbtthang";
            this.txbtthang.ReadOnly = true;
            this.txbtthang.Size = new System.Drawing.Size(232, 34);
            this.txbtthang.TabIndex = 120;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 24);
            this.label5.TabIndex = 119;
            this.label5.Text = "Tổng tiền hàng";
            // 
            // txbtthue
            // 
            this.txbtthue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbtthue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtthue.Location = new System.Drawing.Point(602, 278);
            this.txbtthue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtthue.Name = "txbtthue";
            this.txbtthue.ReadOnly = true;
            this.txbtthue.Size = new System.Drawing.Size(232, 34);
            this.txbtthue.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(444, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 24);
            this.label6.TabIndex = 121;
            this.label6.Text = "Tổng thuế";
            // 
            // FrmTThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 724);
            this.Controls.Add(this.txbtthue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbtthang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbtongtt);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnChiTiet);
            this.Controls.Add(this.txbmast);
            this.Controls.Add(this.txbdvb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadDT);
            this.Controls.Add(this.btnXuatHoaDon);
            this.Name = "FrmTThongKe";
            this.Text = "FrmTThongKe";
            this.Load += new System.EventHandler(this.FrmTThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnChiTiet;
        private System.Windows.Forms.TextBox txbmast;
        private System.Windows.Forms.TextBox txbdvb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.SimpleButton btnLoadDT;
        public DevExpress.XtraEditors.SimpleButton btnXuatHoaDon;
        private System.Windows.Forms.TextBox txbtongtt;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txbtthang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbtthue;
        private System.Windows.Forms.Label label6;
    }
}