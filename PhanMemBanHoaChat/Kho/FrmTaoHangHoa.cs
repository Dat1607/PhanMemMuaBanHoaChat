using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using WinFormsTextBox = System.Windows.Forms.TextBox;
using Microsoft.Win32;

namespace PhanMemBanHoaChat.Kho
{
    public partial class FrmTaoHangHoa : DevExpress.XtraEditors.XtraForm
    {
        BD_HangHoa hh = new BD_HangHoa();
        BD_NSX nsx = new BD_NSX();
        BD_PhanQuyen pq = new BD_PhanQuyen();
        private FrmDSHangHoa frm;
        private string tendn;
        public FrmTaoHangHoa(string tendn)
        {
            InitializeComponent();
            LoadData();
            this.tendn = tendn;
        }
        public FrmTaoHangHoa(FrmDSHangHoa frm)
        {
            InitializeComponent();
            LoadData();
            this.frm = frm;
            DisplayDataFromDataGridView();

        }
        private void DisplayDataFromDataGridView()
        {
            int selectedRowIndex = frm.dataGridView1.CurrentCell.RowIndex;

            if (selectedRowIndex >= 0 && selectedRowIndex < frm.dataGridView1.Rows.Count)
            {
                string mahh = frm.dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString();
                string tenhh = frm.dataGridView1.Rows[selectedRowIndex].Cells[2].Value.ToString();
                string sol = frm.dataGridView1.Rows[selectedRowIndex].Cells[3].Value.ToString();
                string dvt = frm.dataGridView1.Rows[selectedRowIndex].Cells[4].Value.ToString();
                string mansx = frm.dataGridView1.Rows[selectedRowIndex].Cells[5].Value.ToString();
                string xuatsu = frm.dataGridView1.Rows[selectedRowIndex].Cells[6].Value.ToString();
                txbmahh.Text = mahh;
                txbtenhh.Text = tenhh;
                txbSoL.Text = sol;
                txbdvt.Text = dvt;
                txbmansx.Text = mansx;
                txbxuatx.Text = xuatsu;
                txbmahh.ReadOnly = true;
            }
        }

        private void FrmTaoHangHoa_Load(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập tên hàng hóa", txbtenhh);
            SetPlaceholder("Nhập đơn vị tính", txbdvt);
            SetPlaceholder("Nhập xuất xứ", txbxuatx);
            txbmahh.Text = TaoRandomMaHH();
            txbSoL.Text = "0";
            cbbtennsx.Text = "Chọn nhà sản xuất";
            cbbtennsx.ForeColor = Color.Gray;
            stt = LoadSttFromRegistry();

            if (pq.KiemTraQuyen(tendn, "Quản lý"))
            {
            }
            else if (pq.KiemTraQuyen(tendn, "Nhân viên bán hàng"))
            {
                lbdongia.Hide();
                txbdongia.Hide();
            }
            else if (pq.KiemTraQuyen(tendn, "Nhân viên kho"))
            {
                lbdongia.Hide();
                txbdongia.Hide();
            }

        }
        private void SetPlaceholder(string placeholder, WinFormsTextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void RemovePlaceholder(WinFormsTextBox textBox)
        {
            if (textBox.Text == "Nhập tên hàng hóa" || textBox.Text == "Nhập đơn vị tính" || textBox.Text == "Nhập xuất xứ")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void LoadData()
        {
            var mns = nsx.GetDataNSX();

            foreach (var mn in mns)
            {
                cbbtennsx.Items.Add(mn.TenNSX);
            }
            cbbtennsx.SelectedIndex = 0;
        }
        private void cbbtennsx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtennsx.Text == "Chọn mã nhà sản xuất" && cbbtennsx.SelectedIndex == 0)
            {
                cbbtennsx.ForeColor = Color.Gray;
            }
            else
            {
                cbbtennsx.ForeColor = Color.Black;
                string chonGiaTri = cbbtennsx.SelectedItem.ToString();
                string tenmh = nsx.LayMaNSXByTenNSX(chonGiaTri);
                txbmansx.Text = tenmh;
            }
        }

        private void cbbtennsx_DropDown(object sender, EventArgs e)
        {
            if (cbbtennsx.Text == "Chọn mã nhà sản xuất")
            {
                cbbtennsx.Text = "";
            }
        }

