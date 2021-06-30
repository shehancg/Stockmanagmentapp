using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.mainforms;
using stockmanagmentapp.DAL.DAO;
using stockmanagmentapp.DAL.DTO;
using stockmanagmentapp.DAL;

namespace stockmanagmentapp.BLL
{
    class productbll : IBLL<productdetaildto, productdto>
    {
        categorydao categorydao = new categorydao();
        productdao dao = new productdao();
        salesdao salesdao = new salesdao();
        public bool Delete(productdetaildto entity)
        {
            PRODUCT product = new PRODUCT();
            product.id = entity.productid;
            dao.Delete(product);
            SALE sales = new SALE();
            sales.productid = entity.productid;
            salesdao.Delete(sales);
            return true;

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
            PRODUCT product = new PRODUCT();
            product.id = entity.productid;
            product.price = entity.price;
            product.productname = entity.productname;
            product.stockamount = entity.stockamount;
            product.categoryid = entity.categoryid;
            return dao.Update(product);
        }
    }
}
