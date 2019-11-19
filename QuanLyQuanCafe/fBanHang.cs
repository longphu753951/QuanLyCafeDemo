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
    public partial class fBanHang : Form
    {
        private static string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
        private static string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
        private static int w = int.Parse(screenWidth);
        private static int h = int.Parse(screenHeight);
        private int drinkIDCache = 0;
        public fBanHang()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            LoadTable();
            
            
        }
        #region Method
        void LoadTable()
        {
            FLPBan.Controls.Clear();
            List<TableDTO> tableList = TableDAO.Instance.LoadTableList();
            foreach(TableDTO item in tableList)
            {
                Button btn = new Button() {Width = FLPBan.Width*27/100,Height= FLPBan.Height*30/100 };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                FLPBan.Controls.Add(btn);
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
            }
        }
        void ShowBill(int id)
        {
            lsvOrder.Items.Clear();
            List<MenuDTO> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach(MenuDTO item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.DrinkName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += int.Parse(item.TotalPrice.ToString());
                lsvOrder.Items.Add(lsvItem);
            }
            
            txttotalPrice.Text = totalPrice.ToString();
        }
        void loadCategory()
        {
            List<CategoryDTO> listCategory = CategoryDAO.Instance.GetListCategory();
            cbLoaiSanPham.DataSource = listCategory;
            cbLoaiSanPham.DisplayMember = "Name";
        }
        void loadDrinkListByCategoryID(int maCategory)
        {
            flpDoUong.Controls.Clear();
            List<DrinkDTO> tableList = DrinkDAO.Instance.listDrink(maCategory);
            foreach (DrinkDTO item in tableList)
            {
                Button btnDoUong = new Button() { Width = flpDoUong.Width * 30 / 100, Height = FLPBan.Height * 20 / 100 };
                btnDoUong.Text = item.Name + Environment.NewLine + item.Price;
                flpDoUong.Controls.Add(btnDoUong);
                btnDoUong.Click += btnDoUong_Click;
                btnDoUong.Tag = item;
            }
        }
        #endregion
        #region Event
        private void btnDoUong_Click(object sender, EventArgs e)
        {
            int idDrink = ((sender as Button).Tag as DrinkDTO).ID;
            drinkIDCache = idDrink;
            string monChon = ((sender as Button).Tag as DrinkDTO).Name;
            lbMonDangChon.Text = monChon;
        }
        private void fBanHang_Load(object sender, EventArgs e)
        {
            fLPContainer.Size = new Size(w, h);
            gBTTSP.Width = w * 30 / 100;
            gBTTSP.Height = h * 90 / 100;
            gBOrder.Width = w * 40 / 100;
            gBOrder.Height = h * 70 / 100;
            gbBan.Width = w * 28 / 100;
            gbBan.Height = h * 85 / 100;
            panelTinhTien.Width = gBOrder.Width;
            panelTinhTien.Height = h * 19 / 100;
            FLPBan.Width = gbBan.Width * 97 / 100;
            FLPBan.Height = gbBan.Height * 97 / 100;
            lsvOrder.Width = gBOrder.Width * 98 / 100;
            lsvOrder.Height = gBOrder.Height * 96 / 100;
            cbLoaiSanPham.Width = gBTTSP.Width * 98 / 100;
            flpDoUong.Width = gBTTSP.Width * 98 / 100;
            flpDoUong.Height = gBTTSP.Height * 84 / 100;
            btnXoa.Width = txtSoLuong.Width = btnSoLuongXacNhan.Width = gBTTSP.Width * 20 / 100;
            flpTTSP.Width = gBTTSP.Width * 98 / 100;
            flpStaff.Width = gbBan.Width;
            flpStaff.Height = h * 13 / 100;
            btnDangXuat.Width = btnDangXuat.Height = flpStaff.Height * 97 / 100; 
            btnAdmin.Width = btnAdmin.Height = flpStaff.Height * 97 / 100;
            if(Program.loaiChucVu != 1)
            {
                btnAdmin.Visible = false;
            }
            loadCategory();
            LoadTable();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableDTO).ID;
            string tableName = ((sender as Button).Tag as TableDTO).Name;
            txtTenBan.Text = tableName;
            string tinhTrang = ((sender as Button).Tag as TableDTO).Status;
            txtTinhTrang.Text = tinhTrang;
            ShowBill(tableID);
            string b = BillDAO.Instance.getDayBillByTableID(tableID);
            lblNgayHienTai.Text = b;
            lsvOrder.Tag = (sender as Button).Tag;
        }
        private void txtSoLuong_Click(object sender, EventArgs e)
        {
            fSoLuong a = new fSoLuong();
            
            a.ShowDialog();
       
            txtSoLuong.Text = a.soLuong;
            a.soLuong = null;
        }

        private void btnSoLuongXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lsvOrder.Tag as TableDTO;
                int idBill = BillDAO.Instance.GetUncheckBillByTableID(table.ID);
                string a = txtSoLuong.Text;
                int count = int.Parse(txtSoLuong.Text);
                if(count <= 0 || count >= 99)
                {
                    MessageBox.Show("Số lượng không được bằng 0 hoặc lớn hơn 99");
                    return;
                }
                
                if (drinkIDCache == 0)
                {
                    throw new Exception("Mời chọn món");
                }
                if (idBill == -1)
                {
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), drinkIDCache, count);
                    
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, drinkIDCache, count);
                }
                lbMonDangChon.Text = "";
                string b = BillDAO.Instance.getDayBillByTableID(table.ID);
                lblNgayHienTai.Text = b;
                ShowBill(table.ID);
                txtSoLuong.Text = "";
                drinkIDCache = 0;
                
                LoadTable();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Mời chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Vui lòng chọn số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cbLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            CategoryDTO selected = cb.SelectedItem as CategoryDTO;
            id = selected.ID;
            loadDrinkListByCategoryID(id);

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            for (int i = lsvOrder.Items.Count - 1; i >= 0; i--)
            {
                if (lsvOrder.Items[i].Selected)
                {
                    TableDTO banChon = lsvOrder.Tag as TableDTO;
                    int idBill = BillDAO.Instance.GetUncheckBillByTableID(banChon.ID);

                    string drinkName = lsvOrder.Items[i].SubItems[0].Text;
                    BillInfoDAO.Instance.DeleteBillInfo(idBill, drinkName);
                    int a = int.Parse(lsvOrder.Items[i].SubItems[3].Text);
                    txttotalPrice.Text = (int.Parse(txttotalPrice.Text) - a).ToString();
                    lsvOrder.Items[i].Remove();

                }
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lsvOrder.Tag as TableDTO;
                int idBill = BillDAO.Instance.GetUncheckBillByTableID(table.ID);
                if (idBill != -1)
                {
                    if (MessageBox.Show("Bạn có muốn xóa chứ ?", "Xóa bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == System.Windows.Forms.DialogResult.Yes)
                    {
                        BillDAO.Instance.huyBan(idBill, table.ID);
                        ShowBill(table.ID);
                        string b = BillDAO.Instance.getDayBillByTableID(table.ID);
                        lblNgayHienTai.Text = b;
                        lblNgayHienTai.Text = "";
                        txtTenBan.Text = "";
                        txtTinhTrang.Text = "";
                        LoadTable();
                    }

                }
               
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Bàn chưa có hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lsvOrder.Tag as TableDTO;
                int idBill = BillDAO.Instance.GetUncheckBillByTableID(table.ID);
                double totalPrice = Convert.ToDouble(txttotalPrice.Text);
                if (idBill != -1)
                {
                    if (MessageBox.Show("Bạn có muốn thanh toán chứ ?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        BillDAO.Instance.CheckOutBill(idBill,(float)totalPrice);
                        ShowBill(table.ID);
                        BillDAO.Instance.UpdateBillAfterCheckOut(idBill);
                        lblNgayHienTai.Text = "";
                        txtTenBan.Text = "";
                        txtTinhTrang.Text = "";
                        LoadTable();
                    }

                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Mời chọn bàn để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lsvOrder_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lsvOrder.Columns[e.ColumnIndex].Width;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dRThoat = MessageBox.Show("Bạn có muốn đăng xuất không ?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dRThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.InsertDrink += f_InsertDrink;
            f.DeleteDrink += f_DeleteDrink;
            f.UpdateDrink += f_UpdateDrink;
            f.ShowDialog();
            this.Close();
        }

        void f_UpdateDrink(object sender, EventArgs e)
        {
            loadDrinkListByCategoryID((cbLoaiSanPham.SelectedItem as CategoryDTO).ID);
            if (lsvOrder.Tag != null)
                ShowBill((lsvOrder.Tag as TableDTO).ID);
        }

        void f_DeleteDrink(object sender, EventArgs e)
        {
            loadDrinkListByCategoryID((cbLoaiSanPham.SelectedItem as CategoryDTO).ID);
            if (lsvOrder.Tag != null)
                ShowBill((lsvOrder.Tag as TableDTO).ID);
            LoadTable();
        }

        void f_InsertDrink(object sender, EventArgs e)
        {
            loadDrinkListByCategoryID((cbLoaiSanPham.SelectedItem as CategoryDTO).ID);
            if(lsvOrder.Tag != null)
                ShowBill((lsvOrder.Tag as TableDTO).ID);
        }
    }
}
