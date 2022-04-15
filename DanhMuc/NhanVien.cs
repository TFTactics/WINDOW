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
            Huy();
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
                    int r = dgvNhanVien.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strMaNV =
                    dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText =
                    "Delete From NhanVien Where MaNV='"
                    + strMaNV.Trim() + "'";
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = true;
            btnReload.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
            btnSua.Enabled = false;
            txtHoLot.Enabled = false;
            txtTen.Enabled = false;
            txtMaNV.Enabled = false;
            dtNgayNV.Enabled = false;
            checkMale.Enabled = false;
        }

        void Huy()
        {
            btnHuy.Enabled = false;
            btnReload.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
            btnSua.Enabled = true;
            txtHoLot.Enabled = true;
            txtTen.Enabled = true;
            txtMaNV.Enabled = true;
            dtNgayNV.Enabled = true;
            checkMale.Enabled = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (!txtDiaChi.Text.Trim().Equals(""))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dgvNhanVien.CurrentCell.RowIndex;
                string strMaNV = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                
                cmd.CommandText = "UPDATE NhanVien Set DiaChi=N'" + txtDiaChi.Text.Trim() + "',DienThoai=N'" + txtSDT.Text.Trim()
                    + "'WHERE MaNV='" + strMaNV.Trim() + "'";
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
