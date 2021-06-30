using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.DAL.DTO;
using stockmanagmentapp.DAL.DAO;
using stockmanagmentapp.DAL;
using stockmanagmentapp.BLL;

namespace stockmanagmentapp.BLL
{
    class salesbll : IBLL<salesdetaildto, salesdto>
    {
        salesdao dao = new salesdao();
        productdao productdao = new productdao();
        categorydao categorydao = new categorydao();
        customerdao customerdao = new customerdao();
        public bool Delete(salesdetaildto entity)
        {
            throw new NotImplementedException();
        }

        public bool Getback(salesdetaildto entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(salesdetaildto entity)
        {
            SALE sales = new SALE();
            sales.categoryid = entity.categoryid;
            sales.productid = entity.productid;
            sales.customerid = entity.customerid;
            sales.productsalesprice = entity.price;
            sales.productsalesamount = entity.salesamount;
            sales.salesdate = entity.salesdate;
            dao.Insert(sales);
            PRODUCT product = new PRODUCT();
            product.id = entity.productid;
            int temp = entity.stockamount - entity.salesamount;
            product.stockamount = temp;
            productdao.Update(product);
            return true;
        }

        public salesdto Select()
        {
            salesdto dto = new salesdto();
            dto.product = productdao.Select();
            dto.customer = customerdao.Select();
            dto.categories = categorydao.Select();
            dto.sales = dao.Select();
            return dto;
        }

        public bool Update(salesdetaildto entity)
        {
            throw new NotImplementedException();
        }
    }
}
