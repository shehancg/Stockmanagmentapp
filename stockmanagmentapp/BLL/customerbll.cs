using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.DAL.DTO;
using stockmanagmentapp.DAL.DAO;
using stockmanagmentapp.DAL;

namespace stockmanagmentapp.BLL
{
    class customerbll : IBLL<customerdetaildto, customerdto>
    {
        customerdao dao = new customerdao();
        public bool Delete(customerdetaildto entity)
        {
            throw new NotImplementedException();
        }

        public bool Getback(customerdetaildto entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(customerdetaildto entity)
        {
            CUSTOMER customer = new CUSTOMER();
            customer.customername = entity.customername;
            return dao.Insert(customer);
        }

        public customerdto Select()
        {
            customerdto dto = new customerdto();
            dto.customer = dao.Select();
            return dto;
        }

        public bool Update(customerdetaildto entity)
        {
            throw new NotImplementedException();
        }
    }
}
