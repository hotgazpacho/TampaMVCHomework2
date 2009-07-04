using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework2.Models
{
    public class CustomerActiveRecordRepository : IRepository<Customer>
    {
        #region IRepository<Customer> Members

        public IEnumerable<Customer> FindAll()
        {
            return Customer.FetchAll();
        }

        public Customer FindById(long Id)
        {
            return Customer.FetchById(Id);
        }

        public void Insert(Customer entity)
        {
            ((Customer)entity).Save();
        }

        public void Update(Customer entity)
        {
            ((Customer)entity).Save();
        }

        public void Delete(Customer entity)
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
