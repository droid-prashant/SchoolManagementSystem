using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Courses.Dtos;
using Application.Courses.ViewModels;

namespace Application.Courses.Interfaces
{
    public interface ICourseService
    {
        Task AddCourse(CourseDto courseDto, CancellationToken cancellationToken);
        Task<List<CourseViewModel>> GetCourse(CancellationToken cancellationToken);
        Task<List<CourseViewModel>> GetCourseByClassId(Guid classRoomId, CancellationToken cancellationToken);
    }
}
