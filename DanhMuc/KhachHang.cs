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
    public partial class KhachHang : Form
    {
        string strConnectionString = "Data Source=NGUIT;  Initial Catalog=QuanLyBanHang; Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daKhachHang = null;
        DataTable dtKhachHang = null;

        public KhachHang()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG", conn);
                dtKhachHang = new DataTable();
                daKhachHang.Fill(dtKhachHang);
                dgvKhachHang.DataSource = dtKhachHang;
            }
            catch (SqlException)
            {
                MessageBox.Show("FAIL");
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!txtMaKH.Text.Trim().Equals(""))
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
                    cmd.CommandText = "Insert Into KhachHang Values('" +
                     txtMaKH.Text + "',N'" +
                     txtCty.Text + "',N'" + txtDiaChi.Text + "','" + cbTP.Text.Trim() + "','" + txtSDT.Text.Trim() + "')";
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
                txtMaKH.Focus();
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
                    int r = dgvKhachHang.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strKhachHang =
                    dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText =
                    "Delete From KhachHang Where MaKH='"
                    + strKhachHang.Trim() + "'";
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
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnReload.Enabled = true;
            btnThoat.Enabled = false;
            txtMaKH.Enabled = false;
            cbTP.Enabled = false;
            txtCty.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Huy();
        }

        void Huy()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            btnReload.Enabled = false;
            btnThoat.Enabled = true;
            txtMaKH.Enabled = true; ;
            txtCty.Enabled = true;
            cbTP.Enabled = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (!txtDiaChi.Text.Trim().Equals(""))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dgvKhachHang.CurrentCell.RowIndex;
                string strMaKH = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                /*cmd.CommandText = "Update KhachHang Set DiaChi=N'" +
                    txtDiaChi.Text.Trim() + "',N'" + txtSDT.Text.Trim() + "' Where MaKH='" +
                    strMaKH.Trim() + "'";*/
                cmd.CommandText = "UPDATE KhachHang Set DiaChi=N'" + txtDiaChi.Text.Trim() + "',DienThoai=N'" + txtSDT.Text.Trim()
                    + "'WHERE MaKH='" + strMaKH.Trim() + "'";
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
