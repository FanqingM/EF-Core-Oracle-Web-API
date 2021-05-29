using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Classroom
    {
        public Classroom()
        {
            Sections = new HashSet<Section>();
        }

        public string Building { get; set; }
        public string RoomNumber { get; set; }
        public byte? Capacity { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
