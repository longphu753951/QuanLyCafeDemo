using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfoDTO
    {
        public BillInfoDTO(int id, int idBill, int idDrink, int count)
        {
            this.ID = id;
            this.IdBill = idBill;
            this.IdDrink = idDrink;
            this.Count = count;
        }
        public BillInfoDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IdBill = (int)row["idBill"];
            this.IdDrink = (int)row["idDrink"];
            this.Count = (int)row["count"];
        }
        private int iD;
        private int idBill;
        private int idDrink;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdDrink { get => idDrink; set => idDrink = value; }
        public int Count { get => count; set => count = value; }
    }
}
