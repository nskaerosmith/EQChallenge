using System;
using System.ComponentModel.DataAnnotations;

namespace Pensions.Persistence.Entities
{
    public class Service
    {
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        // Relationships
        public int BasicId { get; set; }
        public Basic Basic { get; set; }
        public int SchemeId { get; set; }
        public Scheme Scheme { get; set; }
    }
}
