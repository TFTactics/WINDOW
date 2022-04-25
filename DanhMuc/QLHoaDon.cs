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
    public partial class QLHoaDon : Form
    {
        string err;

        BS_Layer.BLHoaDon dbTP = new BS_Layer.BLHoaDon();

        void LoadData()
        {
            try
            {
                dgvHoaDon.DataSource = dbTP.LayHoaDon();
                dgvHoaDon_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("FAIL");
            }
        }

        public QLHoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet1.HoaDon' table. You can move, or remove it, as needed.
            this.hoaDonTableAdapter.Fill(this.quanLyBanHangDataSet1.HoaDon);
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
                try
                {
                    BS_Layer.BLHoaDon blHD = new BS_Layer.BLHoaDon();
                    blHD.ThemHoaDon(txtMaHD.Text, txtMaKH.Text, txtMaNV.Text, dtNgayLapHD.Value, dtNgayNhanHang.Value, ref err);
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
                txtMaHD.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                BS_Layer.BLHoaDon blHD = new BS_Layer.BLHoaDon();
                blHD.XoaHoaDon(ref err, this.txtMaHD.Text);
                LoadData();
                MessageBox.Show("Đã xóa xong!");
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
            BS_Layer.BLHoaDon blHD = new BS_Layer.BLHoaDon();
            blHD.CapNhatHoaDon(this.txtMaHD.Text, dtNgayLapHD.Value, dtNgayNhanHang.Value, ref err);
            LoadData();
            Huy();
            MessageBox.Show("Đã sửa xong!");
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHoaDon.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaHD.Text = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            this.txtMaKH.Text = dgvHoaDon.Rows[r].Cells[1].Value.ToString();
            txtMaNV.Text = dgvHoaDon.Rows[r].Cells[2].Value.ToString();
        }
    }
}
