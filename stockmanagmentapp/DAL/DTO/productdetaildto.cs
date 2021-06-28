using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockmanagmentapp.DAL.DTO
{
    public class productdetaildto
    {
        public string productname { get; set; }
        public string categoryname { get; set; }
        public int stockamount { get; set; }
        public int price { get; set; }
        public int productid { get; set; }
        public int categoryid { get; set; }

    }
}
