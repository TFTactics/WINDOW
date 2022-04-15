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
    public partial class SanPham : Form
    {
        string strConnectionString = "Data Source=NGUIT;  Initial Catalog=QuanLyBanHang; Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daSanPham = null;
        DataTable dtSanPham = null;


        void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daSanPham = new SqlDataAdapter("SELECT * FROM SANPHAM", conn);
                dtSanPham = new DataTable();
                daSanPham.Fill(dtSanPham);
                dgvSanPham.DataSource = dtSanPham;
            }
            catch (SqlException)
            {
                MessageBox.Show("FAIL");
            }
        }

        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!txtMaSP.Text.Trim().Equals(""))
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
                    cmd.CommandText = "Insert Into SanPham Values('" +
                     txtMaSP.Text.Trim() + "',N'" +
                     txtTenSP.Text + "',N'" + txtDonVi.Text + "','" + txtDonGia.Text.Trim() + "','" + txtHinh.Text + "')";
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
                MessageBox.Show("Thieu Du Kien");
                txtMaSP.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK)
            {
                // Mở kết nối
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lấy thứ tự record hiện hành
                    int r = dgvSanPham.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strSanPham =
                    dgvSanPham.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText =
                    "Delete From SanPham Where MaSP='"
                    + strSanPham.Trim() + "'";
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện câu lệnh SQL
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
                finally
                {
                    // Đóng kết nối
                    conn.Close();
                }
            }
        }

        void Huy()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            btnReload.Enabled = false;
            btnThoat.Enabled = true;
            txtMaSP.Enabled = true;
            txtTenSP.Enabled = true;
            txtHinh.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnReload.Enabled = true;
            btnThoat.Enabled = false;
            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtHinh.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Huy();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (!txtDonGia.Text.Trim().Equals(""))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dgvSanPham.CurrentCell.RowIndex;
                string strMaSP = dgvSanPham.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = "UPDATE SanPham Set DonGia=N'" + txtDonGia.Text.Trim() + "',DonViTinh=N'" + txtDonVi.Text.Trim()
                    + "'WHERE MaSP='" + strMaSP.Trim() + "'";
                cmd.ExecuteNonQuery();
                LoadData();
                Huy();
            }
            else
            {
                MessageBox.Show("Chua co du lieu");
            }
            conn.Close();
        }
    }
}
