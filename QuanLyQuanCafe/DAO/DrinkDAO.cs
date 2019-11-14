using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class DrinkDAO
    {
        private static DrinkDAO instance;

        public static DrinkDAO Instance
        {
            get { if (instance == null) instance = new DrinkDAO(); return DrinkDAO.instance; }
            private set { DrinkDAO.instance = value; }
        }
        private DrinkDAO() { }
        public List<DrinkDTO> listDrink(int idCategory)
        {
            List<DrinkDTO> ListDrink = new List<DrinkDTO>();
            string query = "SELECT * FROM dbo.Drink WHERE idCategory =" + idCategory;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                DrinkDTO drink = new DrinkDTO(item);
                ListDrink.Add(drink);
            }
            return ListDrink;
        }
        public List<DrinkDTO> LoadListDrinkAll()
        {
            List<DrinkDTO> ListDrink = new List<DrinkDTO>();
            string query = "SELECT * FROM dbo.Drink ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DrinkDTO drink = new DrinkDTO(item);
                ListDrink.Add(drink);
            }
            return ListDrink;
        }
        public bool InsertDrink(string name, int id, float price)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("EXEC dbo.USP_InsertDrink @name , @idCategory , @Price ", new object[] {name, id, price });
            return result > 0;
        }
        public bool UpdateDrink(int id,string name, int idCategory, float price)
        {
            string query = string.Format("UPDATE dbo.Drink SET name = N'{0}',idCategory = {1} , price = {2} WHERE id = {3}", name , idCategory , price , id );
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public int FindDrinkByName(string name)
        {
            try
            {
                string result = DataProvider.Instance.ExcuteScalar("SELECT id FROM dbo.Drink WHERE name LIKE N'%" + name + "%'").ToString();
                return int.Parse(result);
            }
            catch(NullReferenceException)
            {
                return 0;
            }
        }

        public bool DeleteDrink(int idDrink)
        {
            BillInfoDAO.Instance.DeleteBillInfoByDrinkId(idDrink);
            string query = string.Format("DELETE dbo.Drink WHERE id = {0}", idDrink);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public void DeleteDrinkByCategory(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByDrinkCategory(id);
            DataProvider.Instance.ExcuteNonQuery(string.Format("DELETE dbo.Drink WHERE idCategory = {0}", id));
        }
    }
}
