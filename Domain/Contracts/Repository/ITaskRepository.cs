using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repository
{
    public interface ITaskRepository : IRepository<Entities.Tasks>
    {        
        Task<List<Tasks>> GetTasksPaginatedAsync(RequestGrid request, int userID);
        Tasks GetTask(int taskID, int userID);
    }
}
