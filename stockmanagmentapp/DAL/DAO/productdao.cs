using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.DAL;
using stockmanagmentapp.DAL.DTO;

namespace stockmanagmentapp.DAL.DAO
{
    class productdao : stockcontext, IDAO<PRODUCT, productdetaildto>
    {
        public bool Delete(PRODUCT entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PRODUCT entity)
        {
            try
            {
                maindb.PRODUCTs.Add(entity);
                maindb.SaveChanges();
                return true; 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<productdetaildto> Select()
        {
            try
            {
                List<productdetaildto> product = new List<productdetaildto>();
                var list = (from p in maindb.PRODUCTs
                            join c in maindb.CATEGORies on p.categoryid equals c.Id
                            select new
                            {
                                productname = p.productname,
                                categoryname = c.categoryname,
                                stockamount = p.stockamount,
                                price = p.price,
                                productid = p.id,
                                categoryid = c.Id
                            }).OrderBy(x => x.productname).ToList();
                foreach(var item in list)
                {
                    productdetaildto dto = new productdetaildto();
                    dto.productname = item.productname;
                    dto.categoryname = item.categoryname;
                    dto.stockamount = item.stockamount;
                    dto.price = item.price;
                    dto.productid = item.price;
                    dto.categoryid = item.categoryid;
                    product.Add(dto);
                }
                return product;
                          
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(PRODUCT entity)
        {
            throw new NotImplementedException();
        }
    }
}
