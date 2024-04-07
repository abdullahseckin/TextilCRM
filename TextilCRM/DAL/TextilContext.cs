using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TextilCRM.DAL
{
    public class TextilContext: DbContext
    {
        // TextilContext için 
        // Constructor/yapıcı metot oluşturuldu.
        // ileride lazım olabilir.
        public TextilContext(): base("TextilContext")
        {
        }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.CustomerProduct> CustomerProducts { get; set; }
        public DbSet<Models.DeliveryAddress> DeliveryAddresses { get; set;}
        public DbSet<Models.Process> Processes { get; set; }

    }
}