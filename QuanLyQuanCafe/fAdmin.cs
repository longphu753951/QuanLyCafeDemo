using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
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
    public partial class fAdmin : Form
    {
        BindingSource drinkList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource banList = new BindingSource();
        BindingSource AccountList = new BindingSource();
        private static int w = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
        private int loaiNhanVien =2;
        private static int h = int.Parse(Screen.PrimaryScreen.Bounds.Height.ToString());
        public fAdmin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            LoadAll();
        }
        
        #region methods
        void loadListByDay(DateTime checkIn, DateTime checkOut)
        {
            dtgHoaDon.DataSource =  BillDAO.Instance.GetBillByDate(checkIn, checkOut);
        }
        void loadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dtpCheckIn.Value = new DateTime(today.Year, today.Month, 1);
            dtpCheckOut.Value = dtpCheckIn.Value.AddMonths(1).AddDays(-1);
        }
        void loadDrink()
        {
            drinkList.DataSource = DrinkDAO.Instance.LoadListDrinkAll();
        }
        void loadAccountList()
        {
            AccountList.DataSource = AccountDAO.Instance.loadTaiKhoan();
        }
        void loadDrinkdmin()
        {
            flpBan1.Width=flp8.Width=dtvCategory .Width= dtvDoUong.Width = flp1.Width = dtgBan.Width = tcContainer.Width * 45 / 100;
            dtvCategory .Height= dtvDoUong.Height =dtgBan.Height =tcContainer.Height * 80 / 100;
            btnSuaBan.Width=btnXoaBan.Width=btnThemBan.Width=btnThemCat.Width = btnXoaCat.Width = btnSuaCat.Width =btnThem.Width = btnXoa.Width = btnSua.Width = flp1.Width * 24 / 100;
            flp7.Width=flpDoUongDTV.Width = ctnThongTinDoUong.Width =flp12.Width =flowLayoutPanel5.Width =tcContainer.Width * 50 / 100;
            flp7.Height=flpDoUongDTV.Height = ctnThongTinDoUong.Height = flp12.Height = flowLayoutPanel5.Height = tcContainer.Height;
            flpBan1.Height=flp8.Height=flp1.Height = flpDoUongDTV.Height * 14 / 100;
            btnSuaBan.Height = btnXoaBan.Height = btnThemBan.Height = btnThemCat.Height = btnThemCat.Height = btnXoaCat.Height = btnSuaCat.Height = btnThem.Height = btnXoa.Height = btnSua.Height = flp1.Height * 90 / 100;
            flp2.Height = ctnThongTinDoUong.Height * 15 / 100;
            flp3.Height = flp4.Height = flp5.Height = flp6.Height = ctnThongTinDoUong.Height * 12 / 100;
            flp2.Width=flp3.Width = flp4.Width = flp5.Width = flp6.Width = ctnThongTinDoUong.Width * 90 / 100 ;
            loadTaiKhoanAdmin();


        }
        void loadTaiKhoanAdmin()
        {
            flpTaiKhoan.Width = tcContainer.Width * 50 / 100;
            flpTaiKhoan.Height = tcContainer.Height * 99 / 100;
            dtvTaiKhoan.Width = flpTaiKhoan.Width * 90 / 100;
            dtvTaiKhoan.Height = flpTaiKhoan.Height * 80 / 100;
            flpButtonTK.Height = flpTaiKhoan.Height - dtvTaiKhoan.Height - 5;
            btnThemTK.Height = btnSuaTK.Height = btnXoaTK.Height = flpButtonTK.Height * 70 / 100;
            btnThemTK.Width = btnSuaTK.Width = btnXoaTK.Width = flpButtonTK.Width * 28 / 100;
            flp19.Width = flp13.Width = flp14.Width = flp15.Width = flp16.Width = flp17.Width = flp18.Width = tcContainer.Width - flpTaiKhoan.Width;
        }
        void loadBan()
        {
            banList.DataSource = TableDAO.Instance.LoadTableList();
        }
        void loadCategoryForComboBox()
        {
            cbLoaiDoUong.DataSource = CategoryDAO.Instance.GetListCategory();
            cbLoaiDoUong.DisplayMember = "Name";
        }
        void loadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void loadAccount()
        {
            dtvTaiKhoan.DataSource = AccountDAO.Instance.loadTaiKhoan();
        }
        void addDrinkBinding()
        {
            txtTen.DataBindings.Add(new Binding("Text", dtvDoUong.DataSource, "Name",true,DataSourceUpdateMode.Never));
            txtID.DataBindings.Add(new Binding("Text", dtvDoUong.DataSource, "ID", true, DataSourceUpdateMode.Never));
            numUDGiaBan.DataBindings.Add(new Binding("Value", dtvDoUong.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void addCategoryBinding()
        {
            txtIDCat.DataBindings.Add(new Binding("Text", dtvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtTenCat.DataBindings.Add(new Binding("Text", dtvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }
        void addBanBinding()
        {
            txtBanID.DataBindings.Add(new Binding("Text", dtgBan.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtBanTen.DataBindings.Add(new Binding("Text", dtgBan.DataSource, "name", true, DataSourceUpdateMode.Never));
        }
        void addAccountBinding()
        {
            txtIDAC.DataBindings.Add(new Binding("Text", dtvTaiKhoan.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dtvTaiKhoan.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txtUserName.DataBindings.Add(new Binding("Text", dtvTaiKhoan.DataSource, "UserName", true, DataSourceUpdateMode.Never));

        }
        void LoadAll()
        {
            dtvTaiKhoan.DataSource = AccountList;
            dtgBan.DataSource = banList;
            dtvCategory.DataSource = categoryList;
            dtvDoUong.DataSource = drinkList;
            loadDrink();
            loadCategory();
            loadCategoryForComboBox();
            loadDateTimePicker();
            loadDrinkdmin();
            loadAccountList();
            addDrinkBinding();
            addCategoryBinding();
            loadBan();
            addBanBinding();
            addAccountBinding();
        }
        #endregion
        #region events 
        private void fAdmin_Load(object sender, EventArgs e)
        {
            loadDateTimePicker();
            tcContainer.Width = w;
            tcContainer.Height = h;
            panel1.Width = tcContainer.Width * 99 / 100;
            dtgHoaDon.Width = w;
            dtgHoaDon.Height = tcContainer.Height - panel1.Height;
            loadListByDay(dtpCheckIn.Value, dtpCheckOut.Value);
            loadDrinkdmin();
        }

        private void btnKiemKe_Click(object sender, EventArgs e)
        {
            loadListByDay(dtpCheckIn.Value, dtpCheckOut.Value);
        }
        private void txtID_TextChanged_1(object sender, EventArgs e)
        {
            if (dtvDoUong.SelectedCells.Count > 0)
            {
                int id = (int)dtvDoUong.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                CategoryDTO category = CategoryDAO.Instance.GetCategoryByID(id);
                int index = -1;
                int i = 0;
                foreach (CategoryDTO item in cbLoaiDoUong.Items)
                {
                    if (item.ID == category.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbLoaiDoUong.SelectedIndex = index;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string name = txtTen.Text;
            int idCat = (cbLoaiDoUong.SelectedItem as CategoryDTO).ID;
            float price = (int)numUDGiaBan.Value;
            if(price <= 0)
            {
                MessageBox.Show("Giá tiền không được bé hơn 0");
                return;
            }
            int idKiem = DrinkDAO.Instance.FindDrinkByName(name);
            if(name == "")
            {
                MessageBox.Show("Mời nhập tên");
                return;
            }
            if(name.Count() < 3)
            {
                MessageBox.Show("Tên món không được bé hơn 8 ký tự");
                return;
            }
            if (idKiem != 0)
            {
                MessageBox.Show("Món đã có trong danh sách");
                return;
            }

            else
                if (DrinkDAO.Instance.InsertDrink(name, idCat, price))
            {
                MessageBox.Show("Đã thêm thành công");
                loadDrink();
                if (insertDrink != null)
                    insertDrink(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn vào danh sách");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string name = txtTen.Text;
            int idCategory = (cbLoaiDoUong.SelectedItem as CategoryDTO).ID;
            float price = (int)numUDGiaBan.Value;
            int idDrink = int.Parse(txtID.Text);
            if (name == "")
            {
                MessageBox.Show("Mời nhập tên");
                return;
            }
            if (name.Count() < 3)
            {
                MessageBox.Show("Tên món không được bé hơn 8 ký tự");
                return;
            }
            if (DrinkDAO.Instance.UpdateDrink(idDrink, name, idCategory, price))
            {
                MessageBox.Show("Sửa món thành công");
                loadDrink();
                if (updateDrink != null)
                    updateDrink(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            if (DrinkDAO.Instance.DeleteDrink(id))
            {
                MessageBox.Show("Món đã được xóa");
                loadDrink();
                if (deleteDrink != null)
                    deleteDrink(this, new EventArgs());
            }
            else
                MessageBox.Show("Có lỗi khi xóa thức ăn");
        }
        private event EventHandler insertDrink;
        public event EventHandler InsertDrink
        {
            add { insertDrink += value; }
            remove { insertDrink -= value; }

        }
        private event EventHandler deleteDrink;
        public event EventHandler DeleteDrink
        {
            add { deleteDrink += value; }
            remove { deleteDrink -= value; }

        }
        private event EventHandler updateDrink;
        public event EventHandler UpdateDrink
        {
            add { updateDrink += value; }
            remove { updateDrink -= value; }

        }
        private void btnThemCat_Click(object sender, EventArgs e)
        {
            string name = txtTenCat.Text;

            int idKiem = CategoryDAO.Instance.FindCategoryByName(name);
            if (name == "")
            {
                MessageBox.Show("Mời nhập tên");
                return;
            }
            if (name.Count() < 3)
            {
                MessageBox.Show("Tên loại món không được bé hơn 8 ký tự");
                return;
            }
            if (idKiem != 0)
            {
                MessageBox.Show("Món đã có trong danh sách");
                return;
            }

            else
                if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Đã thêm thành công");
                loadCategory();
                loadCategoryForComboBox();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn vào danh sách");
            }
        }

        private void btnSuaCat_Click(object sender, EventArgs e)
        {
            string name = txtTenCat.Text;
            int idCategory = int.Parse(txtIDCat.Text);

            if (name == "")
            {
                MessageBox.Show("Mời nhập tên");
                return;
            }
            if (name.Count() <3)
            {
                MessageBox.Show("Tên loại món không được bé hơn 8 ký tự");
                return;
            }
            if (CategoryDAO.Instance.UpdateDrinkCategory(idCategory, name))
            {
                MessageBox.Show("Sửa món thành công");
                loadCategory();
                loadCategoryForComboBox();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa");
            }
        }

        private void tcContainer_MouseClick(object sender, MouseEventArgs e)
        {
            if (tcContainer.SelectedTab.Name == "tabPage6")
            {

                fBanHang f = new fBanHang();
                f.ShowDialog();
                this.Close();
            }
        }



        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void rbtnNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;
            loaiNhanVien = int.Parse(rad.Tag.ToString());
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            string displayName = txtDisplayName.Text;
            string userName = txtUserName.Text;
            string matKhau = txtMatKhau.Text;
            string matKhauConfirm = txtMKConfirm.Text;
            if (displayName == "" || userName == "")
            {
                MessageBox.Show("Mời nhập đầy đủ thông tin");
                return;
            }
            if (userName.Contains(' '))
            {
                MessageBox.Show("Tên tài khoản không được có khoảng trắng");
                return;
            }
            else if(AccountDAO.Instance.FindAccountByUserName(userName) != 0)
            {
                MessageBox.Show("Tên tài khoản đã có, vui lòng đặt lại");
                return;
            }
            else
                if (matKhau == "")
            {
                MessageBox.Show("Mời nhập mật khẩu");
                return;
            }
            else
                if (matKhau != matKhauConfirm)
            {
                MessageBox.Show("Mời nhập mật khẩu trùng với mật khẩu xác nhận");
                return;
            }
            else if(matKhau.Count() >= 5)
            {
                MessageBox.Show("mật khẩu phải lớn hơn 8");
                return;
            }
            else if (matKhau.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được chứa ký tự rỗng");
                return;
            }
            else if (loaiNhanVien == 2)
            {
                MessageBox.Show("Mời chọn loại chức vụ");
                return;
            }
            else
            {
                if (AccountDAO.Instance.InsertAccount(userName, displayName, matKhau, loaiNhanVien))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                    loadAccountList();
                    txtMatKhau.Text = "";
                    txtMKConfirm.Text = "";
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm");
                }
            }
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            string name = txtBanTen.Text;

            int idKiem = TableDAO.Instance.FindTableByName(name);
            if (idKiem != 0)
            {
                MessageBox.Show("Bàn đã có trong danh sách");
                return;
            }

            else
                if (TableDAO.Instance.ThemBan(name))
            {
                MessageBox.Show("Đã bàn thành công");
                loadBan();

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn vào danh sách");
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtBanID.Text);
            string name = txtBanTen.Text;
            if (TableDAO.Instance.KiemTraTinhTrang(id) != "Có người")
            {

                if (TableDAO.Instance.XoaBan(id))
                {
                    MessageBox.Show("Danh mục đã được xóa");
                    loadBan();
                }
                else
                    MessageBox.Show("Có lỗi khi xóa danh mục");
            }
            else
                MessageBox.Show("Bàn đang có người");
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            string name = txtBanTen.Text;
            int idBan = int.Parse(txtBanID.Text);

            if (TableDAO.Instance.KiemTraTinhTrang(idBan) != "Có người")
            {
                if (TableDAO.Instance.CapNhatBan(idBan, name))
                {
                    MessageBox.Show("Sửa bàn thành công");
                    loadBan();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa");
                }
            }
            else
                MessageBox.Show("Bàn đang có người");
        }

        private void btnXoaCat_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDCat.Text);
            if (CategoryDAO.Instance.DeleteDrinkCategory(id))
            {
                MessageBox.Show("Danh mục đã được xóa");
                loadCategory();
                loadCategoryForComboBox();
                loadDrink();

            }
            else
                MessageBox.Show("Có lỗi khi xóa danh mục");
        }

        #endregion

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDAC.Text);
            string displayName = txtDisplayName.Text;
            string userName = txtUserName.Text;
            string matKhau = txtMatKhau.Text;
            string matKhauConfirm = txtMKConfirm.Text;
            
            if (matKhau != "")
            {
                if (matKhauConfirm != matKhau)
                {
                    MessageBox.Show("Mời nhập đúng mật khẩu xác nhận");

                }
                else if (matKhau.Contains(" "))
                {
                    MessageBox.Show("Mật khẩu không được chứa ký tự rỗng");
                    return;
                }

                else if (AccountDAO.Instance.SuaMatKhau(id, matKhau))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    loadAccountList();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa");
                }
            }
            else
            {
                if (displayName == "" || userName == "")
                {
                    MessageBox.Show("Mời nhập đầy đủ thông tin");
                    return;
                }
                else if (AccountDAO.Instance.FindAccountByUserName(userName) > 0)
                {
                    MessageBox.Show("Tên tài khoản đã có, vui lòng đặt lại");
                    return;
                }
                else if(userName.Contains(' '))
                {
                    MessageBox.Show("Tên tài khoản không được có dấu cách");
                    return;
                }
                else if(loaiNhanVien == 2)
                {
                    MessageBox.Show("Mời chọn loại nhân viên");
                    return;
                }
                else
                {
                    if (AccountDAO.Instance.SuaTaiKhoan(id,displayName, userName, loaiNhanVien))
                    {
                        MessageBox.Show("Đổi thông tin tài khoản thành công");
                        loadAccountList();
                        loaiNhanVien = 2;
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa");
                    }
                }
                
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDAC.Text);
            string displayName = txtDisplayName.Text;
            string userName = txtUserName.Text;
            if (Program.userName == userName)
            {
                MessageBox.Show("Không được xóa tài khoản đang được đăng nhập");
                return;
            }
            else 
            {
                if (AccountDAO.Instance.DeteleAccount(id))
                    MessageBox.Show("Xóa tài khoản thành công");
                else
                    MessageBox.Show("Xóa thất bại");
            }

        }

        private void numUDGiaBan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbLoaiDoUong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
