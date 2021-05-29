using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Teach
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string SecId { get; set; }
        public string Semester { get; set; }
        public byte Year { get; set; }

        public virtual Instructor IdNavigation { get; set; }
        public virtual Section Section { get; set; }
    }
}
