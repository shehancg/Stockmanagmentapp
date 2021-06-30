using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.BLL;
using stockmanagmentapp.DAL.DAO;

namespace stockmanagmentapp.DAL.DTO
{
    public class salesdetaildto
    {
        public string customername { get; set; }
        public string productname { get; set; }
        public string categoryname { get; set; }
        public int customerid { get; set; }
        public int productid { get; set; }
        public int categoryid { get; set; }
        public int salesamount { get; set; }
        public int price { get; set; }
        public DateTime salesdate { get; set; }
        public int stockamount { get; set; }
        public int salesid { get; set; }
    }
}
