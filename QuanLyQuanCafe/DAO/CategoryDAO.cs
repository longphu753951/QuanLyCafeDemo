using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }
        public List<CategoryDTO> GetListCategory()
        {
            List<CategoryDTO> ListCategory = new List<CategoryDTO>();
            string query = "SELECT * FROM dbo.DrinkCategory";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                CategoryDTO category = new CategoryDTO(item);
                ListCategory.Add(category);
            }
            return ListCategory;
        }
        public CategoryDTO GetCategoryByID(int id)
        {
            CategoryDTO category = null;
            string query = "SELECT * FROM dbo.DrinkCategory WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                category = new CategoryDTO(item);
               
            }
            return category;
            
        }
        public int FindCategoryByName(string name)
        {
            try
            {
                string result = DataProvider.Instance.ExcuteScalar("SELECT id FROM dbo.DrinkCategory WHERE name = N'" + name + "'").ToString();
                return int.Parse(result);
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }
        public bool InsertCategory(string name)
        {
            string query = "INSERT dbo.DrinkCategory (name) VALUES ( N'" +name +"' ) ";
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDrinkCategory(int id, string name)
        {
            string query = string.Format("UPDATE dbo.DrinkCategory SET name = N'{0}' WHERE id = {1}", name, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDrinkCategory(int id)
        {
            DrinkDAO.Instance.DeleteDrinkByCategory(id);
            string query = string.Format("DELETE dbo.DrinkCategory WHERE id = {0}", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
