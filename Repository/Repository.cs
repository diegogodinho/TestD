using Domain.Contracts.Repository;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext context;
        private readonly DbSet<T> entitySet;

        public Repository(DataContext context)
        {
            this.context = context;
            entitySet = context.Set<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return entitySet.ToListAsync();
        }

        public Task<T> GetByIDAsync(int id)
        {
            return entitySet.FindAsync(id);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }        

        public Task SaveAsync(T entity)
        {
            context.Add(entity);
            return context.SaveChangesAsync();
        }


        protected Task<List<T1>> DoPaingation<T1>(IQueryable<T1> query, RequestGrid request)
        {
            if (request == null)
            {
                request = new RequestGrid
                {
                    Length = 10,
                    Start = 0
                };
            }
            if (request.Start == 0)
                request.Start = 1;
            if (request.Length <= 0)
                request.Length = 10;


            return query.Skip(request.Start).Take(request.Length).ToListAsync();

        }
    }
}
