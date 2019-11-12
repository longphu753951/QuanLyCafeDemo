using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }
        public bool Login(string userName, string password)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = N'" + userName + "' AND matKhau like N'" + password+ "' ";
            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            return result.Rows.Count> 0;
        }
        public int LoaiChucVu(string userName)
        {
            string query = "SELECT Type FROM dbo.Account WHERE UserName = N'" + userName+"' ";
            int result = (int)DataProvider.Instance.ExcuteScalar(query);
            return result;
        }
    }
}
