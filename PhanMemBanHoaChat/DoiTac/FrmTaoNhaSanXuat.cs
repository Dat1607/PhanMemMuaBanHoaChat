using BLL_DAL;
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

namespace PhanMemBanHoaChat.DoiTac
{
    public partial class FrmTaoNhaSanXuat : DevExpress.XtraEditors.XtraForm
    {
        BD_NSX qlnsx = new BD_NSX();
        private FrmDSNhaSanXuat frm;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmTaoNhaSanXuat()
        {
            InitializeComponent();
            InitializeUI();
        }
        public FrmTaoNhaSanXuat(FrmDSNhaSanXuat frm)
        {
            InitializeComponent();
            this.frm = frm;
            DisplayDataFromDataGridView();
            InitializeUI();

        }
        private void InitializeUI()
        {
            autoCompleteCollection = new AutoCompleteStringCollection();
            //txbtennsx
            txbtennsx.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbtennsx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbtennsx.AutoCompleteCustomSource = autoCompleteCollection;
            //txbdiachinsx
            txbdiachinsx.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbdiachinsx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbdiachinsx.AutoCompleteCustomSource = autoCompleteCollection;
            LoadAutoCompleteData();
        }
        private void SaveAutoCompleteData()
        {
            Properties.Settings.Default.AutoCompleteData = autoCompleteCollection;
            Properties.Settings.Default.Save();
        }
        private void LoadAutoCompleteData()
        {
            if (Properties.Settings.Default.AutoCompleteData != null)
            {
                autoCompleteCollection = Properties.Settings.Default.AutoCompleteData;
                txbtennsx.AutoCompleteCustomSource = autoCompleteCollection;
                txbdiachinsx.AutoCompleteCustomSource = autoCompleteCollection;

            }
        }
        private void DisplayDataFromDataGridView()
        {
            int selectedRowIndex = frm.dataGridView1.CurrentCell.RowIndex;

            if (selectedRowIndex >= 0 && selectedRowIndex < frm.dataGridView1.Rows.Count)
            {
                string mansx = frm.dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                string tennsx = frm.dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString();
                string dcnsx = frm.dataGridView1.Rows[selectedRowIndex].Cells[2].Value.ToString();
                txbmansx.Text = mansx;
                txbtennsx.Text = tennsx;
                txbdiachinsx.Text = dcnsx;
                btntaomansx.Text = dcnsx;
                txbmansx.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbmansx.Text) && !string.IsNullOrWhiteSpace(txbtennsx.Text) && !string.IsNullOrWhiteSpace(txbdiachinsx.Text))
            {
                if (qlnsx.KiemTraMaNSX(txbmansx.Text))
                {
                    FrmDSNhaSanXuat frm = new FrmDSNhaSanXuat();
                    qlnsx.ThemNSX(txbmansx.Text, txbtennsx.Text, txbdiachinsx.Text);
                    frm.dataGridView1.DataSource = qlnsx.GetData();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    txbmansx.Clear();
                    txbtennsx.Clear();
                    txbdiachinsx.Clear();
                    SetPlaceholder("Nhập tên nhà sản xuất", txbtennsx);
                    SetPlaceholder("Nhập địa chỉ nhà sản xuất", txbdiachinsx);
                }
                else
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbmansx.Text) && !string.IsNullOrWhiteSpace(txbtennsx.Text) && !string.IsNullOrWhiteSpace(txbdiachinsx.Text))
            {
                FrmDSNhaSanXuat frm = new FrmDSNhaSanXuat();
                qlnsx.SuaNSX(txbmansx.Text, txbtennsx.Text, txbdiachinsx.Text);
                frm.dataGridView1.DataSource = qlnsx.GetData();
                this.Close();
            }
            else
                MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string TaoRandomMaNSX()
        {
            Random random = new Random();
            int randomValue;
            string maNSX;
            do
            {
                randomValue = random.Next(0, 1000);
                maNSX = "NSX" + randomValue.ToString("000");
            } while (KiemTraTrungMaNSX(maNSX));

            return maNSX;
        }

        private bool KiemTraTrungMaNSX(string maNSX)
        {
            return false;
        }

        private void btntaomansx_Click(object sender, EventArgs e)
        {
            txbmansx.Text = TaoRandomMaNSX();
        }

        private void FrmTaoNhaSanXuat_Load(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập tên nhà sản xuất", txbtennsx);
            SetPlaceholder("Nhập địa chỉ nhà sản xuất", txbdiachinsx);
        }

        private void txbtennsx_Leave(object sender, EventArgs e)
        {
            if (txbtennsx.Text.Length < 5 || txbtennsx.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbtennsx.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }

            if (!string.IsNullOrWhiteSpace(txbtennsx.Text))
            {
                if (!autoCompleteCollection.Contains(txbtennsx.Text))
                {
                    autoCompleteCollection.Add(txbtennsx.Text);
                }
                SaveAutoCompleteData();
                txbtennsx.AutoCompleteCustomSource = autoCompleteCollection;
            }
            SetPlaceholder("Nhập tên nhà sản xuất", txbtennsx);
        }

        private void txbtennsx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbdiachinsx_Leave(object sender, EventArgs e)
        {
            if (txbdiachinsx.Text.Length < 5 || txbdiachinsx.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbdiachinsx.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            //
            if (!string.IsNullOrWhiteSpace(txbdiachinsx.Text))
            {
                if (!autoCompleteCollection.Contains(txbdiachinsx.Text))
                {
                    autoCompleteCollection.Add(txbdiachinsx.Text);
                }
                SaveAutoCompleteData();
                txbdiachinsx.AutoCompleteCustomSource = autoCompleteCollection;
            }
            SetPlaceholder("Nhập địa chỉ nhà sản xuất", txbdiachinsx);
        }

        private void txbtennsx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txbtennsx.Text) && !autoCompleteCollection.Contains(txbtennsx.Text))
                {
                    autoCompleteCollection.Add(txbtennsx.Text);
                }
                SaveAutoCompleteData();
                txbtennsx.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbdiachinsx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txbdiachinsx.Text) && !autoCompleteCollection.Contains(txbdiachinsx.Text))
                {
                    autoCompleteCollection.Add(txbdiachinsx.Text);
                }
                SaveAutoCompleteData();
                txbdiachinsx.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbtennsx_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbtennsx);
        }

        private void txbdiachinsx_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbdiachinsx);
        }
        private void SetPlaceholder(string placeholder, TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void RemovePlaceholder(TextBox textBox)
        {
            if (textBox.Text == "Nhập tên nhà sản xuất" || textBox.Text == "Nhập địa chỉ nhà sản xuất")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}