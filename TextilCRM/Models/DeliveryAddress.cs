using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextilCRM.Models
{
    public class DeliveryAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonEmail { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        // customer ile ilişkili
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        


    }
}