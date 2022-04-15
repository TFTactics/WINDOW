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
    public partial class ThanhPho : Form
    {
        string strConnectionString = "Data Source=NGUIT;  Initial Catalog=QuanLyBanHang; Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daThanhPho = null;
        DataTable dtThanhPho = null;

        public ThanhPho()
        {
            InitializeComponent();
        }


        void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daThanhPho = new SqlDataAdapter("SELECT * FROM THANHPHO", conn);
                dtThanhPho = new DataTable();
                daThanhPho.Fill(dtThanhPho);
                dgvThanhPho.DataSource = dtThanhPho;
            }
            catch (SqlException)
            {
                MessageBox.Show("FAIL");
            }
        }

        private void ThanhPho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!txtMaThanhPho.Text.Trim().Equals(""))
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
                    cmd.CommandText = "Insert Into ThanhPho Values('" +
                     txtMaThanhPho.Text.Trim() + "',N'" +
                     txtTenThanhPho.Text + "')";
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
                txtMaThanhPho.Clear();
                txtTenThanhPho.Clear();
            }
            else
            {
                MessageBox.Show("Thành phố chưa có. Lỗi rồi!");
                txtMaThanhPho.Focus();
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
                    int r = dgvThanhPho.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strThanhPho =
                    dgvThanhPho.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText =
                    "Delete From ThanhPho Where ThanhPho='"
                    + strThanhPho.Trim() + "'";
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
            btnReload.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtTenCty
            txtMaThanhPho.Enabled = false;
            txtTenThanhPho.Focus();
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
            btnThoat.Enabled = true;
            txtMaThanhPho.Enabled = true;
            btnReload.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (!txtTenThanhPho.Text.Trim().Equals(""))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dgvThanhPho.CurrentCell.RowIndex;
                string strThanhPho = dgvThanhPho.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = "Update ThanhPho Set TenThanhPho=N'" +
                    txtTenThanhPho.Text.Trim() + "' Where ThanhPho='" +
                    strThanhPho.Trim() + "'";
                cmd.ExecuteNonQuery();
                LoadData();
                Huy();
            }
            else
            {
                MessageBox.Show("Chua co du lieu");
            }
        }
    }
}
