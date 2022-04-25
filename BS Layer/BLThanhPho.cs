using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO.NET.BS_Layer
{
    class BLThanhPho
    {
        public System.Data.Linq.Table<ThanhPho> LayThanhPho()
        {
            DataSet ds = new DataSet();
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            return qlBH.ThanhPhos;
        }

        public bool ThemThanhPho(string MaThanhPho, string TenThanhPho, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            ThanhPho tp = new ThanhPho();
            tp.ThanhPho1 = MaThanhPho;
            tp.TenThanhPho = TenThanhPho;

            qlBH.ThanhPhos.InsertOnSubmit(tp);
            qlBH.ThanhPhos.Context.SubmitChanges();
            return true;
        }

        public bool XoaThanhPho(ref string err, string MaThanhPho)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = from tp in qlBH.ThanhPhos
                          where tp.ThanhPho1 == MaThanhPho
                          select tp;
            qlBH.ThanhPhos.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }

        public bool CapNhatThanhPho(string MaThanhPho, string TenThanhPho, ref string err)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = (from tp in qlBH.ThanhPhos
                           where tp.ThanhPho1 == MaThanhPho
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.TenThanhPho = TenThanhPho;
                qlBH.SubmitChanges();
            }
            return true;
        }
    }
}
