using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO.NET.BS_Layer
{
    class BLHoaDon
    {
        public System.Data.Linq.Table<HoaDon> LayHoaDon()
        {
            DataSet ds = new DataSet();
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            return qlBH.HoaDons;
        }

        public bool ThemHoaDon(string MaHD, string MaKH, string MaNV, DateTime NgayLapHD, DateTime NgayNhanHang, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            HoaDon hd = new HoaDon();
            hd.MaHD = MaHD;
            hd.MaKH = MaKH;
            hd.MaNV = MaNV;
            hd.NgayLapHD = NgayLapHD;
            hd.NgayNhanHang = NgayNhanHang;

            qlBH.HoaDons.InsertOnSubmit(hd);
            qlBH.HoaDons.Context.SubmitChanges();
            return true;
        }

        public bool XoaHoaDon(ref string err, string MaHD)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = from hd in qlBH.HoaDons
                          where hd.MaHD == MaHD
                          select hd;
            qlBH.HoaDons.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }

        public bool CapNhatHoaDon(string MaHD, DateTime NgayLapHD, DateTime NgayNhanHD, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = (from hd in qlBH.HoaDons
                           where hd.MaHD == MaHD
                           select hd).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.NgayLapHD = NgayLapHD;
                tpQuery.NgayNhanHang = NgayNhanHD;
                qlBH.SubmitChanges();
            }
            return true;
        }
    }
}
