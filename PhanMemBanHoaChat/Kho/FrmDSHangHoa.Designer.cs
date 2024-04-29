namespace PhanMemBanHoaChat.Kho
{
    partial class FrmDSHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDSHangHoa));
            this.grbtimkiem = new System.Windows.Forms.GroupBox();
            this.btntimkiem = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txbtimkiem = new System.Windows.Forms.TextBox();
            this.btnThemKH = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnxoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnsua = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txbmahh = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSaoLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhoiPhuc = new DevExpress.XtraEditors.SimpleButton();
            this.btnNhapKho = new DevExpress.XtraEditors.SimpleButton();
            this.btnXuatKho = new DevExpress.XtraEditors.SimpleButton();
            this.grbtimkiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbtimkiem
            // 
            this.grbtimkiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grbtimkiem.Controls.Add(this.btntimkiem);
            this.grbtimkiem.Controls.Add(this.label1);
            this.grbtimkiem.Controls.Add(this.txbtimkiem);
            this.grbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbtimkiem.Location = new System.Drawing.Point(415, 45);
            this.grbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Name = "grbtimkiem";
            this.grbtimkiem.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Size = new System.Drawing.Size(415, 138);
            this.grbtimkiem.TabIndex = 85;
            this.grbtimkiem.TabStop = false;
            this.grbtimkiem.Text = "Tìm kiếm";
            // 
            // btntimkiem
            // 
            this.btntimkiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btntimkiem.ImageOptions.Image")));
            this.btntimkiem.Location = new System.Drawing.Point(346, 73);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btntimkiem.Size = new System.Drawing.Size(54, 41);
            this.btntimkiem.TabIndex = 61;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên hàng hóa và xuất xứ";
            // 
            // txbtimkiem
            // 
            this.txbtimkiem.Location = new System.Drawing.Point(5, 82);
            this.txbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtimkiem.Name = "txbtimkiem";
            this.txbtimkiem.Size = new System.Drawing.Size(335, 30);
            this.txbtimkiem.TabIndex = 1;
            this.txbtimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbtimkiem_KeyDown);
            this.txbtimkiem.Leave += new System.EventHandler(this.txbtimkiem_Leave);
            // 
            // btnThemKH
            // 
            this.btnThemKH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThemKH.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKH.Appearance.Options.UseFont = true;
            this.btnThemKH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemKH.ImageOptions.Image")));
            this.btnThemKH.Location = new System.Drawing.Point(70, 5);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThemKH.Size = new System.Drawing.Size(205, 30);
            this.btnThemKH.TabIndex = 88;
            this.btnThemKH.Text = "Thêm hàng hóa";
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(2, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLamMoi.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLamMoi.Size = new System.Drawing.Size(41, 42);
            this.btnLamMoi.TabIndex = 89;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnxoa.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Appearance.Options.UseFont = true;
            this.btnxoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.Image")));
            this.btnxoa.Location = new System.Drawing.Point(207, 157);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(119, 54);
            this.btnxoa.TabIndex = 86;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnsua.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Appearance.Options.UseFont = true;
            this.btnsua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.Image")));
            this.btnsua.Location = new System.Drawing.Point(70, 157);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(110, 54);
            this.btnsua.TabIndex = 87;
            this.btnsua.Text = "Cập nhật";
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 83;
            this.label2.Text = "Mã hàng hóa";
            // 
            // txbmahh
            // 
            this.txbmahh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbmahh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbmahh.Location = new System.Drawing.Point(70, 105);
            this.txbmahh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbmahh.Name = "txbmahh";
            this.txbmahh.Size = new System.Drawing.Size(256, 34);
            this.txbmahh.TabIndex = 82;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 251);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1226, 389);
            this.dataGridView1.TabIndex = 81;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaoLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaoLuu.Appearance.Options.UseFont = true;
            this.btnSaoLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaoLuu.ImageOptions.Image")));
            this.btnSaoLuu.Location = new System.Drawing.Point(409, -7);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSaoLuu.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSaoLuu.Size = new System.Drawing.Size(129, 42);
            this.btnSaoLuu.TabIndex = 100;
            this.btnSaoLuu.Text = "Sao lưu";
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click_1);
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKhoiPhuc.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoiPhuc.Appearance.Options.UseFont = true;
            this.btnKhoiPhuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoiPhuc.ImageOptions.Image")));
            this.btnKhoiPhuc.Location = new System.Drawing.Point(544, -7);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnKhoiPhuc.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnKhoiPhuc.Size = new System.Drawing.Size(129, 42);
            this.btnKhoiPhuc.TabIndex = 99;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click_1);
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNhapKho.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapKho.Appearance.Options.UseFont = true;
            this.btnNhapKho.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapKho.ImageOptions.Image")));
            this.btnNhapKho.Location = new System.Drawing.Point(896, 59);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(166, 45);
            this.btnNhapKho.TabIndex = 101;
            this.btnNhapKho.Text = "Yêu cầu nhập kho";
            this.btnNhapKho.Click += new System.EventHandler(this.btnNhapKho_Click);
            // 
            // btnXuatKho
            // 
            this.btnXuatKho.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXuatKho.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatKho.Appearance.Options.UseFont = true;
            this.btnXuatKho.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatKho.ImageOptions.Image")));
            this.btnXuatKho.Location = new System.Drawing.Point(896, 124);
            this.btnXuatKho.Name = "btnXuatKho";
            this.btnXuatKho.Size = new System.Drawing.Size(166, 45);
            this.btnXuatKho.TabIndex = 101;
            this.btnXuatKho.Text = "Yêu cầu xuất kho";
            this.btnXuatKho.Click += new System.EventHandler(this.btnXuatKho_Click);
            // 
            // FrmDSHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 662);
            this.Controls.Add(this.btnXuatKho);
            this.Controls.Add(this.btnNhapKho);
            this.Controls.Add(this.btnSaoLuu);
            this.Controls.Add(this.btnKhoiPhuc);
            this.Controls.Add(this.grbtimkiem);
            this.Controls.Add(this.btnThemKH);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbmahh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmDSHangHoa";
            this.Text = "FrmDSHangHoa";
            this.Load += new System.EventHandler(this.FrmDSHangHoa_Load);
            this.grbtimkiem.ResumeLayout(false);
            this.grbtimkiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbtimkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbtimkiem;
        private DevExpress.XtraEditors.SimpleButton btnThemKH;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
        private DevExpress.XtraEditors.SimpleButton btnxoa;
        private DevExpress.XtraEditors.SimpleButton btnsua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbmahh;
        public System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton btntimkiem;
        private DevExpress.XtraEditors.SimpleButton btnSaoLuu;
        private DevExpress.XtraEditors.SimpleButton btnKhoiPhuc;
        private DevExpress.XtraEditors.SimpleButton btnNhapKho;
        private DevExpress.XtraEditors.SimpleButton btnXuatKho;
    }
}