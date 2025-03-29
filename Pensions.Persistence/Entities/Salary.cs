using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pensions.Persistence.Entities
{
    public class Salary
    {
        public DateTime EffectiveDate { get; set; }

        [Required]
        public double Value { get; set; }

        //Relationships
        public int BasicId { get; set; }
        [ForeignKey("BasicId")]
        public Basic Basic { get; set; }
    }
}
