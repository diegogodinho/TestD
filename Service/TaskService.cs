using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class TaskService : Service<Tasks>, ITaskService
    {
        private readonly ITaskRepository repository;

        public TaskService(ITaskRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public Task<List<Tasks>> Get(int userID)
        {
            return this.repository.GetTasks(userID);
        }

        public Task<List<Tasks>> GetPaginatedAsync(RequestGrid request, int userID)
        {
            return this.repository.GetTasksPaginatedAsync(request, userID);
        }

        public List<Domain.Entities.Tasks> GetPaginated(RequestGrid request, int userID)
        {
            return this.repository.GetTasksPaginated(request, userID);
        }

        public void Save(Domain.Entities.Tasks newTag)
        {
            //Business Rules Would take place here!
            newTag.LastChange = DateTime.Now;
            this.repository.Add(newTag);
        }

        public override void Update(Domain.Entities.Tasks entity)
        {
            ///Business logic would take place here
            entity.LastChange = DateTime.Now;
            base.Update(entity);
        }

        public void UpdateStatus(int idTag)
        {
            Domain.Entities.Tasks tagDb = repository.GetByID(idTag);
            if (tagDb != null)
            {
                tagDb.Checked = !tagDb.Checked;
                tagDb.LastChange = DateTime.Now;
                repository.Update(tagDb);
            }
            else
            {
                throw new Exception("invalid ID");
            }
        }
    }
}
