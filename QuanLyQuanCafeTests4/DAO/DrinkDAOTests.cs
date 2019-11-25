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
    public class DrinkDAOTests
    {
        [TestMethod()]
        public void FindDrinkByNameTest()
        {
            string ten = "Cà phê sữa";
            int id = DrinkDAO.Instance.FindDrinkByName(ten);
            Assert.AreEqual(5, id);
        }
        // -------------------------------------------------------------------False-----------------------------
        [TestMethod()]
        public void FindDrinkByNameTestNull()
        {
            string ten = "";
            int id = DrinkDAO.Instance.FindDrinkByName(ten);
            Assert.AreEqual(0, id);
        }

        [TestMethod()]
        public void InsertDrinkTest()
        {
            string ten = "Hồng trà sữa";
            float giaBan = 59000;
            int loai = 8;
            bool resualt = DrinkDAO.Instance.InsertDrink(ten, loai, giaBan);
            Assert.AreEqual(true, resualt);
        }
        

        [TestMethod()]
        public void UpdateDrinkTest()
        {
            int id = 21;
            string name = "Trà xoài kem cheese";
            int idCategory = 8;
            float price = 57000;
            bool kq = DrinkDAO.Instance.UpdateDrink(id, name, idCategory, price);
            Assert.AreEqual(true, kq);
        }

        [TestMethod()]
        public void DeleteDrinkTest()
        {
            int id = 30;
            bool k = DrinkDAO.Instance.DeleteDrink(id);
            Assert.AreEqual(true, k);
        }

    }
}