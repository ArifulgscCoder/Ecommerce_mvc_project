namespace MyProjectSite.Migrations
{
    using MyProjectSite.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyProjectSite.Models.MyAppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyProjectSite.Models.MyAppDBContext context)
        {
            context.Customers.AddOrUpdate(
              c => c.CustomerID,
              new Customer
              {
                  CustomerID = 1,
                  First_Name = "Ariful",
                  Last_Name = "Islam",
                  UserName = "user@gmail.com",
                  Password = "12345",
                  Gender = "Male",
                  DateofBirth = new DateTime(1997, 12, 15),
                  Country = "Bangladesh",
                  City = "Tangail",
                  Email = "ariful@example.com",
                  Phone = "01500000001",
                  Address = "Mohammadpur",
                  PicturePath = "~/content/frontend/img/elements/g8.png"
              },
              new Customer
              {
                  CustomerID = 2,
                  First_Name = "Esmat Ara",
                  Last_Name = "Nadia",
                  UserName = "nadia007",
                  Password = "password456",
                  Gender = "Female",
                  DateofBirth = new DateTime(1998, 07, 04),
                  Country = "Bangladesh",
                  City = "Dhaka",
                  Email = "nadia@example.com",
                  Phone = "01600000001",
                  Address = "Mirpur 11",
                  PicturePath = "~/content/frontend/img/elements/user2.png"
              }
          );
            context.SaveChanges();


            // Seed AdminEmps
            context.adminEmployees.AddOrUpdate(
                a => a.EmpID,
                new AdminEmp
                {
                    FirstName = "Ariful",
                    LastName = "Islam",
                    Gender = "Male",
                    Email = "arifulgsc01@gmail.com",
                    Phone = "01908933132",

                    Address = "Tangail"
                },
                new AdminEmp
                {
                    FirstName = "Monir",
                    LastName = "Khan",
                    Gender = "Male",
                    Email = "monir@gmail.com",
                    Phone = "01500000000",

                    Address = "Tangail"
                }
            );

            context.SaveChanges();

            // Seed Roles
            context.Roles.AddOrUpdate(
                r => r.RoleID,
                new Role { RoleID = 1, RoleName = "Admin" },
                new Role { RoleID = 2, RoleName = "Admin 2" }
            );

            context.SaveChanges();


            context.adminLogins.AddOrUpdate(
                l => l.LoginID,
                new AdminLogin
                {
                    EmpID = 1,
                    UserName = "admin",
                    Password = "admin",
                    RoleType = 1,
                    AdminEmp = context.adminEmployees.First(a => a.FirstName == "Ariful"),
                    Role = context.Roles.First(r => r.RoleID == 1)
                },
                new AdminLogin
                {
                    EmpID = 2,
                    UserName = "admin2",
                    Password = "admin2",
                    RoleType = 2,
                    AdminEmp = context.adminEmployees.First(a => a.FirstName == "Ariful"),
                    Role = context.Roles.First(r => r.RoleID == 2)
                }
            );

            context.SaveChanges();

            //Product List///////////////
            var products = new List<Product>
{
    new Product
    {
        ProductID = 1,
        Name = "Snackers",
        CategoryID = 4,
        SubCategoryID = 7,
        UnitPrice = 2000,
        OldPrice =2200,
        UnitInStock = 15,
        ShortDescription = "Description for product 1",
        PicturePath = "~/Images/f-p-1.jpg"
    },
    new Product
    {
        ProductID = 2,
        Name = "Digital Watch",
        CategoryID = 1,
        SubCategoryID = 2,
        UnitPrice = 800,
        OldPrice = 1000,
        UnitInStock = 50,
        ShortDescription = "Description for product 2",
        PicturePath = "~/Images/watchdigital.jpeg"
    },
    new Product
    {
        ProductID = 3,
        Name = "Jeans",
        CategoryID = 2,
        SubCategoryID = 3,
        UnitPrice = 1500,
        OldPrice = 1800,
        UnitInStock = 25,
        ShortDescription = "Description for product 3",
        PicturePath = "~/Images/manjeans1.jpeg"
    } ,
    new Product
    {
        ProductID = 4,
        Name = "Men Watch",
        CategoryID = 1,
        SubCategoryID = 1,
        UnitPrice = 500,
        OldPrice = 550,
        UnitInStock = 10,
        ShortDescription = "Description for product 3",
        PicturePath = "~/Images/i3.jpg"
     } ,
    new Product
    {
        ProductID = 5,
        Name = "Men Snackers",
        CategoryID = 4,
        SubCategoryID = 8,
        UnitPrice = 2500,
        OldPrice = 2750,
        UnitInStock = 15,
        ShortDescription = "Description for product 3",
        PicturePath = "~/Images/snackers2.jpeg"
    },
                new Product
    {
        ProductID = 6,
        Name = "Men Watch Pro",
        CategoryID = 1,
        SubCategoryID = 1,
        UnitPrice = 1200,
        OldPrice = 1250,
        UnitInStock = 00,
        ShortDescription = "Description for product 3",
        PicturePath = "~/Images/n2.jpg"
    },
                new Product
    {
        ProductID = 7,
        Name = "Men Polo shirt",
        CategoryID = 3,
        SubCategoryID = 5,
        UnitPrice = 700,
        OldPrice =750,
        UnitInStock = 30,
        ShortDescription = "Description for product 3",
        PicturePath = "~/Images/polo-shirt-5.png"
    },
                new Product
    {
        ProductID = 8,
        Name = "Men Export Jeans",
        CategoryID = 2,
        SubCategoryID = 4,
        UnitPrice = 900,
        OldPrice = 1450,
        UnitInStock = 20,
        ShortDescription = "Description for product 3",
        PicturePath = "~/Images/menjeans2.jpeg"
    },
                new Product
    {
        ProductID = 9,
        Name = "Shoe",
        CategoryID = 4,
        SubCategoryID = 8,
        UnitPrice = 2000,
        OldPrice = 2350,
        UnitInStock = 9,
        ShortDescription = "Description for product 3",
        PicturePath = "~/Images/n4.jpg"
    }
};


            var categories = new List<Category>
{
    new Category
    {
        CategoryID = 1,
        Name = "Watch",
        Description = "Watch Items",
        SubCategories = new List<SubCategory>
        {
            new SubCategory { SubCategoryID = 1, Name = "Digital Watch" },

            new SubCategory { SubCategoryID = 2, Name = "Smart Watch" }
        }
    },
    new Category
    {
        CategoryID = 2,
        Name = "Jeans",
        Description = "Various kinds of Jeans",
        SubCategories = new List<SubCategory>
        {
            new SubCategory { SubCategoryID = 3, Name = "Export Jeans" } ,
            new SubCategory { SubCategoryID = 4, Name = "Normal Jeans" }
        }
    },
    new Category
    {
        CategoryID = 3,
        Name = "Shirt",
        Description = "Various kinds of Shirt",
        SubCategories = new List<SubCategory>
        {
            new SubCategory { SubCategoryID = 5, Name = "Polo" } ,
            new SubCategory { SubCategoryID = 6, Name = "T_Shirt" }
        }
    },
    new Category
    {
        CategoryID = 4,
        Name = "Snackers",
        Description = "Various kinds of Snackers",
        SubCategories = new List<SubCategory>
        {
            new SubCategory { SubCategoryID = 7, Name = "Shoe" } ,
            new SubCategory { SubCategoryID = 8, Name = "Lofer" }
        }
    }
};


            foreach (var category in categories)
            {
                context.Categories.AddOrUpdate(c => c.CategoryID, category);
            }
            context.SaveChanges();

            // Add products to the database
            foreach (var product in products)
            {
                context.Products.AddOrUpdate(p => p.ProductID, product);
            }
            context.SaveChanges();
        }
    }
}
