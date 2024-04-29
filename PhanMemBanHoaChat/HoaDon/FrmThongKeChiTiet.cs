using BLL_DAL;
using BLL_DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.TextEditController.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemBanHoaChat.HoaDon
{
    public partial class FrmThongKeChiTiet : DevExpress.XtraEditors.XtraForm
    {
        BD_ThongKe tk = new BD_ThongKe();
        DateTime begin, end;

        public FrmThongKeChiTiet(DateTime begin, DateTime end)
        {
            InitializeComponent();

            this.begin = begin;
            this.end = end;
            LoadChart(0, begin, end);
            LoadCombobox();
        }
        private void LoadChart(int index, DateTime begin, DateTime end)
        {
            ResetChart();

            if (index == 0)
            {
                chart1.Series.Add("Doanh thu");
                chart1.Series["Doanh thu"].IsValueShownAsLabel = true;

                DateTime begin2 = begin;

                while (tk.DateDiffDay(begin2, end) >= 0)
                {
                    var kq = tk.SumTongThanhTienInDate(begin2);

                    chart1.Series["Doanh thu"].Points.AddXY(begin2.ToString("dd/MM/yyyy"), kq);
                    begin2 = begin2.AddDays(1);
                }

                chart1.Titles.Add("Biểu đồ doanh thu từ " + begin.ToString("dd/MM/yyyy") + " đến " + end.ToString("dd/MM/yyyy"));
            }
            else
            {
                DataTable data = tk.GetThongKeData_SanPham(begin, end);

                chart1.Series.Add("Doanh thu");
                chart1.Series.Add("Số sản phẩm bán được");
                chart1.Series["Doanh thu"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
                chart1.Series["Số sản phẩm bán được"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                chart1.Series["Số sản phẩm bán được"].YValuesPerPoint = 1;

                chart1.Series["Doanh thu"].IsValueShownAsLabel = true;
                chart1.Series["Số sản phẩm bán được"].IsValueShownAsLabel = true;

                chart1.Series["Doanh thu"].Color = Color.Blue;
                chart1.Series["Số sản phẩm bán được"].Color = Color.Green;

                int i = 0;
                while (i < data.Rows.Count)
                {
                    chart1.Series["Doanh thu"].Points.AddXY(data.Rows[i]["TenHangHoa"], data.Rows[i]["ThanhTien"]);
                    chart1.Series["Số sản phẩm bán được"].Points.AddY(data.Rows[i]["SoLuong"]);
                    i++;
                }

                chart1.Titles.Add("Biểu đồ sản phẩm bán ra từ " + begin.ToString("dd/MM/yyyy") + " đến " + end.ToString("dd/MM/yyyy"));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChart(comboBox1.SelectedIndex, begin, end);
        }

        private void FrmThongKeChiTiet_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadCombobox()
        {
            comboBox1.DataSource = new string[] { "Theo ngày", "Theo sản phẩm bán" };
        }
        private void ResetChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
        }
    }
}