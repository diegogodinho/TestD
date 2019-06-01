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
        Task<List<Tasks>> GetTasks(int userID);
        Task<List<Tasks>> GetTasksPaginatedAsync(RequestGrid request, int userID);
        List<Tasks> GetTasksPaginated(RequestGrid request, int userID);
    }
}
