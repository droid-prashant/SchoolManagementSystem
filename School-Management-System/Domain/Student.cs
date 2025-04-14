using System.Collections.ObjectModel;

namespace Domain
{
    public class Student:AuditableEntry
    {
        public Guid Id { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string GrandFatherName { get; set; } 
        public string FatherName { get; set; } 
        public string MotherName { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public Guid GradeId { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
