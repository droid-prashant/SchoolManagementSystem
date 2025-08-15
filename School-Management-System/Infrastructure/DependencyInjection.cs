using System.Diagnostics;
using Application.ClassRooms.Interfaces;
using Application.Common.Interfaces;
using Application.Courses.Interfaces;
using Application.Students.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Services.ClassRooms;
using Infrastructure.Services.Courses;
using Infrastructure.Services.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("DbString"));
            });
            services.AddScoped<IApplicationDbContext>(x=>x.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassRoomService, ClassRoomService>();
            services.AddScoped<ICourseService, CourseService>();
            return services;
        }
    }
}
