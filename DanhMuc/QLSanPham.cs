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
    public partial class QLSanPham : Form
    {

        string err;

        BS_Layer.BLSanPham dbSP = new BS_Layer.BLSanPham();


        void LoadData()
        {
            try
            {
                dgvSanPham.DataSource = dbSP.LaySanPham();
                dgvSanPham_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("FAIL");
            }
        }

        public QLSanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet1.SanPham' table. You can move, or remove it, as needed.
            this.sanPhamTableAdapter.Fill(this.quanLyBanHangDataSet1.SanPham);
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
                try
                {
                    BS_Layer.BLSanPham blSP = new BS_Layer.BLSanPham();
                    blSP.ThemSanPham(txtMaSP.Text, txtTenSP.Text, txtDonVi.Text, txtDonGia.Text, txtHinh.Text, ref err);
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
                BS_Layer.BLSanPham blSP = new BS_Layer.BLSanPham();
                blSP.XoaSanPham(ref err, this.txtMaSP.Text);
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
            BS_Layer.BLSanPham blSP = new BS_Layer.BLSanPham();
            blSP.CapNhatSanPham(this.txtMaSP.Text, Convert.ToDouble(txtDonGia.Text), ref err);
            LoadData();
            Huy();
            MessageBox.Show("Đã sửa xong!");
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvSanPham.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaSP.Text = dgvSanPham.Rows[r].Cells[0].Value.ToString();
            this.txtTenSP.Text = dgvSanPham.Rows[r].Cells[1].Value.ToString();
        }
    }
}
