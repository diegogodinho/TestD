using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{    
    public class TagService : Service<Tag>, ITagService
    {
        private readonly ITagRepository repository;

        public TagService(ITagRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public Task<List<Tag>> GetTasks(int userID)
        {
            return this.repository.GetTasks(userID);
        }

        public Task<List<Tag>> GetTasksPaginatedAsync(RequestGrid request, int userID)
        {
            return this.repository.GetTasksPaginatedAsync(request, userID);
        }

        public List<Tag> GetTasksPaginated(RequestGrid request, int userID)
        {
            return this.repository.GetTasksPaginated(request, userID);
        }

        public void SaveTag(Tag newTag)
        {
            //Business Rules Would take place here!
            this.repository.Add(newTag);
        }
    }
}
