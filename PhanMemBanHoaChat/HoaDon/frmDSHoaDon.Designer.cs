namespace PhanMemBanHoaChat.HoaDon
{
    partial class frmDSHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSHoaDon));
            this.btnSaoLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnxoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnsua = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.grbCTHD = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKhoiPhuc = new DevExpress.XtraEditors.SimpleButton();
            this.grbDSHoaDon = new System.Windows.Forms.GroupBox();
            this.txbtimkiem = new System.Windows.Forms.TextBox();
            this.btntimkiem = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grptheongay = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbmahd = new System.Windows.Forms.TextBox();
            this.grbtimkiem = new System.Windows.Forms.GroupBox();
            this.btnThemHD = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.grbCTHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grbDSHoaDon.SuspendLayout();
            this.grptheongay.SuspendLayout();
            this.grbtimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaoLuu.Appearance.Options.UseFont = true;
            this.btnSaoLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaoLuu.ImageOptions.Image")));
            this.btnSaoLuu.Location = new System.Drawing.Point(313, 3);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSaoLuu.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSaoLuu.Size = new System.Drawing.Size(129, 42);
            this.btnSaoLuu.TabIndex = 96;
            this.btnSaoLuu.Text = "Sao lưu";
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Appearance.Options.UseFont = true;
            this.btnxoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.Image")));
            this.btnxoa.Location = new System.Drawing.Point(168, 418);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(119, 54);
            this.btnxoa.TabIndex = 93;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Appearance.Options.UseFont = true;
            this.btnsua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.Image")));
            this.btnsua.Location = new System.Drawing.Point(41, 418);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(110, 54);
            this.btnsua.TabIndex = 94;
            this.btnsua.Text = "Cập nhật";
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(5, 30);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(843, 222);
            this.dataGridView2.TabIndex = 0;
            // 
            // grbCTHD
            // 
            this.grbCTHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCTHD.Controls.Add(this.dataGridView2);
            this.grbCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCTHD.Location = new System.Drawing.Point(330, 316);
            this.grbCTHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCTHD.Name = "grbCTHD";
            this.grbCTHD.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCTHD.Size = new System.Drawing.Size(854, 256);
            this.grbCTHD.TabIndex = 92;
            this.grbCTHD.TabStop = false;
            this.grbCTHD.Text = "Chi tiết hóa đơn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(854, 214);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoiPhuc.Appearance.Options.UseFont = true;
            this.btnKhoiPhuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoiPhuc.ImageOptions.Image")));
            this.btnKhoiPhuc.Location = new System.Drawing.Point(448, 3);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnKhoiPhuc.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnKhoiPhuc.Size = new System.Drawing.Size(129, 42);
            this.btnKhoiPhuc.TabIndex = 95;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click);
            // 
            // grbDSHoaDon
            // 
            this.grbDSHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDSHoaDon.Controls.Add(this.dataGridView1);
            this.grbDSHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDSHoaDon.Location = new System.Drawing.Point(324, 62);
            this.grbDSHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDSHoaDon.Name = "grbDSHoaDon";
            this.grbDSHoaDon.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDSHoaDon.Size = new System.Drawing.Size(866, 250);
            this.grbDSHoaDon.TabIndex = 91;
            this.grbDSHoaDon.TabStop = false;
            this.grbDSHoaDon.Text = "Danh sách hóa đơn";
            // 
            // txbtimkiem
            // 
            this.txbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtimkiem.Location = new System.Drawing.Point(5, 82);
            this.txbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtimkiem.Name = "txbtimkiem";
            this.txbtimkiem.Size = new System.Drawing.Size(217, 34);
            this.txbtimkiem.TabIndex = 1;
            this.txbtimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbtimkiem_KeyDown);
            this.txbtimkiem.Leave += new System.EventHandler(this.txbtimkiem_Leave);
            // 
            // btntimkiem
            // 
            this.btntimkiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btntimkiem.ImageOptions.Image")));
            this.btntimkiem.Location = new System.Drawing.Point(228, 82);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btntimkiem.Size = new System.Drawing.Size(42, 30);
            this.btntimkiem.TabIndex = 58;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã hóa đơn";
            // 
            // grptheongay
            // 
            this.grptheongay.Controls.Add(this.comboBox1);
            this.grptheongay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grptheongay.Location = new System.Drawing.Point(31, 290);
            this.grptheongay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grptheongay.Name = "grptheongay";
            this.grptheongay.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grptheongay.Size = new System.Drawing.Size(287, 123);
            this.grptheongay.TabIndex = 90;
            this.grptheongay.TabStop = false;
            this.grptheongay.Text = "Lọc theo ngày";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(271, 37);
            this.comboBox1.TabIndex = 97;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 88;
            this.label2.Text = "Mã hóa đơn";
            // 
            // txbmahd
            // 
            this.txbmahd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbmahd.Location = new System.Drawing.Point(31, 81);
            this.txbmahd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbmahd.Name = "txbmahd";
            this.txbmahd.Size = new System.Drawing.Size(256, 34);
            this.txbmahd.TabIndex = 87;
            // 
            // grbtimkiem
            // 
            this.grbtimkiem.Controls.Add(this.btntimkiem);
            this.grbtimkiem.Controls.Add(this.label1);
            this.grbtimkiem.Controls.Add(this.txbtimkiem);
            this.grbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbtimkiem.Location = new System.Drawing.Point(31, 147);
            this.grbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Name = "grbtimkiem";
            this.grbtimkiem.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Size = new System.Drawing.Size(287, 128);
            this.grbtimkiem.TabIndex = 89;
            this.grbtimkiem.TabStop = false;
            this.grbtimkiem.Text = "Tìm kiếm";
            // 
            // btnThemHD
            // 
            this.btnThemHD.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHD.Appearance.Options.UseFont = true;
            this.btnThemHD.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemHD.ImageOptions.Image")));
            this.btnThemHD.Location = new System.Drawing.Point(79, 8);
            this.btnThemHD.Name = "btnThemHD";
            this.btnThemHD.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThemHD.Size = new System.Drawing.Size(239, 30);
            this.btnThemHD.TabIndex = 85;
            this.btnThemHD.Text = "Thêm hóa đơn mới";
            this.btnThemHD.Click += new System.EventHandler(this.btnThemHD_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(12, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLamMoi.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLamMoi.Size = new System.Drawing.Size(41, 42);
            this.btnLamMoi.TabIndex = 86;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmDSHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 575);
            this.Controls.Add(this.btnSaoLuu);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.grbCTHD);
            this.Controls.Add(this.btnKhoiPhuc);
            this.Controls.Add(this.grbDSHoaDon);
            this.Controls.Add(this.grptheongay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbmahd);
            this.Controls.Add(this.grbtimkiem);
            this.Controls.Add(this.btnThemHD);
            this.Controls.Add(this.btnLamMoi);
            this.Name = "frmDSHoaDon";
            this.Text = "frmDSHoaDon";
            this.Load += new System.EventHandler(this.frmDSHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.grbCTHD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grbDSHoaDon.ResumeLayout(false);
            this.grptheongay.ResumeLayout(false);
            this.grbtimkiem.ResumeLayout(false);
            this.grbtimkiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSaoLuu;
        private DevExpress.XtraEditors.SimpleButton btnxoa;
        private DevExpress.XtraEditors.SimpleButton btnsua;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox grbCTHD;
        public System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton btnKhoiPhuc;
        private System.Windows.Forms.GroupBox grbDSHoaDon;
        private System.Windows.Forms.TextBox txbtimkiem;
        private DevExpress.XtraEditors.SimpleButton btntimkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grptheongay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbmahd;
        private System.Windows.Forms.GroupBox grbtimkiem;
        private DevExpress.XtraEditors.SimpleButton btnThemHD;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
    }
}