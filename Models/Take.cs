using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Take
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string SecId { get; set; }
        public string Semester { get; set; }
        public byte Year { get; set; }
        public string Grade { get; set; }

        public virtual Student IdNavigation { get; set; }
        public virtual Section Section { get; set; }
    }
}
