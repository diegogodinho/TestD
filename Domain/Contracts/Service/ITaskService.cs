using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Service
{
    public interface ITaskService : IService<Tasks>
    {
        Task<List<Tasks>> Get(int userID);
        Task<List<Tasks>> GetPaginatedAsync(RequestGrid request, int userID);
        List<Tasks> GetPaginated(RequestGrid request, int userID);
        void UpdateStatus(int idTag);
    }
}
