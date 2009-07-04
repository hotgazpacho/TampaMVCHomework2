using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        T FindById(long Id);
        
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
        void DeleteById(long Id);
    }
}
