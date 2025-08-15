using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SubjectMarks.Dtos
{
    public class SubjectMarkDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public string ExamType { get; set; }
        public double TheoryCredit { get; set; }
        public double PracticalCredit { get; set; }
        public double FullTheoryMarks { get; set; }
        public double PassTheoryMarks { get; set; }
        public double FullPracticalMarks { get; set; }
        public double PassPracticalMarks { get; set; }
        public double ObtainedTheoryMarks { get; set; }
        public double ObtainedPracticalMarks { get; set; }
    }
}
