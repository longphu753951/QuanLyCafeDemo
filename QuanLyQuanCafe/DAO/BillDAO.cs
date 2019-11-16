using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        public int GetUncheckBillByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0");
            if(data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public string getDayBillByTableID(int id)
        {
            string a =null;
            string query = "SELECT DateCheckIn FROM dbo.Bill WHERE idTable = "+ id + " AND status = 0 ";
            object data = (DataProvider.Instance.ExcuteScalar(query));
            if (data != null)
                a = data.ToString();
            return a;
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("EXEC USP_InsertBill @idTable", new object[] { id });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
        public void huyBan(int idBill,int idTable)
        {
            DataProvider.Instance.ExcuteNonQuery("EXEC dbo.USP_DeleteBill @idBill ", new object[] { idBill });
            DataProvider.Instance.ExcuteNonQuery("UPDATE dbo.TableDrink SET status = N'Trống' WHERE id = " + idTable);
        }
        public void CheckOutBill(int idBill,float totalPrice)
        {
            DataProvider.Instance.ExcuteNonQuery("UPDATE dbo.Bill SET status = 1 , totalPrice = "+ totalPrice  + " WHERE id = "+ idBill);
        }
        public DataTable GetBillByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExcuteQuery("EXEC USP_GetListBillByDate @checkin , @checkOut", new object[] { checkIn, checkOut });
        }
        public void UpdateBillAfterCheckOut(int id)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format("UPDATE dbo.Bill SET idTable = NULL WHERE id = {0}",id));
        }
    }
    


}
