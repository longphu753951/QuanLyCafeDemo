using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class DoiMatKhau : Form
    {
        private static int w = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
        private static int h = int.Parse(Screen.PrimaryScreen.Bounds.Height.ToString());
        public DoiMatKhau()
        {
            InitializeComponent();
            loadKichThuoc();
        }
        void loadKichThuoc()
        {
            this.ControlBox = false;
            this.Size = new Size(w * 60 / 100, h * 60 / 100);
            flpContainer.Size = this.Size;
            txtIDAC.Text = fAdmin.idDangChon;
        }
        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string c = textBox3.Text.ToString();
            if (c.Length >= 8)
            {
                if (Regex.IsMatch(c, @"[a-z]"))
                {
                    if (Regex.IsMatch(c, @"[A-Z]"))
                    {
                        if (Regex.IsMatch(c, @"\d"))
                        {
                            if (Regex.IsMatch(c, @"\W"))
                            {
                                if (!c.Contains(' '))
                                {
                                    btnXacNhan.Enabled = true;
                                    btnXacNhan.BackColor = Color.FromArgb(192, 255, 192);
                                    label4.Text = "";
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            btnXacNhan.Enabled = false;
            btnXacNhan.BackColor = Color.Gray;
            label4.Text = "Mật khẩu phải có trên 8 ký tự, chữ hoa, thường, ký tự đặc biệt,số và không có khoảng trắng";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.ToString() != textBox3.Text.ToString())
            {
                btnXacNhan.Enabled = false;
                btnXacNhan.BackColor = Color.Gray;
                label4.Text = "Mật khẩu Xác nhận phải giống với mật khẩu";
            }
            else
            {
                btnXacNhan.Enabled = true;
                btnXacNhan.BackColor = Color.FromArgb(192, 255, 192);
                label4.Text = "";
                return;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDAC.Text);
            string matKhau = textBox3.Text.ToString();
            if (matKhau == "")
            {
                MessageBox.Show("Mời điền đầy đủ thông tin");
                return;
            }
            else
            {
                if (AccountDAO.Instance.SuaMatKhau(id, matKhau))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
