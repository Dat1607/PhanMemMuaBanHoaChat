namespace PhanMemBanHoaChat.HoaDon
{
    partial class FrmCongNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCongNo));
            this.btnLoadCN = new DevExpress.XtraEditors.SimpleButton();
            this.btnXuatHoaDon = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.cbbmastkh = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txbtenkh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadCN
            // 
            this.btnLoadCN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadCN.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCN.Appearance.Options.UseFont = true;
            this.btnLoadCN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadCN.ImageOptions.Image")));
            this.btnLoadCN.Location = new System.Drawing.Point(704, 271);
            this.btnLoadCN.Name = "btnLoadCN";
            this.btnLoadCN.Size = new System.Drawing.Size(145, 65);
            this.btnLoadCN.TabIndex = 90;
            this.btnLoadCN.Text = "Hiển thị";
            this.btnLoadCN.Click += new System.EventHandler(this.btnLoadCN_Click);
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXuatHoaDon.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHoaDon.Appearance.Options.UseFont = true;
            this.btnXuatHoaDon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatHoaDon.ImageOptions.Image")));
            this.btnXuatHoaDon.Location = new System.Drawing.Point(704, 193);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(145, 65);
            this.btnXuatHoaDon.TabIndex = 89;
            this.btnXuatHoaDon.Text = "Xuất công nợ";
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(15, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLamMoi.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLamMoi.Size = new System.Drawing.Size(41, 42);
            this.btnLamMoi.TabIndex = 88;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // cbbmastkh
            // 
            this.cbbmastkh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbbmastkh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbmastkh.FormattingEnabled = true;
            this.cbbmastkh.Location = new System.Drawing.Point(248, 225);
            this.cbbmastkh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbmastkh.Name = "cbbmastkh";
            this.cbbmastkh.Size = new System.Drawing.Size(423, 37);
            this.cbbmastkh.TabIndex = 87;
            this.cbbmastkh.DropDown += new System.EventHandler(this.cbbmastkh_DropDown);
            this.cbbmastkh.SelectedIndexChanged += new System.EventHandler(this.cbbmastkh_SelectedIndexChanged);
            this.cbbmastkh.DropDownClosed += new System.EventHandler(this.cbbmastkh_DropDownClosed);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(242, 271);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(259, 30);
            this.label17.TabIndex = 83;
            this.label17.Text = "Mã số thuế khách hàng";
            // 
            // txbtenkh
            // 
            this.txbtenkh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbtenkh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtenkh.Location = new System.Drawing.Point(248, 303);
            this.txbtenkh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtenkh.Name = "txbtenkh";
            this.txbtenkh.ReadOnly = true;
            this.txbtenkh.Size = new System.Drawing.Size(222, 34);
            this.txbtenkh.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 84;
            this.label2.Text = "Đến ngày";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(242, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(185, 30);
            this.label14.TabIndex = 85;
            this.label14.Text = "Tên khách hàng";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 54);
            this.label1.TabIndex = 82;
            this.label1.Text = "BẢNG CÔNG NỢ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 365);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(863, 363);
            this.dataGridView1.TabIndex = 81;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(247, 145);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(223, 34);
            this.dateTimePicker1.TabIndex = 80;
            // 
            // FrmCongNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 759);
            this.Controls.Add(this.btnLoadCN);
            this.Controls.Add(this.btnXuatHoaDon);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.cbbmastkh);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txbtenkh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "FrmCongNo";
            this.Text = "FrmCongNo";
            this.Load += new System.EventHandler(this.FrmCongNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnLoadCN;
        public DevExpress.XtraEditors.SimpleButton btnXuatHoaDon;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
        public System.Windows.Forms.ComboBox cbbmastkh;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txbtenkh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}