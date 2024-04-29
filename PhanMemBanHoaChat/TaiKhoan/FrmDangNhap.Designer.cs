namespace PhanMemBanHoaChat.TaiKhoan
{
    partial class FrmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangNhap));
            this.btnDangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.lbmatkhau = new System.Windows.Forms.Label();
            this.lbtendangnhap = new System.Windows.Forms.Label();
            this.txbtenDN = new System.Windows.Forms.TextBox();
            this.lbdangnhap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDangNhap.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Appearance.Options.UseFont = true;
            this.btnDangNhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.ImageOptions.Image")));
            this.btnDangNhap.Location = new System.Drawing.Point(265, 232);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(149, 57);
            this.btnDangNhap.TabIndex = 42;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txbMatKhau
            // 
            this.txbMatKhau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMatKhau.Location = new System.Drawing.Point(265, 166);
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.Size = new System.Drawing.Size(285, 34);
            this.txbMatKhau.TabIndex = 41;
            this.txbMatKhau.Text = "@Admin123";
            this.txbMatKhau.UseSystemPasswordChar = true;
            this.txbMatKhau.Enter += new System.EventHandler(this.txbMatKhau_Enter);
            this.txbMatKhau.Leave += new System.EventHandler(this.txbMatKhau_Leave);
            // 
            // lbmatkhau
            // 
            this.lbmatkhau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbmatkhau.AutoSize = true;
            this.lbmatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmatkhau.Location = new System.Drawing.Point(121, 166);
            this.lbmatkhau.Name = "lbmatkhau";
            this.lbmatkhau.Size = new System.Drawing.Size(125, 31);
            this.lbmatkhau.TabIndex = 39;
            this.lbmatkhau.Text = "Mật khẩu";
            // 
            // lbtendangnhap
            // 
            this.lbtendangnhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbtendangnhap.AutoSize = true;
            this.lbtendangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtendangnhap.Location = new System.Drawing.Point(51, 111);
            this.lbtendangnhap.Name = "lbtendangnhap";
            this.lbtendangnhap.Size = new System.Drawing.Size(195, 31);
            this.lbtendangnhap.TabIndex = 40;
            this.lbtendangnhap.Text = "Tên đăng nhập";
            // 
            // txbtenDN
            // 
            this.txbtenDN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbtenDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtenDN.Location = new System.Drawing.Point(265, 111);
            this.txbtenDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtenDN.Name = "txbtenDN";
            this.txbtenDN.Size = new System.Drawing.Size(285, 34);
            this.txbtenDN.TabIndex = 37;
            this.txbtenDN.Text = "admin123";
            this.txbtenDN.TextChanged += new System.EventHandler(this.txbtenDN_TextChanged);
            this.txbtenDN.Enter += new System.EventHandler(this.txbtenDN_Enter);
            this.txbtenDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbtenDN_KeyDown);
            this.txbtenDN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbtenDN_KeyPress);
            this.txbtenDN.Leave += new System.EventHandler(this.txbtenDN_Leave);
            // 
            // lbdangnhap
            // 
            this.lbdangnhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbdangnhap.AutoSize = true;
            this.lbdangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdangnhap.Location = new System.Drawing.Point(245, 30);
            this.lbdangnhap.Name = "lbdangnhap";
            this.lbdangnhap.Size = new System.Drawing.Size(214, 46);
            this.lbdangnhap.TabIndex = 38;
            this.lbdangnhap.Text = "Đăng nhập";
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 329);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txbMatKhau);
            this.Controls.Add(this.lbmatkhau);
            this.Controls.Add(this.lbtendangnhap);
            this.Controls.Add(this.txbtenDN);
            this.Controls.Add(this.lbdangnhap);
            this.Name = "FrmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDangNhap";
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDangNhap;
        private System.Windows.Forms.TextBox txbMatKhau;
        private System.Windows.Forms.Label lbmatkhau;
        private System.Windows.Forms.Label lbtendangnhap;
        private System.Windows.Forms.TextBox txbtenDN;
        private System.Windows.Forms.Label lbdangnhap;
    }
}