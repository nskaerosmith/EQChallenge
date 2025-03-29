using System.ComponentModel.DataAnnotations.Schema;

namespace Pensions.Persistence.Entities
{
    public class Address
    {
        public string HouseName { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        //Relationships
        public int BasicId { get; set; }
        [ForeignKey("BasicId")]
        public Basic Basic { get; set; }
    }
}
