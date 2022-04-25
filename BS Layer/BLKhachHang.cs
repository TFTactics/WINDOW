using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO.NET.BS_Layer
{
    class BLKhachHang
    {
        public System.Data.Linq.Table<KhachHang> LayKhachHang()
        {
            DataSet ds = new DataSet();
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            return qlBH.KhachHangs;
        }

        public bool ThemKhachHang(string MaKH, string CTY, string DiaChi, string TP, string SDT, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            KhachHang kh = new KhachHang();
            kh.MaKH = MaKH;
            kh.TenCty = CTY;
            kh.DiaChi = DiaChi;
            kh.ThanhPho = TP;
            kh.DienThoai = SDT;

            qlBH.KhachHangs.InsertOnSubmit(kh);
            qlBH.KhachHangs.Context.SubmitChanges();
            return true;
        }

        public bool XoaKhachHang(ref string err, string MaKH)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = from kh in qlBH.KhachHangs
                          where kh.MaKH == MaKH
                          select kh;
            qlBH.KhachHangs.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }

        public bool CapNhatKhachHang(string MaKH, string SDT, string DiaChi, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = (from kh in qlBH.KhachHangs
                           where kh.MaKH == MaKH
                           select kh).SingleOrDefault();
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
