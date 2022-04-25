using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO.NET.BS_Layer
{
    class BLChiTietHoaDon
    {
        public System.Data.Linq.Table<ChiTietHoaDon> LayChiTietHoaDon()
        {
            DataSet ds = new DataSet();
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            return qlBH.ChiTietHoaDons;
        }

        public bool ThemChiTietHoaDon(string MaHD, string MaSP, string SL, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.MaHD = MaHD;
            cthd.MaSP = MaSP;
            cthd.Soluong = Convert.ToDouble(SL);

            qlBH.ChiTietHoaDons.InsertOnSubmit(cthd);
            qlBH.ChiTietHoaDons.Context.SubmitChanges();
            return true;
        }

        public bool XoaChiTietHoaDon(ref string err, string MaHD)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = from cthd in qlBH.ChiTietHoaDons
                          where cthd.MaHD == MaHD
                          select cthd;
            qlBH.ChiTietHoaDons.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }

        public bool CapNhatChiTietHoaDon(string MaHD, string SL, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = (from cthd in qlBH.ChiTietHoaDons
                           where cthd.MaHD == MaHD
                           select cthd).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.Soluong = Convert.ToDouble(SL);
                qlBH.SubmitChanges();
            }
            return true;
        }
    }
}
