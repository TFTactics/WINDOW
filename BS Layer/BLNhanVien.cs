using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO.NET.BS_Layer
{
    class BLNhanVien
    {
        public System.Data.Linq.Table<NhanVien> LayNhanVien()
        {
            DataSet ds = new DataSet();
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            return qlBH.NhanViens;
        }

        public bool ThemNhanVien(string MaNV, string HoNV, string TenNV, bool Nu,
            DateTime NgayNV, string DiaChi, string SDT, string Hinh, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;
            nv.Ho = HoNV;
            nv.Ten = TenNV;
            nv.Nu = Nu;
            nv.NgayNV = NgayNV;
            nv.DiaChi = DiaChi;
            nv.DienThoai = SDT;
            nv.Hinh = Hinh;

            qlBH.NhanViens.InsertOnSubmit(nv);
            qlBH.NhanViens.Context.SubmitChanges();
            return true;
        }

        public bool XoaNhanVien(ref string err, string MaNhanVien)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = from nv in qlBH.NhanViens
                          where nv.MaNV == MaNhanVien
                          select nv;
            qlBH.NhanViens.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }

        public bool CapNhatNhanVien(string MaNhanVien, string SDT, string DiaChi, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = (from nv in qlBH.NhanViens
                           where nv.MaNV == MaNhanVien
                           select nv).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.DienThoai = SDT;
                tpQuery.DiaChi = DiaChi;
                qlBH.SubmitChanges();
            }
            return true;
        }
    }
}
