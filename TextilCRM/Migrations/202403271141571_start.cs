namespace TextilCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Notes = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Width = c.String(),
                        Color = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        Notes = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.CustomerProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Name = c.String(),
                        Notes = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unvan = c.String(),
                        Vergi_Dairesi = c.String(),
                        Vergi_No = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        ContactPerson = c.String(),
                        ContactPersonPhone = c.String(),
                        ContactPersonEmail = c.String(),
                        Notes = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        ContactPerson = c.String(),
                        ContactPersonPhone = c.String(),
                        ContactPersonEmail = c.String(),
                        Notes = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Processes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProcessName = c.String(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Processes", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.DeliveryAddresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerProducts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Processes", new[] { "Customer_Id" });
            DropIndex("dbo.DeliveryAddresses", new[] { "CustomerId" });
            DropIndex("dbo.CustomerProducts", new[] { "ProductId" });
            DropIndex("dbo.CustomerProducts", new[] { "CustomerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Processes");
            DropTable("dbo.DeliveryAddresses");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
