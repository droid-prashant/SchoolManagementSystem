using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassRooms.VieModels
{
    public class ClassRoomViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string RoomNumber { get; set; }
        public string AcademicYear { get; set; }
    }
}
