using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course:AuditableEntry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreditHour { get; set; }
        public ICollection<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
        public Guid TeacherId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public Guid GradeId { get; set; }
    }
}
