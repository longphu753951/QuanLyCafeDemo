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
    public class CategoryDAOTests
    {
        [TestMethod()]
        public void FindCategoryByNameTest()
        {
            string name = "Trà";
            int id = CategoryDAO.Instance.FindCategoryByName(name);
            Assert.AreEqual(7,id);
        }
    }
}