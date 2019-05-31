using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class Service<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> repositoryBase;

        public Service(IRepository<T> repository)
        {
            this.repositoryBase = repository;
        }

        public T Add(T entity)
        {
            return repositoryBase.Add(entity);
        }

        public void Delete(T entity)
        {
            repositoryBase.Delete(entity);
        }

        public Task<List<T>> GetAllAsync()
        {
            return repositoryBase.GetAllAsync();
        }

        public Task<T> GetByIDAsync(int id)
        {
            return repositoryBase.GetByIDAsync(id);
        }

        public Task SaveAsync(T entity)
        {
            return repositoryBase.SaveAsync(entity);
        }
    }
}
