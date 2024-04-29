namespace PhanMemBanHoaChat.DatHang
{
    partial class FrmDSDatHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDSDatHang));
            this.btnSaoLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnxacnhan = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnxoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnsua = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txbtimkiem = new System.Windows.Forms.TextBox();
            this.btntimkiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhoiPhuc = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txbmaddh = new System.Windows.Forms.TextBox();
            this.grptheongay = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grbDSDonDHang = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.grbCTDDH = new System.Windows.Forms.GroupBox();
            this.grbtimkiem = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.grptheongay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grbDSDonDHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.grbCTDDH.SuspendLayout();
            this.grbtimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaoLuu.Appearance.Options.UseFont = true;
            this.btnSaoLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaoLuu.ImageOptions.Image")));
            this.btnSaoLuu.Location = new System.Drawing.Point(66, 12);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSaoLuu.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSaoLuu.Size = new System.Drawing.Size(129, 42);
            this.btnSaoLuu.TabIndex = 98;
            this.btnSaoLuu.Text = "Sao lưu";
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // btnxacnhan
            // 
            this.btnxacnhan.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxacnhan.Appearance.Options.UseFont = true;
            this.btnxacnhan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxacnhan.ImageOptions.Image")));
            this.btnxacnhan.Location = new System.Drawing.Point(45, 530);
            this.btnxacnhan.Name = "btnxacnhan";
            this.btnxacnhan.Size = new System.Drawing.Size(123, 51);
            this.btnxacnhan.TabIndex = 87;
            this.btnxacnhan.Text = "Xác nhận";
            this.btnxacnhan.Click += new System.EventHandler(this.btnxacnhan_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(12, -1);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLamMoi.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLamMoi.Size = new System.Drawing.Size(41, 42);
            this.btnLamMoi.TabIndex = 96;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Appearance.Options.UseFont = true;
            this.btnxoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.Image")));
            this.btnxoa.Location = new System.Drawing.Point(46, 455);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(123, 54);
            this.btnxoa.TabIndex = 94;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Appearance.Options.UseFont = true;
            this.btnsua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.Image")));
            this.btnsua.Location = new System.Drawing.Point(175, 455);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(165, 54);
            this.btnsua.TabIndex = 95;
            this.btnsua.Text = "Xem đơn đặt hàng";
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã đơn đặt hàng hoặc mã KH";
            // 
            // txbtimkiem
            // 
            this.txbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtimkiem.Location = new System.Drawing.Point(5, 82);
            this.txbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtimkiem.Name = "txbtimkiem";
            this.txbtimkiem.Size = new System.Drawing.Size(237, 34);
            this.txbtimkiem.TabIndex = 1;
            this.txbtimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbtimkiem_KeyDown);
            this.txbtimkiem.Leave += new System.EventHandler(this.txbtimkiem_Leave);
            // 
            // btntimkiem
            // 
            this.btntimkiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btntimkiem.ImageOptions.Image")));
            this.btntimkiem.Location = new System.Drawing.Point(245, 82);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btntimkiem.Size = new System.Drawing.Size(42, 30);
            this.btntimkiem.TabIndex = 60;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoiPhuc.Appearance.Options.UseFont = true;
            this.btnKhoiPhuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoiPhuc.ImageOptions.Image")));
            this.btnKhoiPhuc.Location = new System.Drawing.Point(201, 12);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnKhoiPhuc.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnKhoiPhuc.Size = new System.Drawing.Size(129, 42);
            this.btnKhoiPhuc.TabIndex = 97;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 89;
            this.label2.Text = "Mã đơn đặt hàng";
            // 
            // txbmaddh
            // 
            this.txbmaddh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbmaddh.Location = new System.Drawing.Point(53, 90);
            this.txbmaddh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbmaddh.Name = "txbmaddh";
            this.txbmaddh.Size = new System.Drawing.Size(256, 34);
            this.txbmaddh.TabIndex = 88;
            // 
            // grptheongay
            // 
            this.grptheongay.Controls.Add(this.comboBox1);
            this.grptheongay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grptheongay.Location = new System.Drawing.Point(53, 330);
            this.grptheongay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grptheongay.Name = "grptheongay";
            this.grptheongay.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grptheongay.Size = new System.Drawing.Size(287, 120);
            this.grptheongay.TabIndex = 90;
            this.grptheongay.TabStop = false;
            this.grptheongay.Text = "Lọc theo ngày";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(271, 37);
            this.comboBox1.TabIndex = 98;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 31);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(944, 456);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // grbDSDonDHang
            // 
            this.grbDSDonDHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDSDonDHang.Controls.Add(this.dataGridView1);
            this.grbDSDonDHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDSDonDHang.Location = new System.Drawing.Point(365, 34);
            this.grbDSDonDHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDSDonDHang.Name = "grbDSDonDHang";
            this.grbDSDonDHang.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDSDonDHang.Size = new System.Drawing.Size(956, 505);
            this.grbDSDonDHang.TabIndex = 93;
            this.grbDSDonDHang.TabStop = false;
            this.grbDSDonDHang.Text = "Danh sách đơn đặt hàng";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 31);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(944, 165);
            this.dataGridView2.TabIndex = 0;
            // 
            // grbCTDDH
            // 
            this.grbCTDDH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCTDDH.Controls.Add(this.dataGridView2);
            this.grbCTDDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCTDDH.Location = new System.Drawing.Point(365, 539);
            this.grbCTDDH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCTDDH.Name = "grbCTDDH";
            this.grbCTDDH.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCTDDH.Size = new System.Drawing.Size(956, 200);
            this.grbCTDDH.TabIndex = 92;
            this.grbCTDDH.TabStop = false;
            this.grbCTDDH.Text = "Chi tiết đơn đặt hàng";
            // 
            // grbtimkiem
            // 
            this.grbtimkiem.Controls.Add(this.btntimkiem);
            this.grbtimkiem.Controls.Add(this.label1);
            this.grbtimkiem.Controls.Add(this.txbtimkiem);
            this.grbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbtimkiem.Location = new System.Drawing.Point(53, 157);
            this.grbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Name = "grbtimkiem";
            this.grbtimkiem.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Size = new System.Drawing.Size(301, 144);
            this.grbtimkiem.TabIndex = 91;
            this.grbtimkiem.TabStop = false;
            this.grbtimkiem.Text = "Tìm kiếm";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(175, 530);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(165, 51);
            this.simpleButton1.TabIndex = 99;
            this.simpleButton1.Text = "Hủy đơn đặt hàng";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmDSDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 752);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnSaoLuu);
            this.Controls.Add(this.btnxacnhan);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnKhoiPhuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbmaddh);
            this.Controls.Add(this.grptheongay);
            this.Controls.Add(this.grbDSDonDHang);
            this.Controls.Add(this.grbCTDDH);
            this.Controls.Add(this.grbtimkiem);
            this.Name = "FrmDSDatHang";
            this.Text = "FrmDSDatHang";
            this.Load += new System.EventHandler(this.FrmDSDatHang_Load);
            this.grptheongay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grbDSDonDHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.grbCTDDH.ResumeLayout(false);
            this.grbtimkiem.ResumeLayout(false);
            this.grbtimkiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSaoLuu;
        private DevExpress.XtraEditors.SimpleButton btnxacnhan;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
        private DevExpress.XtraEditors.SimpleButton btnxoa;
        private DevExpress.XtraEditors.SimpleButton btnsua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbtimkiem;
        private DevExpress.XtraEditors.SimpleButton btntimkiem;
        private DevExpress.XtraEditors.SimpleButton btnKhoiPhuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbmaddh;
        private System.Windows.Forms.GroupBox grptheongay;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grbDSDonDHang;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox grbCTDDH;
        private System.Windows.Forms.GroupBox grbtimkiem;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}