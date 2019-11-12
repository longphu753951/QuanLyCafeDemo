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
    public partial class fSoLuong : Form
    {
        public fSoLuong()
        {
            InitializeComponent();
        }
        public string soLuong = null;
        private void fSoLuong_Load(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            
            soLuong = txtSoLuongNhap.Text;
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string soNhap = (sender as Button).Text;
            txtSoLuongNhap.Text += soNhap;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtSoLuongNhap.Text = null;
        }
    }
}
