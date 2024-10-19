using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProjectSite.Models
{
    public partial class Product
    {
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();

            this.Wishlists = new HashSet<Wishlist>();
        }
        [Key]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }
      
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        [Display(Name = "SubCategory")]
        public Nullable<int> SubCategoryID { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Previous Price")]
        public Nullable<decimal> OldPrice { get; set; }
        
        [Display(Name = "Stock")]
        public Nullable<int> UnitInStock { get; set; }
        
     
        [Display(Name = "Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }


        public virtual Category Category { get; set; }
       
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}