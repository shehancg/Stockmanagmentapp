using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockmanagmentapp.DAL.DTO;

namespace stockmanagmentapp.DAL.DAO
{
    public class categorydao : IDAO<CATEGORY, cateogorydetaildto>
    {
        public bool Delete(CATEGORY entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CATEGORY entity)
        {
            try
            {

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<cateogorydetaildto> Select()
        {
            throw new NotImplementedException();
        }

        public bool Update(CATEGORY entity)
        {
            throw new NotImplementedException();
        }
    }
}
