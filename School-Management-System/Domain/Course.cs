using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course : AuditableEntry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreditHour { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public Guid ClassRoomId { get; set; }
        public string CourseType { get; set; }
        public int FullMarks { get; set; }
        public int PassMarks { get; set; }
        public ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
