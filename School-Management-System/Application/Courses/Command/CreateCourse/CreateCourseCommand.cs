using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Courses.Command.CreateCourse
{
    public class CreateCourseCommand:IRequest
    {
        public string Name { get; set; }
        public string CreditHour { get; set; }
        public Guid ClassRoomId { get; set; }
    }
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateCourseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course
            {
                Name = request.Name,
                CreditHour = request.CreditHour,
                ClassRoomId = request.ClassRoomId,
            };
            _context.Courses.Add(course);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
