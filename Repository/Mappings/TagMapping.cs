using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Mappings
{
    public class TagMapping : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(r => r.ID);
            builder.Property(r => r.ID).HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Property(r => r.Name);
            builder.Property(r => r.UserID);
            builder.HasOne(r => r.User);
        }
    }
}
