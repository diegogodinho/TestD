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

        public Task<List<Tasks>> GetPaginatedAsync(RequestGrid request, int userID)
        {
            return this.repository.GetTasksPaginatedAsync(request, userID);
        }

        public void Update(Tasks entity, int userID)
        {
            Tasks taskAttached = repository.GetTask(entity.ID, userID);
            taskAttached.Historics.Add(new TaskHistoric
            {
                Action = "Task Updated",
                Description = string.Format("Name updated from : {0} to: {1}{2} Description updated from: {3} to {4}",
                taskAttached.Name, entity.Name, Environment.NewLine, taskAttached.Description, entity.Description),
                DateCreation = DateTime.Now
            });
            taskAttached.Name = taskAttached.Name;
            taskAttached.Description = taskAttached.Description;

            base.Update(taskAttached);
        }

        public void UpdateStatus(int taskID, int userID)
        {
            Tasks tagDb = repository.GetTask(taskID, userID);
            if (tagDb != null)
            {
                tagDb.Checked = !tagDb.Checked;
                repository.Update(tagDb);
            }
            else
            {
                throw new Exception("invalid ID");
            }
        }

        public override Tasks Add(Tasks entity)
        {
            entity.Historics = new List<TaskHistoric>
            {
                new TaskHistoric
                {
                    Action = "Task Created",
                    Description = "Task was created",
                    DateCreation = DateTime.Now
                }
            };
            return base.Add(entity);
        }

        public Tasks Get(int idTag, int userID)
        {
            return repository.GetTask(idTag, userID);
        }
    }
}
