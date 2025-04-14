using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.ClassRooms.Command.CreateClassRoom
{
    public class CreateClassRoomCommand:IRequest
    {
        public string Name { get; set; }
        public string Section { get; set; }
        public string RoomNumber { get; set; }
        public string AcademicYear { get; set; }
    }
    public class CreateClassRoomCommandHandler : IRequestHandler<CreateClassRoomCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateClassRoomCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateClassRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = new ClassRoom
            {
                Name = request.Name,
                Section = request.Section,
                AcademicYear = request.AcademicYear,
                RoomNumber = request.RoomNumber
            };
            _context.ClassRooms.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
