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
    public partial class ThemTaiKhoan : Form
    {
        private static int w = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
        private int loaiNhanVien = 2;
        private static int h = int.Parse(Screen.PrimaryScreen.Bounds.Height.ToString());
        public ThemTaiKhoan()
        {
            InitializeComponent();
            loadKichThuoc();
        }
        void loadKichThuoc()
        {
            this.ControlBox = false;
            this.Size = new Size(w * 60 / 100, h * 80 / 100);
            flpContainer.Size = this.Size;
            panel1.Size = panel2.Size = panel3.Size = panel4.Size = flpButton.Size = new Size(this.Width * 90 / 100, this.Height * 14 / 100);
            btnXacNhan.Size = btnHuy.Size = new Size(flpButton.Height * 2, flpButton.Height * 70 / 100);
        }
        private void ThemTaiKhoan_Load(object sender, EventArgs e)
        {
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string a = textBox1.Text.ToString();
            string pattern = @"[^a-zA-Z\s]";
            if(Regex.IsMatch(a, pattern))
            {
                btnXacNhan.Enabled = false;
                btnXacNhan.BackColor = Color.Gray;
                label4.Text = "Tên hiển thị không được có số và ký tự đặc biệt";
            }
            else
            {
                btnXacNhan.Enabled = true;
                btnXacNhan.BackColor = Color.FromArgb(192,255,192);
                label4.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string a = textBox2.Text.ToString();
            string pattern = @"[^\d]";
            if (Regex.IsMatch(a, pattern) || a.Length < 10)
            {
                btnXacNhan.Enabled = false;
                btnXacNhan.BackColor = Color.Gray;
                label4.Text = "Tài khoản không được có chữ và ký tự đặc biệt";
            }
            else
            {
                btnXacNhan.Enabled = true;
                btnXacNhan.BackColor = Color.FromArgb(192, 255, 192);
                label4.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string c = textBox3.Text.ToString();
            if (c.Length >= 8)
            {
                if (Regex.IsMatch(c, @"[a-z]"))
                {
                    if(Regex.IsMatch(c, @"[A-Z]"))
                    {
                        if (Regex.IsMatch(c, @"\d"))
                        {
                            if (Regex.IsMatch(c, @"\W"))
                            {
                                if(!c.Contains(' '))
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

        private void rbtnNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;
            loaiNhanVien = int.Parse(rad.Tag.ToString());
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string displayName = textBox1.Text.ToString();
            string account = textBox2.Text.ToString();
            string password = textBox3.Text.ToString();
            if(displayName ==""||account ==""||password ==""||loaiNhanVien == 2)
            {
                MessageBox.Show("Mời điền đầy đủ thông tin");
                return;
            }
            else if (AccountDAO.Instance.FindAccountByUserName(account) != 0)
            {
                MessageBox.Show("Tên tài khoản đã có, vui lòng đặt lại");
                return;
            }
            else
            {
                if (AccountDAO.Instance.InsertAccount(account, displayName, password, loaiNhanVien))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm");
                }
            }
        }
    }
}
