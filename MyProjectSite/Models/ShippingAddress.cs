﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProjectSite.Models
{
    public partial class ShippingAddress
    {
        public ShippingAddress()
        {
            this.Orders = new HashSet<Order>();
        }
        [Key]
        public int ShippingID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
       
        public virtual ICollection<Order> Orders { get; set; }
    }
}