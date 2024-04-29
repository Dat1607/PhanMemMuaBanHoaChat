namespace PhanMemBanHoaChat.XuatKho
{
    partial class FrmDSPhieuXuatKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDSPhieuXuatKho));
            this.grbDSPhieuNhap = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grbtimkiem = new System.Windows.Forms.GroupBox();
            this.btntimkiem = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txbtimkiem = new System.Windows.Forms.TextBox();
            this.grbCTPN = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txbmapx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThemKH = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnxoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnsua = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grptheongay = new System.Windows.Forms.GroupBox();
            this.grbDSPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grbtimkiem.SuspendLayout();
            this.grbCTPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.grptheongay.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDSPhieuNhap
            // 
            this.grbDSPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDSPhieuNhap.Controls.Add(this.dataGridView1);
            this.grbDSPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDSPhieuNhap.Location = new System.Drawing.Point(37, 272);
            this.grbDSPhieuNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDSPhieuNhap.Name = "grbDSPhieuNhap";
            this.grbDSPhieuNhap.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDSPhieuNhap.Size = new System.Drawing.Size(1433, 242);
            this.grbDSPhieuNhap.TabIndex = 96;
            this.grbDSPhieuNhap.TabStop = false;
            this.grbDSPhieuNhap.Text = "Danh sách phiếu xuất";
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
            this.dataGridView1.Size = new System.Drawing.Size(1414, 203);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // grbtimkiem
            // 
            this.grbtimkiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grbtimkiem.Controls.Add(this.btntimkiem);
            this.grbtimkiem.Controls.Add(this.label1);
            this.grbtimkiem.Controls.Add(this.txbtimkiem);
            this.grbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbtimkiem.Location = new System.Drawing.Point(403, 79);
            this.grbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Name = "grbtimkiem";
            this.grbtimkiem.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Size = new System.Drawing.Size(519, 138);
            this.grbtimkiem.TabIndex = 94;
            this.grbtimkiem.TabStop = false;
            this.grbtimkiem.Text = "Tìm kiếm";
            // 
            // btntimkiem
            // 
            this.btntimkiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btntimkiem.ImageOptions.Image")));
            this.btntimkiem.Location = new System.Drawing.Point(435, 82);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btntimkiem.Size = new System.Drawing.Size(54, 41);
            this.btntimkiem.TabIndex = 62;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên nhân viên";
            // 
            // txbtimkiem
            // 
            this.txbtimkiem.Location = new System.Drawing.Point(5, 82);
            this.txbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtimkiem.Name = "txbtimkiem";
            this.txbtimkiem.Size = new System.Drawing.Size(424, 30);
            this.txbtimkiem.TabIndex = 1;
            this.txbtimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbtimkiem_KeyDown);
            this.txbtimkiem.Leave += new System.EventHandler(this.txbtimkiem_Leave);
            // 
            // grbCTPN
            // 
            this.grbCTPN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCTPN.Controls.Add(this.dataGridView2);
            this.grbCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCTPN.Location = new System.Drawing.Point(37, 527);
            this.grbCTPN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCTPN.Name = "grbCTPN";
            this.grbCTPN.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCTPN.Size = new System.Drawing.Size(1433, 262);
            this.grbCTPN.TabIndex = 95;
            this.grbCTPN.TabStop = false;
            this.grbCTPN.Text = "Chi tiết phiếu xuất";
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
            this.dataGridView2.Size = new System.Drawing.Size(1415, 219);
            this.dataGridView2.TabIndex = 0;
            // 
            // txbmapx
            // 
            this.txbmapx.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbmapx.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbmapx.Location = new System.Drawing.Point(82, 109);
            this.txbmapx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbmapx.Name = "txbmapx";
            this.txbmapx.Size = new System.Drawing.Size(256, 34);
            this.txbmapx.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 92;
            this.label2.Text = "Mã phiếu xuất";
            // 
            // btnThemKH
            // 
            this.btnThemKH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThemKH.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKH.Appearance.Options.UseFont = true;
            this.btnThemKH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemKH.ImageOptions.Image")));
            this.btnThemKH.Location = new System.Drawing.Point(68, 24);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThemKH.Size = new System.Drawing.Size(270, 30);
            this.btnThemKH.TabIndex = 102;
            this.btnThemKH.Text = "Thêm phiếu xuất kho";
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(6, 1);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLamMoi.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLamMoi.Size = new System.Drawing.Size(41, 42);
            this.btnLamMoi.TabIndex = 103;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnxoa.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Appearance.Options.UseFont = true;
            this.btnxoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.Image")));
            this.btnxoa.Location = new System.Drawing.Point(1338, 154);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(119, 54);
            this.btnxoa.TabIndex = 104;
            this.btnxoa.Text = "Xóa";
            // 
            // btnsua
            // 
            this.btnsua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnsua.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Appearance.Options.UseFont = true;
            this.btnsua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.Image")));
            this.btnsua.Location = new System.Drawing.Point(1338, 79);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(119, 54);
            this.btnsua.TabIndex = 105;
            this.btnsua.Text = "Cập nhật";
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(271, 37);
            this.comboBox1.TabIndex = 99;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            // 
            // grptheongay
            // 
            this.grptheongay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grptheongay.Controls.Add(this.comboBox1);
            this.grptheongay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grptheongay.Location = new System.Drawing.Point(985, 69);
            this.grptheongay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grptheongay.Name = "grptheongay";
            this.grptheongay.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grptheongay.Size = new System.Drawing.Size(287, 148);
            this.grptheongay.TabIndex = 93;
            this.grptheongay.TabStop = false;
            this.grptheongay.Text = "Lọc theo ngày";
            // 
            // FrmDSPhieuXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1510, 807);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnThemKH);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.grbDSPhieuNhap);
            this.Controls.Add(this.grbtimkiem);
            this.Controls.Add(this.grbCTPN);
            this.Controls.Add(this.txbmapx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grptheongay);
            this.Name = "FrmDSPhieuXuatKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDSPhieuXuatKho";
            this.Load += new System.EventHandler(this.FrmDSPhieuXuatKho_Load);
            this.grbDSPhieuNhap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grbtimkiem.ResumeLayout(false);
            this.grbtimkiem.PerformLayout();
            this.grbCTPN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.grptheongay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDSPhieuNhap;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grbtimkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbtimkiem;
        private System.Windows.Forms.GroupBox grbCTPN;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txbmapx;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnThemKH;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
        private DevExpress.XtraEditors.SimpleButton btnxoa;
        private DevExpress.XtraEditors.SimpleButton btnsua;
        private DevExpress.XtraEditors.SimpleButton btntimkiem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox grptheongay;
    }
}