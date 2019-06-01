using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Service
{
    public interface IService<T> where T : class
    {        
        T Add(T entity);
    }
}
