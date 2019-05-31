using Domain.Contracts.Repository;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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


        protected Task<List<T1>> DoPaingationAsync<T1>(IQueryable<T1> query, RequestGrid request)
        {
            return _DoPaingation<T1>(query, request).ToListAsync();
        }

        protected List<T1> DoPaingation<T1>(IQueryable<T1> query, RequestGrid request)
        {
            return _DoPaingation<T1>(query, request).ToList();
        }

        private IQueryable<T1> _DoPaingation<T1>(IQueryable<T1> query, RequestGrid request)
        {
            if (request == null)
            {
                request = new RequestGrid
                {
                    Length = 10,
                    Start = 0
                };
            }            
            if (request.Length <= 0)
                request.Length = 10;

            request.Total = query.Count();

            request.Currentpage = (int)Math.Ceiling(request.Total / (double)request.Length);

            return query.Skip(request.Start).Take(request.Length);
        }

        public T Add(T entity)
        {            
            EntityEntry<T> response = context.Add(entity);
            context.SaveChanges();
            return response.Entity;
        }
    }
}
