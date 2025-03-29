using System;
using System.Collections.Generic;
using System.Text;

namespace Pensions.Core.Models
{
    public class Results
    {
        public int Id { get; set; }
        public int BasicId { get; set; }

        public double Value { get; set; }

        public DateTime DateOfCalculation { get; set; }
    }
}
