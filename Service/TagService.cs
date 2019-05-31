using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class TagService : ITagService
    {
        private readonly ITagRepository repository;

        public TagService(ITagRepository repository)
        {
            this.repository = repository;
        }

        public void Delete(Tag tag)
        {
            repository.Delete(tag);
        }

        public Task<List<Tag>> GetAllAsync(int userID)
        {
            return repository.GetAllAsync(userID);
        }

        public Task<Tag> GetByIDAsync(int tagID)
        {
            return repository.GetByIDAsync(tagID);
        }

        public Task SaveAsync(Tag tag)
        {
            return repository.SaveAsync(tag);
        }
    }
}
