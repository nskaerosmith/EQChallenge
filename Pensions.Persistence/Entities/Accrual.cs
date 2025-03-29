using System;

namespace Pensions.Persistence.Entities
{
    public class Accrual
    {
        public int Id { get; set; }

        public DateTime EffectiveDate { get; set; }

        public float Rate { get; set; }
    }
}
