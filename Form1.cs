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

namespace ADO.NET
{
    public partial class Form1 : Form
    {
        public static bool bLogin = false;
        SqlConnection strConnect = new SqlConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void tsmLogin_Click(object sender, EventArgs e)
        {
            FormDangNhap login = new FormDangNhap();
            login.ShowDialog();
            if (bLogin)
            {
                quảnLíDanhMụcĐơnToolStripMenuItem.Enabled = true;
                this.tsmLogin.Enabled = false;
                this.tsmExit.Enabled = true;
            }
        }

        private void thànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.QLThanhPho tp = new DanhMuc.QLThanhPho();
            tp.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.QLKhachHang kh = new DanhMuc.QLKhachHang();
            kh.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.NhanVien nv = new DanhMuc.NhanVien();
            nv.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.QLSanPham sp = new DanhMuc.QLSanPham();
            sp.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.QLHoaDon hd = new DanhMuc.QLHoaDon();
            hd.ShowDialog();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.QLChiTietHoaDon cthd = new DanhMuc.QLChiTietHoaDon();
            cthd.ShowDialog();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            tsmLogin.Enabled = true;
            quảnLíDanhMụcĐơnToolStripMenuItem.Enabled = false;
        }

        private void đăngKíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.FormDangKi dk = new DanhMuc.FormDangKi();
            dk.ShowDialog();
        }
    }
}
