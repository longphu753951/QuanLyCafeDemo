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
        private static int w = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
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
        void loadDrinkdmin()
        {
            flp8.Width=dtvCategory .Width= dtvDoUong.Width = flp1.Width = tcContainer.Width * 45 / 100;
            dtvCategory .Height= dtvDoUong.Height = tcContainer.Height * 80 / 100;
            btnThemCat.Width = btnXoaCat.Width = btnSuaCat.Width =btnThem.Width = btnXoa.Width = btnSua.Width = flp1.Width * 24 / 100;
            flp7.Width=flpDoUongDTV.Width = ctnThongTinDoUong.Width = tcContainer.Width * 50 / 100;
            flp7.Height=flpDoUongDTV.Height = ctnThongTinDoUong.Height = tcContainer.Height;
            flp8.Height=flp1.Height = flpDoUongDTV.Height * 14 / 100;
            btnThemCat.Height = btnXoaCat.Height = btnSuaCat.Height = btnThem.Height = btnXoa.Height = btnSua.Height = flp1.Height * 90 / 100;
            flp2.Height = ctnThongTinDoUong.Height * 15 / 100;
            flp3.Height = flp4.Height = flp5.Height = flp6.Height = ctnThongTinDoUong.Height * 12 / 100;
            flp2.Width=flp3.Width = flp4.Width = flp5.Width = flp6.Width = ctnThongTinDoUong.Width * 90 / 100 ;
            btnTim.Size = new Size(flp2.Height, flp2.Height * 50 / 100);
           
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
        void LoadAll()
        {
            dtvCategory.DataSource = categoryList;
            dtvDoUong.DataSource = drinkList;
            loadDrink();
            loadCategory();
            loadCategoryForComboBox();
            loadDateTimePicker();
            loadDrinkdmin();
            addDrinkBinding();
            addCategoryBinding();
        }
        #endregion
        #region events 
        private void fAdmin_Load(object sender, EventArgs e)
        {
            loadDateTimePicker();
            tcContainer.Width = w;
            tcContainer.Height = h;
            panel1.Width = tcContainer.Width*99/100;
            dtgHoaDon.Width = w;
            dtgHoaDon.Height = tcContainer.Height - panel1.Height;
            loadListByDay(dtpCheckIn.Value, dtpCheckOut.Value);
            loadDrinkdmin();
        }

        private void btnKiemKe_Click(object sender, EventArgs e)
        {
            loadListByDay(dtpCheckIn.Value, dtpCheckOut.Value);
        }
        private void dtvDoUong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            loadDrink();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

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
            int idKiem = DrinkDAO.Instance.FindDrinkByName(name);
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
            add { insertDrink += value;}
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

        #endregion

        private void btnThemCat_Click(object sender, EventArgs e)
        {
            string name = txtTenCat.Text;
            
            int idKiem = CategoryDAO.Instance.FindCategoryByName(name);
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
            string name =txtTenCat.Text;
            int idCategory = int.Parse(txtIDCat.Text);
            

            if (CategoryDAO.Instance.UpdateDrinkCategory(idCategory,name))
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
            if(tcContainer.SelectedTab.Name == "tabPage6")
            {
               
                    fBanHang f = new fBanHang();
                    f.ShowDialog();
                    this.Close();
            }
        }

        private void btnXoaCat_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDCat.Text);
            if (CategoryDAO.Instance.DeleteDrinkCategory(id))
            {
                MessageBox.Show("Danh mục đã được xóa");
                loadCategory();
                loadCategoryForComboBox();


            }
            else
                MessageBox.Show("Có lỗi khi xóa danh mục");
        }
    }
}
