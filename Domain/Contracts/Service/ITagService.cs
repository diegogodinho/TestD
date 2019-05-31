using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Service
{
    public interface ITagService : IService<Tag>
    {
        Task<List<Tag>> GetTasks(int userID);
        Task<List<Tag>> GetTasksPaginatedAsync(RequestGrid request, int userID);
        List<Tag> GetTasksPaginated(RequestGrid request, int userID);
        void SaveTag(Tag newTag);
    }
}
