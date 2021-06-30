using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.DAL.DTO;
using stockmanagmentapp.DAL;
using stockmanagmentapp.DAL.DAO;

namespace stockmanagmentapp.BLL
{
    public class categorybll : IBLL<cateogorydetaildto, categorydto>
    {
        categorydao dao = new categorydao();
        productdao productdao = new productdao();
        public bool Delete(cateogorydetaildto entity)
        {
            CATEGORY category = new CATEGORY();
            category.Id = entity.id;
            dao.Delete(category);
            PRODUCT product = new PRODUCT();
            product.categoryid = entity.id;
            productdao.Delete(product);
            return true;
        }

        public bool Getback(cateogorydetaildto entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(cateogorydetaildto entity)
        {
            CATEGORY category = new CATEGORY();
            category.categoryname = entity.categoryname;
            return dao.Insert(category);
        }

        public categorydto Select()
        {
            categorydto dto = new categorydto();
            dto.categories = dao.Select();
            return dto;
        }

        public bool Update(cateogorydetaildto entity)
        {
            CATEGORY category = new CATEGORY();
            category.categoryname = entity.categoryname;
            category.Id = entity.id;
            return dao.Update(category);
        }
    }
}
