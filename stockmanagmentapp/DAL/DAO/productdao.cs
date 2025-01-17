﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.mainforms;
using stockmanagmentapp.DAL;
using stockmanagmentapp.DAL.DTO;
using stockmanagmentapp.BLL;

namespace stockmanagmentapp.DAL.DAO
{
    class productdao : stockcontext, IDAO<PRODUCT, productdetaildto>
    {
        public bool Delete(PRODUCT entity)
        {
            try
            {
                if(entity.id!=0)
                {
                    PRODUCT product = maindb.PRODUCTs.First(x => x.id == entity.id);
                    product.isdeleted = true;
                    product.deleteddate = DateTime.Today;
                    maindb.SaveChanges();
                }
                else if(entity.categoryid!=0)
                {
                    List<PRODUCT> list = maindb.PRODUCTs.Where(x => x.categoryid == entity.categoryid).ToList();
                    foreach(var item in list)
                    {
                        item.isdeleted = true;
                        item.deleteddate = DateTime.Today;
                        List<SALE> sales = maindb.SALES.Where(x => x.productid == item.id).ToList();
                        foreach(var item2 in sales)
                        {
                            item2.isdeleted = true;
                            item2.deleteddate = DateTime.Today;
                        }
                        maindb.SaveChanges();
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
                var list = (from p in maindb.PRODUCTs.Where(x=>x.isdeleted==false)
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
            try
            {
                PRODUCT product = maindb.PRODUCTs.First(x => x.id == entity.id);
                if(entity.categoryid == 0)
                {
                    product.stockamount = entity.stockamount;
                    
                }
                else
                {
                    product.productname = entity.productname;
                    product.price = entity.price;
                    product.categoryid = entity.categoryid;
                }
                maindb.SaveChanges();
                return true;
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}
