using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repository
{
    public interface IRepository<T> where T : class
    {        
        void Delete(T entity);
        T Add(T entity);        
        void Update(T entity);
    }
}
