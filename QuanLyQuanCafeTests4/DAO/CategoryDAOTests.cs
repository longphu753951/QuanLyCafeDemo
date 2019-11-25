using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO.Tests
{
    [TestClass()]
    public class CategoryDAOTests
    {
        // FIND CATEGORY BY NAME
        [TestMethod()]
        public void FindCategoryByNameTest()
        {
            string tenHang = "Milk tea";
            int Actual = CategoryDAO.Instance.FindCategoryByName(tenHang);
            Assert.AreEqual(1, Actual);
        }

        [TestMethod()]
        public void FindCategoryByNameTestNull()
        {
            string tenHang = "";
            int Actual = CategoryDAO.Instance.FindCategoryByName(tenHang);
            Assert.AreEqual(0, Actual);
        }

        [TestMethod()]
        public void FindCategoryByNameTest1()
        {
            string tenHang = "Kem";
            int Actual = CategoryDAO.Instance.FindCategoryByName(tenHang);
            Assert.AreEqual(0, Actual);
        }

        // GET CATEGORY BY ID
        [TestMethod()]
        public void GetCategoryByIDTest()
        {
            int maLoai = 5;
            Assert.AreEqual("Chocolate", CategoryDAO.Instance.GetCategoryByID(maLoai).Name);
        }

        [TestMethod()]
        public void GetCategoryByIDTestNull()
        {
            int maLoai =120 ;
            CategoryDTO actual = CategoryDAO.Instance.GetCategoryByID(maLoai);
            Assert.AreEqual(null,actual );
        }

        // INSERT CATEGORY TEST
        [TestMethod()]
        public void InsertCategoryTest()
        {
            string ten = "Sữa tươi";
            bool them = CategoryDAO.Instance.InsertCategory(ten);
            Assert.AreEqual(true, them);
        }

        // UPDATE DRINK CATEGORY
        [TestMethod()]
        public void UpdateDrinkCategoryTest()
        {
            int maLoai = 1;
            string tenMoi = "Milk tea";
            CategoryDAO.Instance.UpdateDrinkCategory(maLoai, tenMoi);
            Assert.AreEqual("Milk tea", CategoryDAO.Instance.GetCategoryByID(1).Name);
        }

        [TestMethod()]
        public void UpdateDrinkCategoryTestNull()
        {
            int maLoai = 1;
            string tenMoi = "";
            CategoryDAO.Instance.UpdateDrinkCategory(maLoai, tenMoi);
            Assert.AreEqual("", CategoryDAO.Instance.GetCategoryByID(1).Name);
        }

        // DELETE DRINK CATEGORY
        [TestMethod()]
        public void DeleteDrinkCategoryTest()
        {
            int id = 4;
            CategoryDAO.Instance.DeleteDrinkCategory(id);
            Assert.AreEqual(null, CategoryDAO.Instance.GetCategoryByID(id));
        }

        [TestMethod()]
        public void DeleteDrinkCategoryTest1() // ma loai nay khong ton tai, tra ve null
        {
            int id = 500;
            CategoryDAO.Instance.DeleteDrinkCategory(id);
            Assert.AreEqual(null, CategoryDAO.Instance.GetCategoryByID(id));
        }

    }
}