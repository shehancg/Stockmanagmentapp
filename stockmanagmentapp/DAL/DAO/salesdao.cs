using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.DAL.DTO;
using stockmanagmentapp.DAL;

namespace stockmanagmentapp.DAL.DAO
{
    public class salesdao : stockcontext, IDAO<SALE, salesdetaildto>
    {
        public bool Delete(SALE entity)
        {
            try
            {
                if(entity.id!=0)
                {
                    SALE sales = maindb.SALES.First(x => x.id == entity.id);
                    sales.isdeleted = true;
                    sales.deleteddate = DateTime.Today;
                    maindb.SaveChanges();
                    return true;
                }
                else if(entity.productid!=0)
                {
                    List<SALE> sales = maindb.SALES.Where(x => x.productid == entity.productid).ToList();
                    foreach(var item in sales)
                    {
                        item.isdeleted = true;
                        item.deleteddate = DateTime.Today;

                    }
                    maindb.SaveChanges();
                }
                else if(entity.customerid!=0)
                {
                    List<SALE> sales = maindb.SALES.Where(x => x.customerid == entity.customerid).ToList();
                    foreach(var item in sales)
                    {
                        item.isdeleted = true;
                        item.deleteddate = DateTime.Today;
                    }
                    maindb.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
                
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SALE entity)
        {
            try
            {
                maindb.SALES.Add(entity);
                maindb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<salesdetaildto> Select()
        {
            try
            {
                List<salesdetaildto> sales = new List<salesdetaildto>();
                var list = (from s in maindb.SALES
                            join p in maindb.PRODUCTs on s.productid equals p.id
                            join c in maindb.CUSTOMERs on s.customerid equals c.id
                            join category in maindb.CATEGORies on s.categoryid equals category.Id
                            select new
                            {
                                productname = p.productname,
                                customername = c.customername,
                                categoryname = category.categoryname,
                                productid = s.productid,
                                customerid = s.customerid,
                                salesid=s.id,
                                categoryid=s.categoryid,
                                salesprice = s.productsalesprice,
                                salesamount = s.productsalesamount,
                                salesdate = s.salesdate
                            }).OrderBy(x => x.salesdate).ToList();
                foreach(var item in list)
                {
                    salesdetaildto dto = new salesdetaildto();
                    dto.productname = item.productname;
                    dto.customername = item.customername;
                    dto.categoryname = item.categoryname;
                    dto.productid = item.productid;
                    dto.customerid = item.customerid;
                    dto.categoryid = item.categoryid;
                    dto.salesid = item.salesid;
                    dto.price = item.salesprice;
                    dto.salesamount = item.salesamount;
                    dto.salesdate = item.salesdate;
                    sales.Add(dto);
                }
                return sales;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(SALE entity)
        {
            throw new NotImplementedException();
        }
    }
}
