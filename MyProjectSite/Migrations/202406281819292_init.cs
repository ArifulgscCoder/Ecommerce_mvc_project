﻿namespace MyProjectSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminEmps",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateofBirth = c.DateTime(),
                        Gender = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.EmpID);
            
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        EmpID = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleType = c.Int(),
                        AdminEmp_EmpID = c.Int(),
                        Role_RoleID = c.Int(),
                        AdminEmp_EmpID1 = c.Int(),
                        AdminEmp_EmpID2 = c.Int(),
                    })
                .PrimaryKey(t => t.LoginID)
                .ForeignKey("dbo.AdminEmps", t => t.AdminEmp_EmpID)
                .ForeignKey("dbo.Roles", t => t.Role_RoleID)
                .ForeignKey("dbo.AdminEmps", t => t.AdminEmp_EmpID1)
                .ForeignKey("dbo.AdminEmps", t => t.AdminEmp_EmpID2)
                .Index(t => t.AdminEmp_EmpID)
                .Index(t => t.Role_RoleID)
                .Index(t => t.AdminEmp_EmpID1)
                .Index(t => t.AdminEmp_EmpID2);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryID = c.Int(nullable: false),
                        SubCategoryID = c.Int(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldPrice = c.Decimal(precision: 18, scale: 2),
                        UnitInStock = c.Int(),
                        ShortDescription = c.String(),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                        OrderDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderDetailsID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PaymentID = c.Int(),
                        ShippingID = c.Int(),
                        Discount = c.Int(),
                        Taxes = c.Int(),
                        TotalAmount = c.Int(),
                        OrderDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentID)
                .ForeignKey("dbo.ShippingAddresses", t => t.ShippingID)
                .Index(t => t.CustomerID)
                .Index(t => t.PaymentID)
                .Index(t => t.ShippingID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Gender = c.String(),
                        DateofBirth = c.DateTime(),
                        Country = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        WishlistID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WishlistID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        CreditAmount = c.Decimal(precision: 18, scale: 2),
                        DebitAmount = c.Decimal(precision: 18, scale: 2),
                        Balance = c.Decimal(precision: 18, scale: 2),
                        PaymentDateTime = c.DateTime(),
                        PaymentType_PayTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentType_PayTypeID)
                .Index(t => t.PaymentType_PayTypeID);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PayTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PayTypeID);
            
            CreateTable(
                "dbo.ShippingAddresses",
                c => new
                    {
                        ShippingID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        Address = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.ShippingID);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        isActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategoryID", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "ShippingID", "dbo.ShippingAddresses");
            DropForeignKey("dbo.Payments", "PaymentType_PayTypeID", "dbo.PaymentTypes");
            DropForeignKey("dbo.Orders", "PaymentID", "dbo.Payments");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Wishlists", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Wishlists", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.AdminLogins", "AdminEmp_EmpID2", "dbo.AdminEmps");
            DropForeignKey("dbo.AdminLogins", "AdminEmp_EmpID1", "dbo.AdminEmps");
            DropForeignKey("dbo.AdminLogins", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.AdminLogins", "AdminEmp_EmpID", "dbo.AdminEmps");
            DropIndex("dbo.SubCategories", new[] { "CategoryID" });
            DropIndex("dbo.Payments", new[] { "PaymentType_PayTypeID" });
            DropIndex("dbo.Wishlists", new[] { "ProductID" });
            DropIndex("dbo.Wishlists", new[] { "CustomerID" });
            DropIndex("dbo.Orders", new[] { "ShippingID" });
            DropIndex("dbo.Orders", new[] { "PaymentID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "SubCategoryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.AdminLogins", new[] { "AdminEmp_EmpID2" });
            DropIndex("dbo.AdminLogins", new[] { "AdminEmp_EmpID1" });
            DropIndex("dbo.AdminLogins", new[] { "Role_RoleID" });
            DropIndex("dbo.AdminLogins", new[] { "AdminEmp_EmpID" });
            DropTable("dbo.SubCategories");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Payments");
            DropTable("dbo.Wishlists");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Roles");
            DropTable("dbo.AdminLogins");
            DropTable("dbo.AdminEmps");
        }
    }
}
