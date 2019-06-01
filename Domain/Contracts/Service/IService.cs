using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Service
{
    public interface IService<T> where T : class
    {   
        void Delete(T entity);
        T Add(T entity);
    }
}
