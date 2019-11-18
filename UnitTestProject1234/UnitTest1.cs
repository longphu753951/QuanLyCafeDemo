using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyQuanCafe;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DangNhap fbh = new DangNhap();
            fbh.txtDangNhap.Text = "staff1";
            fbh.txtMK.Text = "123456789";
            fbh.btnDangNhap.PerformClick();
        }
    }
}
