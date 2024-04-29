namespace PhanMemBanHoaChat.TaiKhoan
{
    partial class FrmTaoTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaoTaiKhoan));
            this.txbXNMK = new System.Windows.Forms.TextBox();
            this.txbMKDK = new System.Windows.Forms.TextBox();
            this.txbTenDK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbdangky = new System.Windows.Forms.Label();
            this.btnDangKy = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // txbXNMK
            // 
            this.txbXNMK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbXNMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbXNMK.Location = new System.Drawing.Point(321, 280);
            this.txbXNMK.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbXNMK.Name = "txbXNMK";
            this.txbXNMK.PasswordChar = '*';
            this.txbXNMK.Size = new System.Drawing.Size(398, 34);
            this.txbXNMK.TabIndex = 55;
            this.txbXNMK.Enter += new System.EventHandler(this.txbXNMK_Enter);
            this.txbXNMK.Leave += new System.EventHandler(this.txbXNMK_Leave);
            // 
            // txbMKDK
            // 
            this.txbMKDK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbMKDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMKDK.Location = new System.Drawing.Point(321, 208);
            this.txbMKDK.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbMKDK.Name = "txbMKDK";
            this.txbMKDK.PasswordChar = '*';
            this.txbMKDK.Size = new System.Drawing.Size(398, 34);
            this.txbMKDK.TabIndex = 54;
            this.txbMKDK.Enter += new System.EventHandler(this.txbMKDK_Enter);
            this.txbMKDK.Leave += new System.EventHandler(this.txbMKDK_Leave);
            // 
            // txbTenDK
            // 
            this.txbTenDK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbTenDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenDK.Location = new System.Drawing.Point(321, 132);
            this.txbTenDK.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTenDK.Name = "txbTenDK";
            this.txbTenDK.Size = new System.Drawing.Size(398, 34);
            this.txbTenDK.TabIndex = 49;
            this.txbTenDK.Enter += new System.EventHandler(this.txbTenDK_Enter);
            this.txbTenDK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTenDK_KeyPress);
            this.txbTenDK.Leave += new System.EventHandler(this.txbTenDK_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 280);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 29);
            this.label4.TabIndex = 50;
            this.label4.Text = "Xác nhận mật khẩu";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(147, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 29);
            this.label3.TabIndex = 51;
            this.label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 29);
            this.label2.TabIndex = 52;
            this.label2.Text = "Tên đăng nhập";
            // 
            // lbdangky
            // 
            this.lbdangky.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbdangky.AutoSize = true;
            this.lbdangky.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdangky.Location = new System.Drawing.Point(297, 37);
            this.lbdangky.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbdangky.Name = "lbdangky";
            this.lbdangky.Size = new System.Drawing.Size(245, 42);
            this.lbdangky.TabIndex = 53;
            this.lbdangky.Text = "Tạo tài khoản";
            // 
            // btnDangKy
            // 
            this.btnDangKy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDangKy.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.Appearance.Options.UseFont = true;
            this.btnDangKy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangKy.ImageOptions.Image")));
            this.btnDangKy.Location = new System.Drawing.Point(332, 338);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(169, 72);
            this.btnDangKy.TabIndex = 56;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(12, 1);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLamMoi.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLamMoi.Size = new System.Drawing.Size(41, 42);
            this.btnLamMoi.TabIndex = 71;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // FrmTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 441);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.txbXNMK);
            this.Controls.Add(this.txbMKDK);
            this.Controls.Add(this.txbTenDK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbdangky);
            this.Name = "FrmTaoTaiKhoan";
            this.Text = "FrmTaoTaiKhoan";
            this.Load += new System.EventHandler(this.FrmTaoTaiKhoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbXNMK;
        private System.Windows.Forms.TextBox txbMKDK;
        private System.Windows.Forms.TextBox txbTenDK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbdangky;
        private DevExpress.XtraEditors.SimpleButton btnDangKy;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
    }
}