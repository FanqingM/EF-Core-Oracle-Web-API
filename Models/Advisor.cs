using System;
using System.Collections.Generic;

#nullable disable

namespace EFdemo.Models
{
    public partial class Advisor
    {
        public string SId { get; set; }
        public string IId { get; set; }

        public virtual Instructor IIdNavigation { get; set; }
        public virtual Student SIdNavigation { get; set; }
    }
}
