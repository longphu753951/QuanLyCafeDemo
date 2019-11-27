using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO.Tests
{
    [TestClass()]
    public class AccountDAOTests
    {

        //  TEST LOGIN
        [TestMethod()]
        public void LoginTest()
        {
            string user = "admin1";
            string password = "123456789";
            bool Actual = AccountDAO.Instance.Login(user, password);
            Assert.AreEqual(true, Actual);
        }

        [TestMethod()]
        public void LoginTestMatKhau() // sai mat khau
        {
            string user = "admin";
            string password = "1234";
            bool Actual = AccountDAO.Instance.Login(user, password);
            Assert.AreEqual(false, Actual);
        }

        [TestMethod()]
        public void LoginTestNull() // ten va mat khau co gia tri null
        {
            string user = "";
            string password = "";
            bool Actual = AccountDAO.Instance.Login(user, password);
            Assert.AreEqual(false, Actual);
        }

        [TestMethod()]
        public void LoginTestNullMatKhau() // mat khau null
        {
            string user = "admin";
            string password = "";
            bool Actual = AccountDAO.Instance.Login(user, password);
            Assert.AreEqual(false, Actual);
        }

        [TestMethod()]
        public void LoginTestNullName() // ten dang nhap null
        {
            string user = "";
            string password = "admin1";
            bool Actual = AccountDAO.Instance.Login(user, password);
            Assert.AreEqual(false, Actual);
        }

        [TestMethod()]
        public void LoginTestSaiTenDN() // sai ten dang nhap
        {
            string user = "a";
            string password = "12345";
            bool Actual = AccountDAO.Instance.Login(user, password);
            Assert.AreEqual(false, Actual);
        }
        
        // TEST CHUC VU
        [TestMethod()]
        public void LoaiChucVuTest()
        {
            string user = "admin1";
            int s = AccountDAO.Instance.LoaiChucVu(user);
            Assert.AreEqual(1, s);
        }
        

        [TestMethod()]
        public void FindAccountByUserNameTest()
        {
            string userName = "staff1";
            int id = AccountDAO.Instance.FindAccountByUserName(userName);
            Assert.AreEqual(2, id);
        }

        [TestMethod()]
        public void InsertAccountTest()
        {
            string userName = "admin2";
            string displayName = "admin2";
            string matKhau = "admin2";
            int type = 1;
            bool t = AccountDAO.Instance.InsertAccount(userName, displayName, matKhau, type);
            Assert.AreEqual(true, t);
        }

        [TestMethod()]
        public void SuaTaiKhoanTest()
        {
            int id = 1;
            string DisplayName = "admin";
            string UserName = "admin";
            int loaiChucVu = 1;
            bool t = AccountDAO.Instance.SuaTaiKhoan(id, DisplayName, UserName, loaiChucVu);
            Assert.AreEqual(true, t);
        }

        [TestMethod()]
        public void SuaMatKhauTest()
        {
            int id = 1;
            string pw = "admin1";
            bool ad = AccountDAO.Instance.SuaMatKhau(id, pw);
            Assert.AreEqual(true, ad);
        }

        [TestMethod()]
        public void DeteleAccountTest()
        {
            int id = 2;
            bool kq = AccountDAO.Instance.DeteleAccount(id);
            Assert.AreEqual(true, kq);
        }
        [TestMethod()]
        public void testMaHoa()
        {
            string a = "HueNguSiDan";
            string actual = AccountDAO.Instance.MaHoaMK(a);
            Assert.AreNotEqual(a, actual);
        }
    }
}