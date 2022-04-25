using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO.NET.BS_Layer
{
    class BLSanPham
    {
        public System.Data.Linq.Table<SanPham> LaySanPham()
        {
            DataSet ds = new DataSet();
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            return qlBH.SanPhams;
        }

        public bool ThemSanPham(string MaSP, string TenSP, string DonViTinh, string DonGia, string Hinh, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            SanPham sp = new SanPham();
            sp.MaSP = MaSP;
            sp.TenSP = TenSP;
            sp.DonViTinh = DonViTinh;
            sp.DonGia = Convert.ToDouble(DonGia);
            sp.Hinh = Hinh;

            qlBH.SanPhams.InsertOnSubmit(sp);
            qlBH.SanPhams.Context.SubmitChanges();
            return true;
        }

        public bool XoaSanPham(ref string err, string MaSanPham)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = from sp in qlBH.SanPhams
                          where sp.MaSP == MaSanPham
                          select sp;
            qlBH.SanPhams.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }

        public bool CapNhatSanPham(string MaSanPham, double DonGia, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = (from sp in qlBH.SanPhams
                           where sp.MaSP == MaSanPham
                           select sp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.DonGia = Convert.ToDouble(DonGia);
                qlBH.SubmitChanges();
            }
            return true;
        }
    }
}
