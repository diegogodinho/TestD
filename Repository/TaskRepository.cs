using Domain.Contracts.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.ViewModels;

namespace Repository
{
    public class TaskRepository : Repository<Tasks>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context) { }

        public Task<List<Tasks>> GetTasks(int userID)
        {
            return this.context.Tasks.Where(r => r.UserID == userID).ToListAsync();
        }

        public Task<List<Tasks>> GetTasksPaginatedAsync(RequestGrid request, int userID)
        {
            return DoPaingationAsync(this.context.Tasks.Where(r => r.UserID == userID), request);
        }
       
        public List<Domain.Entities.Tasks> GetTasksPaginated(RequestGrid request, int userID)
        {
            return DoPaingation(this.context.Tasks.Where(r => r.UserID == userID), request);
        }
    }
}
