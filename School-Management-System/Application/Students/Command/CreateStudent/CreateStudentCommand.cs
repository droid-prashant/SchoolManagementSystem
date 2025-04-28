using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Students.Command.CreateStudent
{
    public class CreateStudentCommand:IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GrandFatherName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public Guid ClassRoomId { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                FirstName = request.LastName,
                LastName = request.GrandFatherName,
                FatherName = request.FatherName,
                MotherName = request.MotherName,
                GrandFatherName = request.GrandFatherName,
                Gender = request.Gender,
                Age = request.Age,
                Address = request.FirstName,
                ContactNumber = request.ContactNumber,
                ClassRoomId = request.ClassRoomId,
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
