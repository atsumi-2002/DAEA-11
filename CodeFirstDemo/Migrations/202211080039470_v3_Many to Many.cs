namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3_ManytoMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        InvoiceNumber = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductInvoices",
                c => new
                    {
                        Product_ProductID = c.Int(nullable: false),
                        Invoice_InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductID, t.Invoice_InvoiceID })
                .ForeignKey("dbo.Products", t => t.Product_ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .Index(t => t.Product_ProductID)
                .Index(t => t.Invoice_InvoiceID);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    LastName = c.String(),
                })
                .PrimaryKey(t => t.CustomerID);

            CreateTable(
                "dbo.Sellers",
                c => new
                {
                    SellerID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    LastName = c.String(),
                })
                .PrimaryKey(t => t.SellerID);

            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                {
                    InvoiceDetailID = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    CustomerID = c.Int(nullable: false),
                    SellerID = c.Int(nullable: false),
                    InvoiceID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.InvoiceDetailID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.SellerID)
                .Index(t => t.InvoiceID);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.ProductInvoices", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.InvoiceDetails", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.ProductInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.ProductInvoices", new[] { "Product_ProductID" });
            DropIndex("dbo.InvoiceDetails", new[] { "CustomerID" });
            DropIndex("dbo.InvoiceDetails", new[] { "SellerID" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceID" });
            DropTable("dbo.ProductInvoices");
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.Students");
            DropTable("dbo.Sellers");
            DropTable("dbo.InvoiceDetails");
        }
    }
}
