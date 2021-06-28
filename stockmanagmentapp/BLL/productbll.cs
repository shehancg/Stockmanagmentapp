using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.DAL.DAO;
using stockmanagmentapp.DAL.DTO;
using stockmanagmentapp.DAL;

namespace stockmanagmentapp.BLL
{
    class productbll : IBLL<productdetaildto, productdto>
    {
        categorydao categorydao = new categorydao();
        productdao dao = new productdao();
        public bool Delete(productdetaildto entity)
        {
            throw new NotImplementedException();
        }

        public bool Getback(productdetaildto entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(productdetaildto entity)
        {
            PRODUCT product = new PRODUCT();
            product.productname = entity.productname;
            product.categoryid = entity.categoryid;
            product.price = entity.price;
            return dao.Insert(product);
        }

        public productdto Select()
        {
            productdto dto = new productdto();
            dto.category = categorydao.Select();
            dto.product = dao.Select();
            return dto;
        }

        public bool Update(productdetaildto entity)
        {
            throw new NotImplementedException();
        }
    }
}
