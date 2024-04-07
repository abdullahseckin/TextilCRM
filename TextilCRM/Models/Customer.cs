using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextilCRM.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unvan { get; set; }
        public string Vergi_Dairesi { get; set; }
        public string Vergi_No { get; set; }
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

        // delivery address ile ilişkili
        public virtual ICollection<DeliveryAddress> DeliveryAddresses { get; set; }

        // Process ile ilişkili
        public virtual ICollection<Process> Orders { get; set; }

        // CustomerProduct ile ilişkili
        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; }

    }
}