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
    public class TableDAOTests
    {
        [TestMethod()]
        public void ThemBanTest()
        {
            string tenBan = "Bàn 11";
            bool them = TableDAO.Instance.ThemBan(tenBan);
            Assert.AreEqual(true, them);
        }

        [TestMethod()]
        public void FindTableByNameTest()
        {
            string name = "Bàn 1";
            int tim = TableDAO.Instance.FindTableByName(name);
            Assert.AreEqual(2, tim);
        }

        [TestMethod()]
        public void FindTableByNameTestNull()
        {
            string name = "";
            int tim = TableDAO.Instance.FindTableByName(name);
            Assert.AreEqual(0, tim);
        }

        [TestMethod()]
        public void KiemTraTinhTrangTest()
        {
            int idBan = 1;
            string status = "Có người";
            string statusBan = TableDAO.Instance.KiemTraTinhTrang(idBan);
            Assert.AreEqual(status, statusBan);
        }

        [TestMethod()]
        public void CapNhatBanTest()
        {
            int id = 4;
            string nameBan = "Bàn ba";
            bool a = TableDAO.Instance.CapNhatBan(id, nameBan);
            Assert.AreEqual(true, a);
        }

        [TestMethod()]
        public void XoaBanTest()
        {
            int id = 9;
            bool kq = TableDAO.Instance.XoaBan(id);
            Assert.AreEqual(true, kq);
        }
    }
}