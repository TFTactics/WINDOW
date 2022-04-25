using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO.NET.BS_Layer
{
    class BLDangNhap
    {
        public bool AddUser(string User, string Pass)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            DangNhap login = new DangNhap();
            login.Username = User;
            login.Password = Pass;

            qlBH.DangNhaps.InsertOnSubmit(login);
            qlBH.DangNhaps.Context.SubmitChanges();
            return true;
        }

        public bool checkUser(string User, string Pass)
        {
            QuanLyBanHangDataContext qlBH = new QuanLyBanHangDataContext();
            var tpQuery = (from login in qlBH.DangNhaps
                           where login.Username == User
                           select login).SingleOrDefault();
            if (tpQuery.Password == Pass)
            {
                return true;
            }
            return false; ;
        }
    }
}
