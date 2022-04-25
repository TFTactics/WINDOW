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
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ADO.NET.DanhMuc
{
    public partial class QLThanhPho : Form
    {
        string err;

        BS_Layer.BLThanhPho dbTP = new BS_Layer.BLThanhPho();

        public QLThanhPho()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dgvThanhPho.DataSource = dbTP.LayThanhPho();
                dgvThanhPho_CellClick(null, null);
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
                try
                {
                    BS_Layer.BLThanhPho blTP = new BS_Layer.BLThanhPho();
                    blTP.ThemThanhPho(txtMaThanhPho.Text, txtTenThanhPho.Text, ref err);
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
                MessageBox.Show("Thành phố chưa có. Lỗi rồi!");
                txtMaThanhPho.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                BS_Layer.BLThanhPho blTP = new BS_Layer.BLThanhPho();
                blTP.XoaThanhPho(ref err, this.txtMaThanhPho.Text);
                LoadData();
                MessageBox.Show("Đã xóa xong!");
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
            BS_Layer.BLThanhPho blTP = new BS_Layer.BLThanhPho();
            blTP.CapNhatThanhPho(this.txtMaThanhPho.Text, this.txtTenThanhPho.Text, ref err);
            LoadData();
            Huy();
            MessageBox.Show("Đã sửa xong!");
        }

        private void dgvThanhPho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*int r = dgvThanhPho.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaThanhPho.Text = dgvThanhPho.Rows[r].Cells[0].Value.ToString();
            this.txtTenThanhPho.Text = dgvThanhPho.Rows[r].Cells[1].Value.ToString();*/
        }
    }
}
