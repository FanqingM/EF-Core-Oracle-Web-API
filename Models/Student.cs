using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Student
    {
        public Student()
        {
            Takes = new HashSet<Take>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public byte? TotCred { get; set; }

        public virtual Department DeptNameNavigation { get; set; }
        public virtual Advisor Advisor { get; set; }
        public virtual ICollection<Take> Takes { get; set; }
    }
}
