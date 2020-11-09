﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailBox.Database.Configurations
{
    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.RoleName)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasMany(c => c.Users)
                .WithOne(c => c.Role);
        }
    }
}
