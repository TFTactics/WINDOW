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
    public partial class HoaDon : Form
    {
        string strConnectionString = "Data Source=NGUIT;  Initial Catalog=QuanLyBanHang; Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daHoaDon = null;
        DataTable dtHoaDon = null;

        void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daHoaDon = new SqlDataAdapter("SELECT * FROM HOADON", conn);
                dtHoaDon = new DataTable();
                daHoaDon.Fill(dtHoaDon);
                dgvHoaDon.DataSource = dtHoaDon;
            }
            catch (SqlException)
            {
                MessageBox.Show("FAIL");
            }
        }

        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!txtMaHD.Text.Trim().Equals(""))
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
                    cmd.CommandText = "Insert Into HoaDon Values('" +
                     txtMaHD.Text.Trim() + "',N'" +
                     txtMaKH.Text + "',N'" + txtMaNV.Text + "','" + dtNgayLapHD.Value.ToString("yyyy-MM-dd") + "','" 
                     + dtNgayNhanHang.Value.ToString("yyyy-MM-dd") + "')";
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
                txtMaHD.Focus();
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
                    int r = dgvHoaDon.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strHoaDon =
                    dgvHoaDon.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText =
                    "Delete From HoaDon Where MaHD='"
                    + strHoaDon.Trim() + "'";
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
            txtMaNV.Enabled = true;
            txtMaKH.Enabled = true;
            txtMaHD.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnReload.Enabled = true;
            btnThoat.Enabled = false;
            txtMaNV.Enabled = false;
            txtMaKH.Enabled = false;
            txtMaHD.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Huy();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            int r = dgvHoaDon.CurrentCell.RowIndex;
            string strMaHD = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            cmd.CommandText = "UPDATE HoaDon Set NgayLapHD=N'" + dtNgayLapHD.Value.ToString("yyyy-MM-dd")
                + "',NgayNhanHang=N'" + dtNgayNhanHang.Value.ToString("yyyy-MM-dd")
                + "'WHERE MaHD='" + strMaHD.Trim() + "'";
            cmd.ExecuteNonQuery();
            LoadData();
            Huy();
            conn.Close();
        }
    }
}
