using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Courses)
                   .WithOne(x => x.ClassRoom)
                   .HasForeignKey(x => x.ClassRoomId);

            builder.HasMany(x => x.Students)
                   .WithOne(x => x.ClassRoom)
                   .HasForeignKey(x => x.ClassRoomId);
        }
    }
}