        private void cbbtennsx_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbtennsx.Text))
            {
                cbbtennsx.Text = "Chọn mã nhà sản xuất";
                cbbtennsx.ForeColor = Color.Gray;
            }
            else
            {
                cbbtennsx.ForeColor = Color.Black;
            }
        }
        private string TaoRandomMaHH()
        {
            Random random = new Random();
            int randomValue;
            string maHH;
            do
            {
                randomValue = random.Next(0, 1000);
                maHH = "HH" + randomValue.ToString("000");
            } while (KiemTraTrungMaHH(maHH));

            return maHH;
        }

        private bool KiemTraTrungMaHH(string maHH)
        {
            return false;
        }

        private void txbtenhh_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txbtenhh_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbtenhh);
        }

        private void txbtenhh_Leave(object sender, EventArgs e)
        {
            if (txbtenhh.Text.Length < 5 || txbtenhh.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbtenhh.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập tên hàng hóa", txbtenhh);
        }

        private void txbdvt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbdvt_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbdvt);
        }

        private void txbdvt_Leave(object sender, EventArgs e)
        {
            if (txbdvt.Text.Length < 1 || txbdvt.Text.Length > 10)
            {
                MessageBox.Show("Vui lòng nhập từ 1 đến 10 ký tự");
            }
            else if (txbdvt.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập đơn vị tính", txbdvt);
        }

        private void txbxuatx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbxuatx_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbxuatx);
        }

        private void txbxuatx_Leave(object sender, EventArgs e)
        {
            if (txbxuatx.Text.Length < 1 || txbxuatx.Text.Length > 10)
            {
                MessageBox.Show("Vui lòng nhập từ 1 đến 10 ký tự");
            }
            else if (txbdvt.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập xuất xứ", txbxuatx);
        }
        private static int stt = 1;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbmahh.Text) && !string.IsNullOrWhiteSpace(txbtenhh.Text) && !string.IsNullOrWhiteSpace(txbSoL.Text) && !string.IsNullOrWhiteSpace(txbdvt.Text) && !string.IsNullOrWhiteSpace(txbmansx.Text) && !string.IsNullOrWhiteSpace(txbxuatx.Text))
            {
                if (hh.KiemTraMaHH(txbmahh.Text))
                {

                    FrmDSHangHoa frm = new FrmDSHangHoa();
                    double donGia = string.IsNullOrWhiteSpace(txbdongia.Text) ? 0 : double.Parse(txbdongia.Text);
                    hh.ThemHANGHOA(stt, txbmahh.Text, txbtenhh.Text, Convert.ToInt16(txbSoL.Text), txbdvt.Text, txbmansx.Text, txbxuatx.Text, donGia);
                    stt++;
                    frm.dataGridView1.DataSource = hh.GetData();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    txbmahh.Text = TaoRandomMaHH();
                    txbtenhh.Clear();
                    txbdvt.Clear();
                    txbxuatx.Clear();
                    SetPlaceholder("Nhập tên hàng hóa", txbtenhh);
                    SetPlaceholder("Nhập đơn vị tính", txbdvt);
                    SetPlaceholder("Nhập xuất xứ", txbxuatx);
                    cbbtennsx.Text = "Chọn mã nhà sản xuất";
                    cbbtennsx.ForeColor = Color.Gray;
                    txbmansx.Text = "";
                }
                else
                {
                    MessageBox.Show("Đã có hàng hóa này", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbmahh.Text) && !string.IsNullOrWhiteSpace(txbtenhh.Text) && !string.IsNullOrWhiteSpace(txbSoL.Text) && !string.IsNullOrWhiteSpace(txbdvt.Text) && !string.IsNullOrWhiteSpace(txbmansx.Text) && !string.IsNullOrWhiteSpace(txbxuatx.Text))
            {
                FrmDSHangHoa frm = new FrmDSHangHoa();
                hh.SuaHANGHOA(txbmahh.Text, txbtenhh.Text, Convert.ToInt16(txbSoL.Text), txbdvt.Text, txbmansx.Text, txbxuatx.Text, double.Parse(txbdongia.Text));
                frm.dataGridView1.DataSource = hh.GetData();
                frm.Show();
                this.Close();
            }
            else
                MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private int LoadSttFromRegistry()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\YourAppName"))
                {
                    if (key != null)
                    {
                        int loadedStt = (int)key.GetValue("Stt", 1);
                        return loadedStt;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return 1; 
        }

        private void SaveSttToRegistry(int sttToSave)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YourAppName"))
                {
                    key.SetValue("Stt", sttToSave);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void FrmTaoHangHoa_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSttToRegistry(stt);
        }

        private void txbdongia_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txbdongia.Text, out double number))
            {
                txbdongia.Text = number.ToString("N0");
                txbdongia.SelectionStart = txbdongia.Text.Length;
            }
        }
    }
}