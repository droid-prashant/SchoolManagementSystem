using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SubjectMark:AuditableEntry
    {
        public Guid Id { get; set; }
        public double FullMarks { get; set; }
        public double PassMarks { get; set; }
        public double ObtainedMarks { get; set; }
        public string Grade { get; set; }
    }
}
