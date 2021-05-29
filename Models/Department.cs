using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            Instructors = new HashSet<Instructor>();
            Students = new HashSet<Student>();
        }

        public string DeptName { get; set; }
        public string Building { get; set; }
        public decimal? Budget { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
