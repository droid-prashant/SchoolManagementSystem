using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClassRoom:AuditableEntry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string RoomNumber { get; set; }
        public string AcademicYear { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers{ get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
