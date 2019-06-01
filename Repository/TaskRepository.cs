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

        public Task<List<Tasks>> GetTasksPaginatedAsync(RequestGrid request, int userID)
        {
            return DoPaingationAsync(this.context.Tasks.Where(r => r.UserID == userID), request);
        }        

        public Tasks GetTask(int taskID, int userID)
        {            
            return this.context.Tasks.Include("Historics").Where(r=> r.UserID == userID && r.ID == taskID).FirstOrDefault();
        }
    }
}
