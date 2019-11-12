﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class TableDTO
    {
        
        private int iD;
        private string name;
        private string status;
        public TableDTO(int id, string name,string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }
        public TableDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name =row["name"].ToString();
            this.Status = row["status"].ToString();

        }
        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
