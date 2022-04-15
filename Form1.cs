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
                this.tsmLogin.Enabled = false;
                this.tsmExit.Enabled = true;
            }
        }

        private void thànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.ThanhPho tp = new DanhMuc.ThanhPho();
            tp.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.KhachHang kh = new DanhMuc.KhachHang();
            kh.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.NhanVien nv = new DanhMuc.NhanVien();
            nv.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.SanPham sp = new DanhMuc.SanPham();
            sp.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.HoaDon hd = new DanhMuc.HoaDon();
            hd.ShowDialog();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc.ChiTietHoaDon cthd = new DanhMuc.ChiTietHoaDon();
            cthd.ShowDialog();
        }
    }
}
