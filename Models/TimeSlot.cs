using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class TimeSlot
    {
        public string TimeSlotId { get; set; }
        public string Day { get; set; }
        public byte StartHr { get; set; }
        public byte StartMin { get; set; }
        public byte? EndHr { get; set; }
        public byte? EndMin { get; set; }
    }
}
