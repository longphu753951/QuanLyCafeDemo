using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set {TableDAO.instance = value;}
        }
        private TableDAO() { }
        public List<TableDTO> LoadTableList()
        {
            List<TableDTO> tableList = new List<TableDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("EXEC dbo.USP_GetTableList");
            foreach(DataRow item in data.Rows)
            {
                TableDTO table = new TableDTO(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool ThemBan(string name)
        {
            string query = "INSERT dbo.TableDrink(name)VALUES( N'" + name +"')";
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaBan(int id)
        {
            string query = string.Format("DELETE dbo.TableDrink WHERE id = {0}",id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool CapNhatBan(int id, string name)
        {
            string query = string.Format("UPDATE dbo.TableDrink SET name = N'{0}' WHERE id = {1} ", name, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public int FindTableByName(string name)
        {
            try
            {
                string result = DataProvider.Instance.ExcuteScalar("SELECT id FROM dbo.TableDrink WHERE name LIKE N'%" + name + "%'").ToString();
                return int.Parse(result);
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }
        public string KiemTraTinhTrang(int id)
        {
            string query = string.Format("SELECT status FROM dbo.TableDrink WHERE id = {0} ", id);
            string result = DataProvider.Instance.ExcuteScalar(query).ToString();
            return result;
        }
    }
}
