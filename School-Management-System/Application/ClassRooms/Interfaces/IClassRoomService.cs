using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ClassRooms.VieModels;
using Application.Students.ViewModels;

namespace Application.ClassRooms.Interfaces
{
    public interface IClassRoomService
    {
        Task<List<ClassRoomViewModel>> GetClassRoomList(CancellationToken cancellationToken);
    }
}
