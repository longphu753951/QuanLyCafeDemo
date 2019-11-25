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
    public class BillDAOTests
    {
        // Lấy hóa đơn chưa thanh toán của bàn mà bạn muốn lấy nếu có
        [TestMethod()]
        public void GetUncheckBillByTableIDTest()
        {
            int id = 1;
            int kq = BillDAO.Instance.GetUncheckBillByTableID(id);
            Assert.AreEqual(6, kq);
        }
        
        [TestMethod()]
        public void GetUncheckBillByTableIDTest1()
        {
            int id = -70;
            int kq = BillDAO.Instance.GetUncheckBillByTableID(id);
            Assert.AreEqual(-1, kq);
        }

        [TestMethod()]
        public void getDayBillByTableIDTest()
        {
            int id = 3;
            string ngay = BillDAO.Instance.getDayBillByTableID(id);
            Assert.AreEqual("18-Nov-19 12:00:00 AM", ngay);
        }

        [TestMethod()]
        public void getDayBillByTableIDTest1()
        {
            int id = 500;
            string ngay = BillDAO.Instance.getDayBillByTableID(id);
            Assert.AreEqual(null, ngay);
        }

        [TestMethod()]
        public void getMaxBillTest()
        {
            int maBillMax = BillDAO.Instance.GetMaxIDBill();
            Assert.AreEqual(8, maBillMax);
        }

        
    }
}