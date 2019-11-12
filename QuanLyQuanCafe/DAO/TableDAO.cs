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
    }
}
