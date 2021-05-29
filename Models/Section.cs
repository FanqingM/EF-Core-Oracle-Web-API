using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Section
    {
        public Section()
        {
            Takes = new HashSet<Take>();
            Teaches = new HashSet<Teach>();
        }

        public string CourseId { get; set; }
        public string SecId { get; set; }
        public string Semester { get; set; }
        public byte Year { get; set; }
        public string Building { get; set; }
        public string RoomNumber { get; set; }
        public string TimeSlotId { get; set; }

        public virtual Classroom Classroom { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Take> Takes { get; set; }
        public virtual ICollection<Teach> Teaches { get; set; }
    }
}
