using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
            builder.HasKey(r => r.Name);
            builder.HasKey(r => r.UserID);
            builder.HasOne(r => r.User);
        }
    }
}
