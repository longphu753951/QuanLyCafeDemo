using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }
        public List<MenuDTO> GetListMenuByTable(int id)
        {
            List<MenuDTO> listMenu = new List<MenuDTO>();
            string query = "SELECT d.name, bi.count,d.price,d.price*bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Drink AS d WHERE bi.idBill = b.id AND status = 0 AND bi.idDrink = d.id AND b.idTable = "+ id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                MenuDTO menu = new MenuDTO(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
