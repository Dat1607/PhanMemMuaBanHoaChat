namespace PhanMemBanHoaChat.DoiTac
{
    partial class FrmDSNhaCC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDSNhaCC));
            this.btnKhoiPhuc = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaoLuu = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txbmancc = new System.Windows.Forms.TextBox();
            this.grbtimkiem = new System.Windows.Forms.GroupBox();
            this.btnxoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnsua = new DevExpress.XtraEditors.SimpleButton();
            this.btntimkiem = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txbtimkiem = new System.Windows.Forms.TextBox();
            this.btnThemNCC = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grbtimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoiPhuc.Appearance.Options.UseFont = true;
            this.btnKhoiPhuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoiPhuc.ImageOptions.Image")));
            this.btnKhoiPhuc.Location = new System.Drawing.Point(475, 14);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnKhoiPhuc.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnKhoiPhuc.Size = new System.Drawing.Size(129, 42);
            this.btnKhoiPhuc.TabIndex = 91;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click);
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaoLuu.Appearance.Options.UseFont = true;
            this.btnSaoLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaoLuu.ImageOptions.Image")));
            this.btnSaoLuu.Location = new System.Drawing.Point(340, 14);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSaoLuu.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSaoLuu.Size = new System.Drawing.Size(129, 42);
            this.btnSaoLuu.TabIndex = 92;
            this.btnSaoLuu.Text = "Sao lưu";
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(348, 72);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(547, 397);
            this.dataGridView1.TabIndex = 90;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 88;
            this.label2.Text = "Mã NCC";
            // 
            // txbmancc
            // 
            this.txbmancc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbmancc.Location = new System.Drawing.Point(25, 112);
            this.txbmancc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbmancc.Name = "txbmancc";
            this.txbmancc.Size = new System.Drawing.Size(256, 34);
            this.txbmancc.TabIndex = 87;
            // 
            // grbtimkiem
            // 
            this.grbtimkiem.Controls.Add(this.btnxoa);
            this.grbtimkiem.Controls.Add(this.btnsua);
            this.grbtimkiem.Controls.Add(this.btntimkiem);
            this.grbtimkiem.Controls.Add(this.label1);
            this.grbtimkiem.Controls.Add(this.txbtimkiem);
            this.grbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbtimkiem.Location = new System.Drawing.Point(24, 212);
            this.grbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Name = "grbtimkiem";
            this.grbtimkiem.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbtimkiem.Size = new System.Drawing.Size(287, 236);
            this.grbtimkiem.TabIndex = 89;
            this.grbtimkiem.TabStop = false;
            this.grbtimkiem.Text = "Tìm kiếm";
            // 
            // btnxoa
            // 
            this.btnxoa.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Appearance.Options.UseFont = true;
            this.btnxoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.Image")));
            this.btnxoa.Location = new System.Drawing.Point(138, 156);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(119, 54);
            this.btnxoa.TabIndex = 75;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Appearance.Options.UseFont = true;
            this.btnsua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.Image")));
            this.btnsua.Location = new System.Drawing.Point(11, 156);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(110, 54);
            this.btnsua.TabIndex = 76;
            this.btnsua.Text = "Cập nhật";
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btntimkiem.ImageOptions.Image")));
            this.btntimkiem.Location = new System.Drawing.Point(239, 82);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btntimkiem.Size = new System.Drawing.Size(42, 30);
            this.btntimkiem.TabIndex = 60;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã và tên NCC";
            // 
            // txbtimkiem
            // 
            this.txbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtimkiem.Location = new System.Drawing.Point(5, 82);
            this.txbtimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtimkiem.Name = "txbtimkiem";
            this.txbtimkiem.Size = new System.Drawing.Size(228, 34);
            this.txbtimkiem.TabIndex = 1;
            this.txbtimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbtimkiem_KeyDown);
            this.txbtimkiem.Leave += new System.EventHandler(this.txbtimkiem_Leave);
            // 
            // btnThemNCC
            // 
            this.btnThemNCC.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNCC.Appearance.Options.UseFont = true;
            this.btnThemNCC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNCC.ImageOptions.Image")));
            this.btnThemNCC.Location = new System.Drawing.Point(69, 20);
            this.btnThemNCC.Name = "btnThemNCC";
            this.btnThemNCC.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThemNCC.Size = new System.Drawing.Size(148, 30);
            this.btnThemNCC.TabIndex = 85;
            this.btnThemNCC.Text = "Thêm NCC";
            this.btnThemNCC.Click += new System.EventHandler(this.btnThemNCC_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(22, 14);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLamMoi.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLamMoi.Size = new System.Drawing.Size(41, 42);
            this.btnLamMoi.TabIndex = 86;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // FrmDSNhaCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 483);
            this.Controls.Add(this.btnKhoiPhuc);
            this.Controls.Add(this.btnSaoLuu);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbmancc);
            this.Controls.Add(this.grbtimkiem);
            this.Controls.Add(this.btnThemNCC);
            this.Controls.Add(this.btnLamMoi);
            this.Name = "FrmDSNhaCC";
            this.Text = "FrmDSNhaCC";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grbtimkiem.ResumeLayout(false);
            this.grbtimkiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnKhoiPhuc;
        private DevExpress.XtraEditors.SimpleButton btnSaoLuu;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbmancc;
        private System.Windows.Forms.GroupBox grbtimkiem;
        private DevExpress.XtraEditors.SimpleButton btnxoa;
        private DevExpress.XtraEditors.SimpleButton btnsua;
        private DevExpress.XtraEditors.SimpleButton btntimkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbtimkiem;
        private DevExpress.XtraEditors.SimpleButton btnThemNCC;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
    }
}