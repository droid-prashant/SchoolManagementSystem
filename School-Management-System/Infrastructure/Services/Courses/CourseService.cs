using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Courses.Dtos;
using Application.Courses.Interfaces;
using Application.Courses.ViewModels;
using Azure.Core;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IApplicationDbContext _context;
        public CourseService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCourse(CourseDto courseDto, CancellationToken cancellationToken)
        {
            var course = new Course
            {
                Name = courseDto.Name,
                CreditHour = courseDto.CreditHour,
                ClassRoomId = courseDto.ClassRoomId,
                CourseType = courseDto.CourseType,
                FullMarks = courseDto.FullMarks,
                PassMarks = courseDto.PassMarks
            };
            _context.Courses.Add(course);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CourseViewModel>> GetCourse(CancellationToken cancellationToken)
        {
            var courseList = await _context.Courses.Select(x => new CourseViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreditHour = x.CreditHour,
                ClassRoom = x.ClassRoom.Name,
                 CourseType = x.CourseType,
                FullMarks = x.FullMarks,
                PassMarks = x.PassMarks
            }).ToListAsync(cancellationToken);

            return courseList;
        }

        public async Task<List<CourseViewModel>> GetCourseByClassId(Guid classRoomId, CancellationToken cancellationToken)
        {
            var courseList = await _context.Courses.Include(x => x.ClassRoom)
                                                   .Where(x => x.ClassRoomId == classRoomId)
                                                   .Select(x => new CourseViewModel
                                                   {
                                                       Id = x.Id,
                                                       Name = x.Name,
                                                       CreditHour = x.CreditHour,
                                                       ClassRoom = x.ClassRoom.Name,
                                                       CourseType = x.CourseType,
                                                       FullMarks = x.FullMarks,
                                                       PassMarks = x.PassMarks
                                                   }).ToListAsync(cancellationToken);

            return courseList;
        }
    }
}
