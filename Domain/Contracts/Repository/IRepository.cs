using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task SaveAsync(T entity);
        Task<T> GetByIDAsync(int id);
        void Delete(T entity);
    }
}
