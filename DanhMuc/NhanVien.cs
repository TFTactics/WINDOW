using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.NET.DanhMuc
{
    public partial class NhanVien : Form
    {
        string strConnectionString = "Data Source=NGUIT;  Initial Catalog=QuanLyBanHang; Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daNhanVien = null;
        DataTable dtNhanVien = null;

        public NhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!txtMaNV.Text.Trim().Equals(""))
            {
                // Mở kết nối
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                // Thêm dữ liệu
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = "Insert Into NhanVien Values('" +
                     txtMaNV.Text.Trim() + "',N'" +
                     txtHoLot.Text.Trim()  + "',N'" + 
                     txtTen.Text  + "','" +
                     checkMale.Checked  + "',N'" + 
                     dtNgayNV.Value.ToString("yyyy-MM-dd")  + "',N'" +
                     txtDiaChi.Text + "','" + 
                     txtSDT.Text
                        + "','" + txtHinh.Text + "')";
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
                // Đóng kết nối
                conn.Close();
            }
            else
            {
                MessageBox.Show("Thieu Du Lieu");
                txtMaNV.Focus();
            }
        }

        void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daNhanVien = new SqlDataAdapter("SELECT * FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                daNhanVien.Fill(dtNhanVien);
                dgvNhanVien.DataSource = dtNhanVien;
            }
            catch (SqlException)
            {
                MessageBox.Show("FAIL");
            }
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dtNgayNV.Value.ToString("yyyy-MM-dd"));
        }
    }
}
