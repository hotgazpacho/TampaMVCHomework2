using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework2.Models
{
    public class CustomerActiveRecordRepository : IRepository<ICustomer>
    {
        #region IRepository<ICustomer> Members

        public IEnumerable<ICustomer> FindAll()
        {
            return Customer.FetchAll() as IEnumerable<ICustomer>;
        }

        public ICustomer FindById(long Id)
        {
            return Customer.FetchById(Id) as ICustomer;
        }

        public void Insert(ICustomer entity)
        {
            ((Customer)entity).Save();
        }

        public void Update(ICustomer entity)
        {
            ((Customer)entity).Save();
        }

        public void Delete(ICustomer entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteById(long Id)
        {
            Customer.DeleteById(Id);
        }

        #endregion
    }
}
