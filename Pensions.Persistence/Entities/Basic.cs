using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pensions.Persistence.Entities
{
    public class Basic
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Forename { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        // Relationships
        public Address Address { get; set; }
        public IEnumerable<Salary> SalaryHistory { get; set; }
        public IEnumerable<Service> ServiceHistory { get; set; }
    }
}