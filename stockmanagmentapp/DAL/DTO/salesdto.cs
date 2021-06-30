using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockmanagmentapp.DAL.DTO
{
    public class salesdto
    {
        public List<salesdetaildto> sales { get; set; }
        public List<customerdetaildto> customer { get; set; }
        public List<productdetaildto> product { get; set; }
        public List<cateogorydetaildto> categories { get; set; }
    }
}
