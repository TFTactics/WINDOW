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
    public partial class QLKhachHang : Form
    {
        string err;

        BS_Layer.BLKhachHang dbKH = new BS_Layer.BLKhachHang();

        public QLKhachHang()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dgvKhachHang.DataSource = dbKH.LayKhachHang();
                dgvKhachHang_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("FAIL");
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet1.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.quanLyBanHangDataSet1.KhachHang);
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
                try
                {
                    BS_Layer.BLKhachHang blKH = new BS_Layer.BLKhachHang();
                    blKH.ThemKhachHang(txtMaKH.Text, txtCty.Text, txtDiaChi.Text, cbTP.Text, txtSDT.Text, ref err);
                    LoadData();
                    MessageBox.Show("Done");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
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
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                BS_Layer.BLKhachHang blKH = new BS_Layer.BLKhachHang();
                blKH.XoaKhachHang(ref err, this.txtMaKH.Text);
                LoadData();
                MessageBox.Show("Đã xóa xong!");
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
            BS_Layer.BLKhachHang blKH = new BS_Layer.BLKhachHang();
            blKH.CapNhatKhachHang(this.txtMaKH.Text, this.txtSDT.Text, this.txtDiaChi.Text, ref err);
            LoadData();
            Huy();
            MessageBox.Show("Đã sửa xong!");
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKhachHang.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaKH.Text = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            this.txtCty.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            this.cbTP.Text = dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            this.txtDiaChi.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            this.txtSDT.Text = dgvKhachHang.Rows[r].Cells[4].Value.ToString();
        }
    }
}
