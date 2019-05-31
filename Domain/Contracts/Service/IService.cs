using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Service
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAllAsync(int userID);
        Task SaveAsync(T tag);
        Task<T> GetByIDAsync(int tagID);
        void Delete(T tag);
    }
}
