using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Courses.ViewModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreditHour { get; set; }
        public string ClassRoom { get; set; }
        public string CourseType { get; set; }
        public int FullMarks { get; set; }
        public int PassMarks { get; set; }
    }
}
