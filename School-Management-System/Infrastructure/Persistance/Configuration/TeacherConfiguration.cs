﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Courses)
                   .WithOne(x => x.Teacher)
                   .HasForeignKey(x => x.TeacherId);

            builder.HasOne(x => x.ClassRoom)
                   .WithMany(x => x.Teachers)
                   .HasForeignKey(x => x.ClassId);
        }
    }
}
