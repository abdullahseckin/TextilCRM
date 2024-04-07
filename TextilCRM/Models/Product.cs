using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextilCRM.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Width { get; set; }
        public string Color { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        // category ile ilişkili
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}