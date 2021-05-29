using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Prereq
    {
        public string CourseId { get; set; }
        public string PrereqId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Course PrereqNavigation { get; set; }
    }
}
