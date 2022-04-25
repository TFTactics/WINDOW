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
        string err;

        BS_Layer.BLNhanVien dbTP = new BS_Layer.BLNhanVien();

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
                try
                {
                    BS_Layer.BLNhanVien blNV = new BS_Layer.BLNhanVien();
                    blNV.ThemNhanVien(txtMaNV.Text, txtHoLot.Text, txtTen.Text, 
                        checkMale.Checked, dtNgayNV.Value, txtDiaChi.Text, txtSDT.Text, txtHinh.Text, ref err);
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
                MessageBox.Show("Thieu Du Lieu");
                txtMaNV.Focus();
            }
        }

        void LoadData()
        {
            try
            {
                dgvNhanVien.DataSource = dbTP.LayNhanVien();
                dgvNhanVien_CellClick(null, null);
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
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                BS_Layer.BLNhanVien blTP = new BS_Layer.BLNhanVien();
                blTP.XoaNhanVien(ref err, this.txtMaNV.Text);
                LoadData();
                MessageBox.Show("Đã xóa xong!");
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
            BS_Layer.BLNhanVien blNV = new BS_Layer.BLNhanVien();
            blNV.CapNhatNhanVien(this.txtMaNV.Text, this.txtSDT.Text, this.txtDiaChi.Text, ref err);
            LoadData();
            Huy();
            MessageBox.Show("Đã sửa xong!");
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNhanVien.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.txtHoLot.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.txtTen.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.checkMale.Checked = Convert.ToBoolean(dgvNhanVien.Rows[r].Cells[3].Value.ToString());
            this.dtNgayNV.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
            txtHinh.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
        }
    }
}
