using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.SubjectMarks.Dtos;
using Application.SubjectMarks.Interfaces;
using Domain;

namespace Infrastructure.Services.SubjectMarks
{
    public class SubjectMarkService : ISubjectMarkService
    {
        private readonly IApplicationDbContext _context;
        public SubjectMarkService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddSubjectMarks(List<SubjectMarkDto> subjectMarklist, CancellationToken cancellationToken)
        {
            foreach (var subjectMarkObj in subjectMarklist)
            {
                double gradePointTheory = calculateGradePoint(subjectMarkObj.ObtainedTheoryMarks, subjectMarkObj.FullTheoryMarks);
                double gradePointPractical = calculateGradePoint(subjectMarkObj.ObtainedPracticalMarks, subjectMarkObj.FullPracticalMarks);

                double totalCredit = subjectMarkObj.TheoryCredit + subjectMarkObj.PracticalCredit;
                double finalGradePoint = ((gradePointTheory * subjectMarkObj.TheoryCredit) + (gradePointPractical * subjectMarkObj.PracticalCredit)) / totalCredit;

                string gradeTheory = calculateGrade(subjectMarkObj.ObtainedTheoryMarks, subjectMarkObj.FullTheoryMarks);
                string gradePractical = calculateGrade(subjectMarkObj.ObtainedPracticalMarks, subjectMarkObj.FullPracticalMarks);
                string finalGrade = calculateFinalGrade(finalGradePoint);

                var subjectMark = new SubjectMark
                {
                    StudentId = subjectMarkObj.StudentId,
                    CourseId = subjectMarkObj.CourseId,
                    FullTheoryMarks = subjectMarkObj.FullTheoryMarks,
                    PassTheoryMarks = subjectMarkObj.PassTheoryMarks,
                    FullPracticalMarks = subjectMarkObj.FullPracticalMarks,
                    PassPracticalMarks = subjectMarkObj.PassPracticalMarks,
                    ObtainedTheoryMarks = subjectMarkObj.ObtainedTheoryMarks,
                    ObtainedPracticalMarks = subjectMarkObj.ObtainedPracticalMarks,
                    GradeTheory = gradeTheory,
                    GradePointTheory = gradePointTheory,
                    GradePractical = gradePractical,
                    GradePointPractical = gradePointPractical,
                    FinalGrade = finalGrade
                };
                await _context.SubjectMarks.AddAsync(subjectMark);
            }
        }
        private string calculateGrade(double obtainedMarks, double fullMarks)
        {
            double percent = (obtainedMarks / fullMarks) * 100;
            string grade = percent switch
            {
                >= 90 => "A+",  // 3.6–4.0
                >= 80 => "A",   // 3.2–3.6
                >= 70 => "B+",  // 2.8–3.2
                >= 60 => "B",   // 2.4–2.8
                >= 50 => "C+",  // 2.0–2.4
                >= 40 => "C",   // 1.8–2.0
                >= 37 => "D+",  // 1.6–1.8
                >= 35 => "D",   // fixed at 1.6
                _ => "F"        // fail
            };
            return grade;
        }

        string calculateFinalGrade(double gradePoint)
        {
            var grade = gradePoint switch
            {
                >= 3.6 => "A+",
                >= 3.2 => "A",
                >= 2.8 => "B+",
                >= 2.4 => "B",
                >= 2.0 => "C+",
                >= 1.8 => "C",
                >= 1.6 => "D+",
                >= 1.5 => "D",
                _ => "F"
            };
            return grade;
        }

        private double calculateGradePoint(double obtainedMarks, double fullMarks)
        {
            double percent = (obtainedMarks / fullMarks) * 100;
            double gradePoint = percent switch
            {
                >= 90 => 3.6 + (percent - 90) / 25.0,      // 3.6–4.0
                >= 80 => 3.2 + (percent - 80) / 25.0,      // 3.2–3.6
                >= 70 => 2.8 + (percent - 70) / 25.0,      // 2.8–3.2
                >= 60 => 2.4 + (percent - 60) / 25.0,      // 2.4–2.8
                >= 50 => 2.0 + (percent - 50) / 25.0,      // 2.0–2.4
                >= 40 => 1.8 + (percent - 40) / 25.0,      // 1.8–2.0
                >= 37 => 1.6 + (percent - 37) / 7.5,       // 1.6–1.8
                >= 35 => 1.6,                              // fixed at 1.6
                _ => 0.0                                   // fail
            };
            return gradePoint;
        }
    }
}
