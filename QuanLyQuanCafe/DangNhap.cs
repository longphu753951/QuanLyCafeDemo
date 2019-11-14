﻿using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            
        }
        
        private void DangNhap_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            int a = int.Parse(screenWidth);
            int b = int.Parse(screenHeight);
            panelDangNhap.Location = new Point(a / 7, b /2-140);
            
        }
        private bool Login(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dRThoat = MessageBox.Show("Bạn có muốn tắt không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dRThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = txtDangNhap.Text;
            string matKhau = txtMK.Text;
            if (Login(tenTK,matKhau))
            {
                Program.loaiChucVu = AccountDAO.Instance.LoaiChucVu(tenTK);
                fBanHang banHang = new fBanHang();
                this.Hide();
                banHang.ShowDialog();
                this.Show();
                txtDangNhap.Text = txtMK.Text = "";

            }
            else
                MessageBox.Show("Thất bại");
        }

        private void panelDangNhap_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
