using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Course
    {
        public Course()
        {
            PrereqCourses = new HashSet<Prereq>();
            PrereqPrereqNavigations = new HashSet<Prereq>();
            Sections = new HashSet<Section>();
        }

        public string CourseId { get; set; }
        public string Title { get; set; }
        public string DeptName { get; set; }
        public byte? Credits { get; set; }

        public virtual Department DeptNameNavigation { get; set; }
        public virtual ICollection<Prereq> PrereqCourses { get; set; }
        public virtual ICollection<Prereq> PrereqPrereqNavigations { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
