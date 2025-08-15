using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Students.Dtos;
using Application.Students.Interfaces;
using Application.Students.ViewModels;
using Azure.Core;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IApplicationDbContext _context;
        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddStudentAsync(StudentDto addStudent, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                FirstName = addStudent.FirstName,
                LastName = addStudent.LastName,
                FatherName = addStudent.FatherName,
                MotherName = addStudent.MotherName,
                GrandFatherName = addStudent.GrandFatherName,
                Gender = addStudent.Gender,
                Age = addStudent.Age,
                Address = addStudent.Address,
                ContactNumber = addStudent.ContactNumber,
                ClassRoomId = Guid.Parse(addStudent.ClassRoomId)
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<StudentViewModel>> GetStudentAsync(CancellationToken cancellationToken)
        {
            var students = await _context.Students.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName,
                Address = x.Address,
                Age = x.Age,
                ClassRoom = x.ClassRoom.Name,
                Section = x.ClassRoom.Section,
                Gender = x.Gender == 1 ? "Male" : "Female"
            })
                .ToListAsync(cancellationToken);
            return students;
        }
        public async Task<List<StudentViewModel>> GetStudentByClassIdAsync(Guid classRooomId, CancellationToken cancellationToken)
        {
            var students = await _context.Students.Include(x => x.ClassRoom)
                                                  .Where(x => x.ClassRoomId == classRooomId)
                                                  .Select(x => new StudentViewModel
                                                  {
                                                      Id = x.Id,
                                                      Name = x.FirstName + " " + x.LastName,
                                                      Address = x.Address,
                                                      Age = x.Age,
                                                      ClassRoom = x.ClassRoom.Name,
                                                      Section = x.ClassRoom.Section,
                                                      Gender = x.Gender == 1 ? "Male" : "Female"
                                                  })
                .ToListAsync(cancellationToken);
            return students;
        }
    }
}
