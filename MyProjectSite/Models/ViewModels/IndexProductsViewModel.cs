using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProjectSite.Models.ViewModels
{
    public class IndexProductsViewModel
    {
        public List<Product> LatestestProducts { get; set;}
        public List<Product> CategoryProducts { get; set;}
        public List<Product> GetAllProducts { get; set;}

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }


    }
}