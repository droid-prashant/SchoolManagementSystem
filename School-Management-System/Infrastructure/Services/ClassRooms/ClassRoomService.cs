using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ClassRooms.Interfaces;
using Application.ClassRooms.VieModels;
using Application.Common.Interfaces;
using Application.Students.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ClassRooms
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IApplicationDbContext _context;
        public ClassRoomService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ClassRoomViewModel>> GetClassRoomList(CancellationToken cancellationToken)
        {
            var classRooms = await _context.ClassRooms.Select(x => new ClassRoomViewModel
            {
                Id = x.Id,
                Name = x.Name,
                AcademicYear = x.AcademicYear,
                Section = x.Section,
                RoomNumber = x.RoomNumber,
            })
                .ToListAsync(cancellationToken);
            return classRooms;
        }
    }
}
