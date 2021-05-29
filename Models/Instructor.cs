using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Advisors = new HashSet<Advisor>();
            Teaches = new HashSet<Teach>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public decimal? Salary { get; set; }

        public virtual Department DeptNameNavigation { get; set; }
        public virtual ICollection<Advisor> Advisors { get; set; }
        public virtual ICollection<Teach> Teaches { get; set; }
    }
}
