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
    public partial class FrmTaoNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        BD_NhaCC qlncc = new BD_NhaCC();
        private FrmDSNhaCC frm;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmTaoNhaCungCap()
        {
            InitializeComponent();
            InitializeUI();
        }
        public FrmTaoNhaCungCap(FrmDSNhaCC frm)
        {
            InitializeComponent();
            this.frm = frm;
            DisplayDataFromDataGridView();
            InitializeUI();
        }
        private void InitializeUI()
        {
            autoCompleteCollection = new AutoCompleteStringCollection();
            //txbtenncc
            txbtenncc.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbtenncc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbtenncc.AutoCompleteCustomSource = autoCompleteCollection;
            //txbdiachincc
            txbdiachincc.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbdiachincc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbdiachincc.AutoCompleteCustomSource = autoCompleteCollection;
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
                txbtenncc.AutoCompleteCustomSource = autoCompleteCollection;
                txbdiachincc.AutoCompleteCustomSource = autoCompleteCollection;

            }
        }
        private void DisplayDataFromDataGridView()
        {
            int selectedRowIndex = frm.dataGridView1.CurrentCell.RowIndex;

            if (selectedRowIndex >= 0 && selectedRowIndex < frm.dataGridView1.Rows.Count)
            {
                string mancc = frm.dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                string tenncc = frm.dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString();
                string dcncc = frm.dataGridView1.Rows[selectedRowIndex].Cells[2].Value.ToString();
                txbmancc.Text = mancc;
                txbtenncc.Text = tenncc;
                txbdiachincc.Text = dcncc;
                btntaomncc.Hide();
                txbmancc.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbmancc.Text) && !string.IsNullOrWhiteSpace(txbtenncc.Text) && !string.IsNullOrWhiteSpace(txbdiachincc.Text))
            {
                if (qlncc.KiemTraMaNCC(txbmancc.Text))
                {
                    FrmDSNhaCC frm = new FrmDSNhaCC();
                    qlncc.ThemNCC(txbmancc.Text, txbtenncc.Text, txbdiachincc.Text);
                    frm.dataGridView1.DataSource = qlncc.GetData();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    txbmancc.Clear();
                    txbtenncc.Clear();
                    txbdiachincc.Clear();
                    SetPlaceholder("Nhập tên nhà cung cấp", txbtenncc);
                    SetPlaceholder("Nhập địa chỉ nhà cung cấp", txbdiachincc);
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
            if (!string.IsNullOrWhiteSpace(txbmancc.Text) && !string.IsNullOrWhiteSpace(txbtenncc.Text) && !string.IsNullOrWhiteSpace(txbdiachincc.Text))
            {
                FrmDSNhaCC frm = new FrmDSNhaCC();
                qlncc.SuaNCC(txbmancc.Text, txbtenncc.Text, txbdiachincc.Text);
                frm.dataGridView1.DataSource = qlncc.GetData();
                this.Close();
            }
            else
                MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string TaoRandomMaNCC()
        {
            Random random = new Random();
            int randomValue;
            string maNCC;
            do
            {
                randomValue = random.Next(0, 1000);
                maNCC = "NCC" + randomValue.ToString("000");
            } while (KiemTraTrungMaNCC(maNCC));

            return maNCC;
        }

        private bool KiemTraTrungMaNCC(string maNCC)
        {
            return false;
        }

        private void btntaomncc_Click(object sender, EventArgs e)
        {
            txbmancc.Text = TaoRandomMaNCC();
        }

        private void FrmTaoNhaCungCap_Load(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập tên nhà cung cấp", txbtenncc);
            SetPlaceholder("Nhập địa chỉ nhà cung cấp", txbdiachincc);
        }

        private void txbtenncc_Leave(object sender, EventArgs e)
        {
            if (txbtenncc.Text.Length < 5 || txbtenncc.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbtenncc.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }

            if (!string.IsNullOrWhiteSpace(txbtenncc.Text))
            {
                if (!autoCompleteCollection.Contains(txbtenncc.Text))
                {
                    autoCompleteCollection.Add(txbtenncc.Text);
                }
                SaveAutoCompleteData();
                txbtenncc.AutoCompleteCustomSource = autoCompleteCollection;
            }
            SetPlaceholder("Nhập tên nhà cung cấp", txbtenncc);
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
            if (textBox.Text == "Nhập tên nhà cung cấp" || textBox.Text == "Nhập địa chỉ nhà cung cấp")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txbtenncc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbdiachincc_Leave(object sender, EventArgs e)
        {
            if (txbdiachincc.Text.Length < 5 || txbdiachincc.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbdiachincc.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }

            if (!string.IsNullOrWhiteSpace(txbdiachincc.Text))
            {
                if (!autoCompleteCollection.Contains(txbdiachincc.Text))
                {
                    autoCompleteCollection.Add(txbdiachincc.Text);
                }
                SaveAutoCompleteData();
                txbdiachincc.AutoCompleteCustomSource = autoCompleteCollection;
            }
            SetPlaceholder("Nhập địa chỉ nhà cung cấp", txbdiachincc);
        }

        private void txbtenncc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txbtenncc.Text) && !autoCompleteCollection.Contains(txbtenncc.Text))
                {
                    autoCompleteCollection.Add(txbtenncc.Text);
                }
                SaveAutoCompleteData();
                txbtenncc.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbdiachincc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txbdiachincc.Text) && !autoCompleteCollection.Contains(txbdiachincc.Text))
                {
                    autoCompleteCollection.Add(txbdiachincc.Text);
                }
                SaveAutoCompleteData();
                txbdiachincc.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbtenncc_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbtenncc);
        }

        private void txbdiachincc_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbdiachincc);
        }
    }
}