using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Mappings
{
    public class TaskHistoricMapping : IEntityTypeConfiguration<TaskHistoric>
    {
        public void Configure(EntityTypeBuilder<TaskHistoric> builder)
        {
            builder.HasKey(r => r.ID);
            builder.Property(r => r.ID).HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Property(r => r.Description);
            builder.Property(r => r.DateCreation);
            builder.Property(r => r.TaskID);
        }
    }
}
