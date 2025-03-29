using System;

namespace Pensions.Core.Models
{
    public class Basic
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}