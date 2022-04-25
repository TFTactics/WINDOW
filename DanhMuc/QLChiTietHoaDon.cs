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
    public partial class QLChiTietHoaDon : Form
    {
        string err;

        BS_Layer.BLChiTietHoaDon dbCTHD = new BS_Layer.BLChiTietHoaDon();

        void LoadData()
        {
            try
            {
                dgvCTHoaDon.DataSource = dbCTHD.LayChiTietHoaDon();
                dgvCTHoaDon_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("FAIL");
            }
        }

        public QLChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet1.ChiTietHoaDon' table. You can move, or remove it, as needed.
            this.chiTietHoaDonTableAdapter.Fill(this.quanLyBanHangDataSet1.ChiTietHoaDon);
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
                    BS_Layer.BLChiTietHoaDon blCTHD = new BS_Layer.BLChiTietHoaDon();
                    blCTHD.ThemChiTietHoaDon(txtMaHD.Text, txtMaSP.Text, txtSL.Text, ref err);
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
                txtMaSP.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                BS_Layer.BLChiTietHoaDon blCTHD = new BS_Layer.BLChiTietHoaDon();
                blCTHD.XoaChiTietHoaDon(ref err, this.txtMaHD.Text);
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
            txtMaHD.Enabled = false;
            txtMaSP.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Huy();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            BS_Layer.BLChiTietHoaDon blCTHD = new BS_Layer.BLChiTietHoaDon();
            blCTHD.CapNhatChiTietHoaDon(this.txtMaHD.Text, this.txtSL.Text, ref err);
            LoadData();
            Huy();
            MessageBox.Show("Đã sửa xong!");
        }

        private void dgvCTHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvCTHoaDon.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaHD.Text = dgvCTHoaDon.Rows[r].Cells[0].Value.ToString();
            this.txtMaSP.Text = dgvCTHoaDon.Rows[r].Cells[1].Value.ToString();
            txtSL.Text = dgvCTHoaDon.Rows[r].Cells[2].Value.ToString();
        }
    }
}
