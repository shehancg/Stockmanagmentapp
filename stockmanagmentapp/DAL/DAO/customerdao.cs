﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.DAL.DAO;
using stockmanagmentapp.DAL;
using stockmanagmentapp.DAL.DTO;

namespace stockmanagmentapp.DAL.DAO
{
    class customerdao : stockcontext, IDAO<CUSTOMER, customerdetaildto>
    {
        public bool Delete(CUSTOMER entity)
        {
            try
            {
                CUSTOMER customer = maindb.CUSTOMERs.First(x => x.id == entity.id);
                customer.isdeleted = true;
                customer.deleteddate = DateTime.Today;
                maindb.SaveChanges();
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

        public bool Insert(CUSTOMER entity)
        {
            try
            {
                maindb.CUSTOMERs.Add(entity);
                maindb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<customerdetaildto> Select()
        {
            try
            {
                List<customerdetaildto> customer = new List<customerdetaildto>();
                var list = maindb.CUSTOMERs.Where(x=>x.isdeleted==false).ToList();
                foreach(var item in list)
                {
                    customerdetaildto dto = new customerdetaildto();
                    dto.customername = item.customername;
                    dto.id = item.id;
                    customer.Add(dto);
                }
                return customer;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Update(CUSTOMER entity)
        {
            try
            {
                CUSTOMER customer = maindb.CUSTOMERs.First(x => x.id == entity.id);
                customer.customername = entity.customername;
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
