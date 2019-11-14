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
        [TestMethod()]
        public void LoaiChucVuTest()
        {
            int actual = AccountDAO.Instance.LoaiChucVu("1751010108phu");
            Assert.AreEqual(1, actual);
        }
    }
}