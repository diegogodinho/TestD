using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Service
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAllAsync();        
        Task<T> GetByIDAsync(int id);
        T GetByID(int id);
        void Delete(T entity);
        T Add(T entity);        
        void Update(T entity);
    }
}
