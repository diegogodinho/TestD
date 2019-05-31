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
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(DataContext context) : base(context) { }

        public Task<List<Tag>> GetTasks(int userID)
        {
            return this.context.Tag.Where(r => r.UserID == userID).ToListAsync();
        }

        public Task<List<Tag>> GetTasksPaginatedAsync(RequestGrid request, int userID)
        {
            return DoPaingationAsync<Tag>(this.context.Tag.Where(r => r.UserID == userID), request);
        }
       
        public List<Tag> GetTasksPaginated(RequestGrid request, int userID)
        {
            return DoPaingation<Tag>(this.context.Tag.Where(r => r.UserID == userID), request);
        }
    }
}
