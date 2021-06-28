using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockmanagmentapp.DAL.DTO
{
    public class productdto
    {
        public List<productdetaildto> product { get; set; }
        public List<cateogorydetaildto> category { get; set; }
    }
}
