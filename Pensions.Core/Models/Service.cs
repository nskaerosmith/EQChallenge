using System;
using System.Collections.Generic;
using System.Text;

namespace Pensions.Core.Models
{
    public class Service
    {
        public int BasicId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int SchemeId { get; set; }
    }
}
