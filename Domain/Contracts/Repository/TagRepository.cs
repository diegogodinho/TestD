using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repository
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<List<Tag>> GetTasks(int userID);
        Task<List<Tag>> GetTasksPaginated(RequestGrid request, int userID);
    }
}
