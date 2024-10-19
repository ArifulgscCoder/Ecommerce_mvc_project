using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyProjectSite.Models
{
    public partial class MyAppDBContext:DbContext
    {
        public MyAppDBContext()
           : base("MyAppDBContext")
        {
        }

        public virtual DbSet<AdminEmp> adminEmployees { get; set; }
        public virtual DbSet<AdminLogin> adminLogins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
       
        
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
       
       
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShippingAddress> ShippingAddresss { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
       
        public virtual DbSet<Wishlist> Wishlists { get; set; }
    }
}