using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new TagMapping());
        }
    }
}
