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

            builder.HasData(
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                        Name = "One",
                        Section = "A",
                        RoomNumber = "1",
                        AcademicYear = "2024/2025"
                    },
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                        Name = "Two",
                        Section = "A",
                        RoomNumber = "2",
                        AcademicYear = "2024/2025"
                    },
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                        Name = "Three",
                        Section = "A",
                        RoomNumber = "3",
                        AcademicYear = "2024/2025"
                    },
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                        Name = "Four",
                        Section = "A",
                        RoomNumber = "4",
                        AcademicYear = "2024/2025"
                    },
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                        Name = "Five",
                        Section = "A",
                        RoomNumber = "5",
                        AcademicYear = "2024/2025"
                    },
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                        Name = "Six",
                        Section = "A",
                        RoomNumber = "6",
                        AcademicYear = "2024/2025"
                    },
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                        Name = "Seven",
                        Section = "A",
                        RoomNumber = "7",
                        AcademicYear = "2024/2025"
                    },
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                        Name = "Eight",
                        Section = "A",
                        RoomNumber = "8",
                        AcademicYear = "2024/2025"
                    },
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                        Name = "Nine",
                        Section = "A",
                        RoomNumber = "9",
                        AcademicYear = "2024/2025"
                    },
                    new ClassRoom
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                        Name = "Ten",
                        Section = "A",
                        RoomNumber = "10",
                        AcademicYear = "2024/2025"
                    }
             );
        }
    }
}
