using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextilCRM.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        // product ile ilişkili 
        public virtual ICollection<Product> Products { get; set; }

    }
}