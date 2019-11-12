using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }
        private BillInfoDAO() { }
        public List<BillInfoDTO> GetListBillInfo(int id)
        {
            List<BillInfoDTO> listBillInfo = new List<BillInfoDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);
            foreach(DataRow item in data.Rows)
            {
                BillInfoDTO info  =new BillInfoDTO(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }
        public void InsertBillInfo(int idBill,int idFood, int count)
        {
            
            
                DataProvider.Instance.ExcuteNonQuery("USP_InsertBillInfo @idBill , @idFood , @count ", new object[] { idBill, idFood, count });
           
        }
        public void DeleteBillInfo(int idBill, string drinkName)
        {
            DataProvider.Instance.ExcuteNonQuery("EXEC dbo.USP_DeleteBillInfo @idBill , @drinkName", new object[] { idBill, drinkName });
        }
        public void DeleteBillInfoByDrinkId(int idDrink)
        {
            DataProvider.Instance.ExcuteNonQuery("DELETE dbo.BillInfo Where idDrink = " + idDrink);
        }
    }
}
